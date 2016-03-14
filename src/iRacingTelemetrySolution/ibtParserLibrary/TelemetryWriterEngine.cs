using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibtParserLibrary
{
    public class TelemetryWriterEngine
    {

        #region fields
        int _fieldCount;
        int _frameCount;
        int _frameSize;
        byte[] _telemetryFileBytes;
        ASCIIEncoding _ascii = new ASCIIEncoding();
        #endregion

        #region properties
        public TelemetrySession Session { get; set; }
        #endregion

        #region consts
        const int HeaderLength = 144;
        const int FieldDescriptionLength = 144;
        const int FieldDescriptionDataTypeStart = 0;
        const int FieldDescriptionDataTypeLength = 2;
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
        public void WriteSessionToTemeletryFile(string fileName)
        {         
            var newField = new TelemetryFieldDefinition()
            {
                Name = "FOO",
                Description = "Testing123",
                Unit = "foos",
                DataType = 2, // int
                Position = Session.Fields.Max((f) => f.Position + f.Size) + 1
            };
            Session.Fields.Add(newField);
            foreach (var frame in Session.Frames)
            {
                TelemetryFieldValue fieldValue = new TelemetryFieldValue(newField);
                fieldValue.Bytes = new byte[newField.Size];
                var frameBytes = GetBytesFromInt(82); // <<<< assign value here
                Array.Copy(frameBytes, 0, fieldValue.Bytes, 0, newField.Size);
                frame.FieldValues.Add(fieldValue);
            }

            int idx = 0;
            _fieldCount = Session.Fields.Count();
            _frameCount = Session.Frames.Count();
            _frameSize = Session.Fields.Max((f) => f.Position + f.Size);




            var fieldDescriptionLength = Session.Fields.Count() * FieldDescriptionLength;
            var yamlLength = 3 + Session.Yaml.Length + 3;
            var frameSectionStart = fieldDescriptionLength + yamlLength + HeaderLength + 1;
            var frameSize = Session.Fields.Max((f) => f.Position + f.Size);
            var frameSectionLength = Session.Frames.Count() * frameSize;
            var totalSize = frameSectionStart + frameSectionLength + 1;

            _telemetryFileBytes = new byte[totalSize];

            WriteHeaderSection();
            idx++;
            WriteFieldDescriptionSection(ref idx);
            WriteYAMLSection(ref idx);
            WriteValueSection(ref idx);

            if (File.Exists(fileName))
                File.Delete(fileName);

            File.WriteAllBytes(fileName, _telemetryFileBytes);
        }
        #endregion

        #region Header Section
        private void WriteHeaderSection()
        {
            // copy the header, overwrite the field and frame counts
            Array.Copy(Session.RawHeader, 0, _telemetryFileBytes, 0, Session.RawHeader.Length);

            var fieldCountBytes = GetBytesFromInt(_fieldCount);
            var frameCountBytes = GetBytesFromInt(_frameCount);

            Array.Copy(fieldCountBytes, 0, _telemetryFileBytes, FieldCountStart, FieldCountLength);
            Array.Copy(frameCountBytes, 0, _telemetryFileBytes, FrameCountStart, FrameCountLength);
        }
        #endregion

        #region Field Description Section
        void WriteFieldDescriptionSection(ref int idx)
        {
            int i = 0;
            foreach (var fieldDefinition in Session.Fields)
            {
                idx = FieldDescriptionLength + (FieldDescriptionLength * i);
                WriteFieldDescription(fieldDefinition, idx);
                i++;
            }
            idx += FieldDescriptionLength;
            idx++;
        }

        void WriteFieldDescription(TelemetryFieldDefinition field, int idx)
        {
            byte[] fieldDescriptionBytes = new byte[FieldDescriptionLength];

            var dataTypeBytes = GetBytesFromInt(field.DataType);
            var positionBytes = GetBytesFromInt(field.Position);
            var nameBytes = GetBytesFromString(field.Name);
            var descriptionBytes = GetBytesFromString(field.Description);
            var unitBytes = GetBytesFromString(field.Unit);

            Array.Copy(dataTypeBytes, 0, _telemetryFileBytes, idx + FieldDescriptionDataTypeStart, dataTypeBytes.Length);
            Array.Copy(positionBytes, 0, _telemetryFileBytes, idx + FieldDescriptionPositionStart, positionBytes.Length);
            Array.Copy(nameBytes, 0, _telemetryFileBytes, idx + FieldDescriptionNameStart, nameBytes.Length);
            Array.Copy(descriptionBytes, 0, _telemetryFileBytes, idx + FieldDescriptionDescriptionStart, descriptionBytes.Length);
            Array.Copy(unitBytes, 0, _telemetryFileBytes, idx + FieldDescriptionUnitStart, unitBytes.Length);
        }
        #endregion

        #region YAML Section   
        void WriteYAMLSection(ref int idx)
        {
            var yamlBytes = new List<byte>();
            var dashBytes = GetBytesFromString("---\n");
            var dotBytes = GetBytesFromString("...\n");
            yamlBytes.AddRange(dashBytes);
            var sessionYamlBytes = GetBytesFromString(Session.Yaml);
            yamlBytes.AddRange(sessionYamlBytes);
            yamlBytes.AddRange(dotBytes);
            var yamlArray = yamlBytes.ToArray();
            var yamlLength = yamlArray.Length;
            Array.Copy(yamlArray, 0, _telemetryFileBytes, idx - 1, yamlLength);
            idx += yamlLength;
        }
        #endregion

        #region Value Section
        void WriteValueSection(ref int dataStartIdx)
        {
            Array.Copy(Session.RawFrames, 0, _telemetryFileBytes, dataStartIdx - 1, Session.RawFrames.Length);

            dataStartIdx += 1;


        }

        //int ParseValueSection(byte[] telemetryFileBytes, ref int dataStartIdx)
        //{
        //    dataStartIdx += 1;
        //    var valueLength = telemetryFileBytes.Length - dataStartIdx;
        //    byte[] frameBytes = new byte[valueLength];
        //    Array.Copy(telemetryFileBytes, dataStartIdx, frameBytes, 0, valueLength);
        //    return ParseValues(frameBytes);
        //}

        //int ParseValues(byte[] valueSectionBytes)
        //{
        //    var startIdx = 0;
        //    var frameIdx = 0;
        //    byte[] frameBytes;
        //    var frameSize = Session.Fields.Max((f) => f.Position + f.Size);

        //    while (true)
        //    {
        //        for (int frameByteIndex = startIdx; frameByteIndex < valueSectionBytes.Length - 1; frameByteIndex += frameSize)
        //        {
        //            frameBytes = new byte[frameSize];
        //            Array.Copy(valueSectionBytes, frameByteIndex, frameBytes, 0, frameSize);

        //            var frame = new TelemetryFrame(frameIdx);
        //            foreach (TelemetryFieldDefinition field in Session.Fields)
        //            {
        //                TelemetryFieldValue fieldValue = new TelemetryFieldValue(field);
        //                fieldValue.Bytes = new byte[field.Size];
        //                Array.Copy(frameBytes, field.Position, fieldValue.Bytes, 0, field.Size);
        //                frame.FieldValues.Add(fieldValue);
        //            }

        //            Session.Frames.Add(frame);
        //            frameIdx++;
        //        }
        //        break;
        //    }

        //    return frameCount;
        //}

        //object GetFieldValue(int dataType, byte[] bytes)
        //{
        //    object fieldValue = null;

        //    switch (dataType)
        //    {
        //        case 1:
        //            {
        //                fieldValue = BitConverter.ToBoolean(bytes, 0);
        //                break;
        //            }
        //        case 2:
        //            {
        //                fieldValue = BitConverter.ToInt16(bytes, 0);
        //                break;
        //            }
        //        case 3:
        //            {
        //                fieldValue = BitConverter.ToInt16(bytes, 0);
        //                break;
        //            }
        //        case 4:
        //            {
        //                fieldValue = BitConverter.ToSingle(bytes, 0);
        //                break;
        //            }
        //        case 5:
        //            {
        //                fieldValue = BitConverter.ToDouble(bytes, 0);
        //                break;
        //            }
        //    }
        //    return fieldValue;
        //}
        #endregion

        #region Helpers 
        byte[] GetBytesFromString(string value)
        {
            return _ascii.GetBytes(value);
        }
        byte[] GetBytesFromInt(int value)
        {
            return BitConverter.GetBytes(value);
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
    }
}
