using ibtSessionLibrary;
using System;
using System.Linq;
using System.Text;

namespace ibtParserLibrary
{
    public class ParserEngine
    {
        #region fields
        bool _metaOnly;
        int _fieldCount;
        int _frameCount;
        private ASCIIEncoding _ascii = new ASCIIEncoding();
        #endregion

        #region props
        public TelemetrySession Session { get; private set; }
        #endregion

        #region consts
        const int HeaderLength = 144;
        const int FieldDescriptionLength = 144;
        const int FieldDescriptionLengthStart = 0;
        const int FieldDescriptionLengthLength = 2;
        const int FieldDescriptionPositionStart = 4;
        const int FieldDescriptionPositionLength = 2;
        const int FieldDescriptionNameStart = 16;
        const int FieldDescriptionNameLength = 32;
        const int FieldDescriptionDescriptionStart = 48;
        const int FieldDescriptionDescriptionLength = 64;
        const int FieldDescriptionUnitStart = 112;
        const int FieldDescriptionUnitLength = 32;
        const int FieldCountStart = 24;
        const int FieldCountLength = 2;
        const int FrameCountStart = 140;
        const int FrameCountLength = 2;
        #endregion

        #region public methods
        public TelemetrySession ParseTelemetryFile(string fileName, bool metadataOnly)
        {
            byte[] telemetryFileBytes = System.IO.File.ReadAllBytes(fileName);
            return ParseTelemetryBytes(fileName, telemetryFileBytes, metadataOnly);
        }     
        public TelemetrySession ParseTelemetryBytes(string fileName, byte[] telemetryFileBytes,  bool metadataOnly)
        {
            _metaOnly = metadataOnly;
            int idx = 0;
            Session = new TelemetrySession(fileName);

            _fieldCount = GetIntFromBytes(telemetryFileBytes, FieldCountStart, FieldCountLength);
            _frameCount = GetIntFromBytes(telemetryFileBytes, FrameCountStart, FrameCountLength);

            if (!_metaOnly)
            {
                ParseFieldDescriptionSection(telemetryFileBytes, ref idx);
                Session.RawHeader = new byte[idx];
                Array.Copy(telemetryFileBytes, 0, Session.RawHeader, 0, idx);
            }
            
            ParseYamlSection(telemetryFileBytes, ref idx);

            Session.TelemetrySessionInfo = TelemetrySessionInfoFactory.GetSessionInfo(Session.Yaml);

            if (!_metaOnly)
            {
                ParseValueSection(telemetryFileBytes, ref idx);
                ParseLaps();
            }

            return Session;
        }
        #endregion

        #region Field Description Section
        void ParseFieldDescriptionSection(byte[] telemetryFileBytes, ref int idx)
        {
            for (int i = 0; i < _fieldCount; i++)
            {
                idx = FieldDescriptionLength + (FieldDescriptionLength * i);
                ParseFieldDescription(telemetryFileBytes, idx);
            }
            idx += FieldDescriptionLength;
            idx++;
        }

        void ParseFieldDescription(byte[] telemetryFileBytes, int idx)
        {
            byte[] fieldDescriptionBytes = new byte[FieldDescriptionLength];

            Array.Copy(telemetryFileBytes, idx, fieldDescriptionBytes, 0, FieldDescriptionLength);

            TelemetryFieldDefinition field = new TelemetryFieldDefinition();

            field.DataType = GetIntFromBytes(fieldDescriptionBytes, FieldDescriptionLengthStart, FieldDescriptionLengthLength);
            field.Position = GetIntFromBytes(fieldDescriptionBytes, FieldDescriptionPositionStart, FieldDescriptionPositionLength);
            field.Name = GetTextFromBytes(fieldDescriptionBytes, FieldDescriptionNameStart, FieldDescriptionNameLength);
            field.Description = GetTextFromBytes(fieldDescriptionBytes, FieldDescriptionDescriptionStart, FieldDescriptionDescriptionLength);
            field.Unit = GetTextFromBytes(fieldDescriptionBytes, FieldDescriptionUnitStart, FieldDescriptionUnitLength);

            Session.Fields.Add(field);
        }

        string GetTextFromBytes(byte[] bytes, int start, int length)
        {
            return _ascii.GetString(bytes, start, length).TrimEnd('\0');
        }

