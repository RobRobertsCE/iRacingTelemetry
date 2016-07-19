using iRacing.TelemetryParser.Session;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;

namespace iRacing.TelemetryParser
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
        private TelemetrySession _session;
        public ITelemetrySession Session
        {
            get
            {
                return _session;
            }
        }
        public ITelemetrySessionInfo SessionInfo { get; private set; }
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
        #region ITelemetrySession
        /// <summary>
        /// Parses a telemetry file
        /// </summary>
        /// <param name="fileName">The telemetry file</param>
        /// <param name="metadataOnly">True = no telemetry values.</param>
        /// <returns></returns>
        public ITelemetrySession ParseTelemetryFile(string fileName, bool metadataOnly)
        {
            byte[] telemetryFileBytes = System.IO.File.ReadAllBytes(fileName);
            return ParseTelemetryBytes(fileName, telemetryFileBytes, metadataOnly);
        }

        /// <summary>
        /// Parses a telemetry file
        /// </summary>
        /// <param name="fileName">The telemetry file</param>
        /// <param name="telemetryFileBytes">the byte array of the file contents</param>
        /// <param name="metadataOnly">True = no telemetry values.</param>
        /// <returns></returns>
        public ITelemetrySession ParseTelemetryBytes(string fileName, byte[] telemetryFileBytes, bool metadataOnly)
        {
            _metaOnly = metadataOnly;
            int idx = 0;
            _session = new TelemetrySession(fileName);

            _fieldCount = GetIntFromBytes(telemetryFileBytes, FieldCountStart, FieldCountLength);
            _frameCount = GetIntFromBytes(telemetryFileBytes, FrameCountStart, FrameCountLength);

            if (!_metaOnly)
            {
                ParseFieldDescriptionSection(telemetryFileBytes, ref idx);
                _session.RawHeader = new byte[idx];
                Array.Copy(telemetryFileBytes, 0, _session.RawHeader, 0, idx);
            }

            ParseYamlSection(telemetryFileBytes, ref idx);
            
            if (!_metaOnly)
            {
                ParseValueSection(telemetryFileBytes, ref idx);
                ParseLaps();
            }

            return _session;
        }

        /// <summary>
        /// Parses the bytes from the telemetry session
        /// </summary>
        /// <param name="telemetryFileBytes">byte array of the telemetry session</param>
        public ITelemetrySession ParseTelemetryBytes(byte[] telemetryFileBytes)
        {
            return ParseTelemetryBytes(telemetryFileBytes, false);          
        }

        /// <summary>
        /// Parses the bytes from the telemetry session
        /// </summary>
        /// <param name="telemetryFileBytes">byte array of the telemetry session</param>
        /// <param name="metadataOnly">Does not parse actual telemetry values</param>
        public ITelemetrySession ParseTelemetryBytes(byte[] telemetryFileBytes, bool metadataOnly)
        {
            return ParseTelemetryBytes(string.Empty, telemetryFileBytes, metadataOnly);
        }
        #endregion

        #region ITelemetrySessionInfo
        /// <summary>
        /// Parses the session information (Session YAML, lap count, frame count, setup),
        /// but does not parse the actual telemetry values.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ITelemetrySessionInfo ParseTelemetrySessionInfo(string fileName)
        {
            byte[] telemetryFileBytes = System.IO.File.ReadAllBytes(fileName);
            this.SessionInfo = ParseTelemetrySessionInfo(fileName, telemetryFileBytes);
            return SessionInfo;
        }

        /// <summary>
        /// Parses the session information (Session YAML, lap count, frame count, setup),
        /// but does not parse the actual telemetry values.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="telemetryFileBytes"></param>
        /// <returns></returns>
        public ITelemetrySessionInfo ParseTelemetrySessionInfo(string fileName, byte[] telemetryFileBytes)
        {
            int idx = 0;
            _session = new TelemetrySession(fileName);

            _fieldCount = GetIntFromBytes(telemetryFileBytes, FieldCountStart, FieldCountLength);
            _frameCount = GetIntFromBytes(telemetryFileBytes, FrameCountStart, FrameCountLength);

            ParseFieldDescriptionSection(telemetryFileBytes, ref idx);
            _session.RawHeader = new byte[idx];
            Array.Copy(telemetryFileBytes, 0, _session.RawHeader, 0, idx);

            ParseYamlSection(telemetryFileBytes, ref idx);

            this.SessionInfo = TelemetrySessionInfoFactory.GetSessionInfo(_session.Yaml);
            
            return this.SessionInfo;
        }
        #endregion
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

            TelemetryChannelDefinition field = new TelemetryChannelDefinition();

            field.DataType = GetIntFromBytes(fieldDescriptionBytes, FieldDescriptionLengthStart, FieldDescriptionLengthLength);
            field.Position = GetIntFromBytes(fieldDescriptionBytes, FieldDescriptionPositionStart, FieldDescriptionPositionLength);
            field.Name = GetTextFromBytes(fieldDescriptionBytes, FieldDescriptionNameStart, FieldDescriptionNameLength);
            field.Description = GetTextFromBytes(fieldDescriptionBytes, FieldDescriptionDescriptionStart, FieldDescriptionDescriptionLength);
            field.Unit = GetTextFromBytes(fieldDescriptionBytes, FieldDescriptionUnitStart, FieldDescriptionUnitLength);

            _session.Fields.Add(field);
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
            _session.Yaml = GetTextFromBytes(telemetryFileBytes, yamlStartIdx, yamlLength);

            _session.RawYaml = new byte[yamlLength + 7];
            Array.Copy(telemetryFileBytes, yamlStartIdx - 3, _session.RawYaml, 0, yamlLength + 7);

            _session.SessionInfo = TelemetrySessionInfoFactory.GetSessionInfo(_session.Yaml);
        }
        #endregion

        #region Value Section
        int ParseValueSection(byte[] telemetryFileBytes, ref int dataStartIdx)
        {
            dataStartIdx += 1;
            var valueLength = telemetryFileBytes.Length - dataStartIdx;
            byte[] frameBytes = new byte[valueLength];
            Array.Copy(telemetryFileBytes, dataStartIdx, frameBytes, 0, valueLength);

            _session.RawFrames = new byte[valueLength];
            Array.Copy(telemetryFileBytes, dataStartIdx, _session.RawFrames, 0, valueLength);

            return ParseValues(frameBytes);
        }

        int ParseValues(byte[] valueSectionBytes)
        {
            var startIdx = 0;
            var frameIdx = 0;
            byte[] frameBytes;
            var frameSize = _session.Fields.Max((f) => f.Position + f.Size);

            while (true)
            {
                for (int frameByteIndex = startIdx; frameByteIndex < valueSectionBytes.Length - 1; frameByteIndex += frameSize)
                {
                    frameBytes = new byte[frameSize];
                    Array.Copy(valueSectionBytes, frameByteIndex, frameBytes, 0, frameSize);

                    var frame = new TelemetryFrame(frameIdx);
                    foreach (TelemetryChannelDefinition field in _session.Fields)
                    {
                        TelemetryChannelValue fieldValue = new TelemetryChannelValue(field);
                        fieldValue.Bytes = new byte[field.Size];
                        Array.Copy(frameBytes, field.Position, fieldValue.Bytes, 0, field.Size);
                        frame.ChannelValues.Add(fieldValue);
                    }

                    _session.Frames.Add(frame);
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
            int currentLapNumber = -1;
            int currentLapIdx = 0;
            foreach (var frame in _session.Frames.OrderBy(f => f.FrameIndex))
            {
                var lapBuffer = frame.GetValue(TelemetryConstants.LapKey);
                var lapNum = Convert.ToInt32(lapBuffer);
                if (lapNum > currentLapNumber)
                {
                    currentLap = new TelemetryLap(lapNum, currentLapIdx);
                    _session.Laps.Add(currentLap);
                    currentLapNumber = lapNum;
                    currentLapIdx++;
                }
                currentLap.Frames.Add(frame);
            }
        }      
        #endregion
    }
}