        int GetIntFromBytes(byte[] bytes, int start, int length)
        {
            byte[] valueBytes = new byte[length];
            Array.Copy(bytes, start, valueBytes, 0, length);
            return (int)(valueBytes[0] + (256 * valueBytes[1]));
        }
        #endregion

        #region YAML Section
        void ParseYamlSection(byte[] telemetryFileBytes, ref int idx)
        {
            idx += 3; // skip the three '-' characters that denote the start of the YAML section.
            int yamlStartIdx = idx;
            // find the three '.' characters that denote the end of the YAML section.
            while (true)
            {
                idx++;
                if (telemetryFileBytes[idx] == 46)
                {
                    if ((telemetryFileBytes[idx + 1] == 46) && (telemetryFileBytes[idx + 2] == 46))
                    {
                        idx += 3;
                        break;
                    }
                }
            }
            int yamlLength = idx - yamlStartIdx - 3; // exclude the three '.' characters on the end.
            Session.Yaml = GetTextFromBytes(telemetryFileBytes, yamlStartIdx, yamlLength);
            
            Session.RawYaml = new byte[yamlLength + 7];
            Array.Copy(telemetryFileBytes, yamlStartIdx - 3, Session.RawYaml, 0, yamlLength + 7);
        }
        #endregion
        
        #region Value Section
        int ParseValueSection(byte[] telemetryFileBytes, ref int dataStartIdx)
        {
            dataStartIdx += 1;
            var valueLength = telemetryFileBytes.Length - dataStartIdx;
            byte[] frameBytes = new byte[valueLength];
            Array.Copy(telemetryFileBytes, dataStartIdx, frameBytes, 0, valueLength);

            Session.RawFrames = new byte[valueLength];
            Array.Copy(telemetryFileBytes, dataStartIdx, Session.RawFrames, 0, valueLength);
            
            return ParseValues(frameBytes);
        }

        int ParseValues(byte[] valueSectionBytes)
        {
            var startIdx = 0;
            var frameIdx = 0;
            byte[] frameBytes;
            var frameSize = Session.Fields.Max((f) => f.Position + f.Size);

            while (true)
            {
                for (int frameByteIndex = startIdx; frameByteIndex < valueSectionBytes.Length - 1; frameByteIndex += frameSize)
                {
                    frameBytes = new byte[frameSize];
                    Array.Copy(valueSectionBytes, frameByteIndex, frameBytes, 0, frameSize);

                    var frame = new TelemetryFrame(frameIdx);
                    foreach (TelemetryFieldDefinition field in Session.Fields)
                    {
                        TelemetryFieldValue fieldValue = new TelemetryFieldValue(field);
                        fieldValue.Bytes = new byte[field.Size];
                        Array.Copy(frameBytes, field.Position, fieldValue.Bytes, 0, field.Size);
                        frame.FieldValues.Add(fieldValue);
                    }

                    Session.Frames.Add(frame);
                    frameIdx++;
                }
                break;
            }

            return _frameCount;
        }

        object GetFieldValue(int dataType, byte[] bytes)
        {
            object fieldValue = null;

            switch (dataType)
            {
                case 1:
                    {
                        fieldValue = BitConverter.ToBoolean(bytes, 0);
                        break;
                    }
                case 2:
                    {
                        fieldValue = BitConverter.ToInt16(bytes, 0);
                        break;
                    }
                case 3:
                    {
                        fieldValue = BitConverter.ToInt16(bytes, 0);
                        break;
                    }
                case 4:
                    {
                        fieldValue = BitConverter.ToSingle(bytes, 0);
                        break;
                    }
                case 5:
                    {
                        fieldValue = BitConverter.ToDouble(bytes, 0);
                        break;
                    }
            }
            return fieldValue;
        }
        #endregion

        #region Laps
        void ParseLaps()
        {
            TelemetryLap currentLap = new TelemetryLap();
            int currentLapIdx = -1;

            foreach (var frame in Session.Frames.OrderBy(f => f.FrameIndex))
            {
                var lapBuffer = frame.GetValue(TelemetryConstants.LapKey);
                var lapNum = Convert.ToInt32(lapBuffer);
                if (lapNum > currentLapIdx)
                {
                    currentLap = new TelemetryLap(lapNum);
                    Session.Laps.Add(currentLap);
                    currentLapIdx = lapNum;
                }
                currentLap.Frames.Add(frame);
            }
        }
        #endregion
    }
}
