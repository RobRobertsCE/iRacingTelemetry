using ibtParserLibrary.Helpers;
using ibtSessionLibrary;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ibtParserLibrary
{
    public class TelemetryFileParser
    {        
        #region fields
        static int _fieldCount;
        static int _frameCount;
        static ASCIIEncoding _ascii = new ASCIIEncoding();
        #endregion
        
        #region consts
        const int ChannelLength = 144;
        const int ChannelLengthStart = 0;
        const int ChannelLengthLength = 2;
        const int ChannelPositionStart = 4;
        const int ChannelPositionLength = 2;
        const int ChannelNameStart = 16;
        const int ChannelNameLength = 32;
        const int ChannelDescriptionStart = 48;
        const int ChannelDescriptionLength = 64;
        const int ChannelUnitStart = 112;
        const int ChannelUnitLength = 32;
        const int FieldCountStart = 24;
        const int FieldCountLength = 2;
        const int FrameCountStart = 140;
        const int FrameCountLength = 2;
        #endregion

        #region public methods       
        public static TelemetryFile ParseTelemetryFile(string fileName)
        {
            byte[] telemetryFileBytes = File.ReadAllBytes(fileName);
            return ParseTelemetryBinaryData(fileName, telemetryFileBytes);
        }
        public static TelemetryFile ParseTelemetryBinaryData(string fileName, byte[] telemetryFileBytes)
        {
            TelemetryFile telemetryData = new TelemetryFile(fileName);
            
            _fieldCount = GetIntFromBytes(telemetryFileBytes, FieldCountStart, FieldCountLength);
            _frameCount = GetIntFromBytes(telemetryFileBytes, FrameCountStart, FrameCountLength);

            var yamlStartTokenBytes = new byte[] { 45, 45, 45, 10 }; // '---\n'
            var yamlStartTokenIdx = telemetryFileBytes.Locate(yamlStartTokenBytes).FirstOrDefault();
            var yamlStartIdx = yamlStartTokenIdx + yamlStartTokenBytes.Length;
            var yamlEndTokenBytes = new byte[] { 10, 46, 46, 46, 10 }; // '\n...\n'
            var yamlEndIdx = telemetryFileBytes.Locate(yamlEndTokenBytes).FirstOrDefault();
            var yamlEndTokenEndIdx = yamlEndIdx + yamlEndTokenBytes.Length;
            var yamlLength = yamlEndIdx - yamlStartIdx;

            // get the header bytes
            var headerStartIdx = 0;
            var headerLength = yamlStartTokenIdx;
            telemetryData.RawHeader = new byte[headerLength];
            Array.Copy(telemetryFileBytes, headerStartIdx, telemetryData.RawHeader, 0, headerLength);

            // get the yaml bytes          
            telemetryData.RawYaml = new byte[yamlLength];
            Array.Copy(telemetryFileBytes, yamlStartIdx, telemetryData.RawYaml, 0, yamlLength);
            // get the yaml string
            telemetryData.Yaml = GetTextFromBytes(telemetryFileBytes, yamlStartIdx, yamlLength);

            // get the frames bytes
            var framesStartIdx = yamlEndTokenEndIdx;
            var framesLength = telemetryFileBytes.Length - framesStartIdx;
            telemetryData.RawFrames = new byte[framesLength];
            Array.Copy(telemetryFileBytes, framesStartIdx, telemetryData.RawFrames, 0, framesLength);
            
            ParseChannelDefinitionSection(telemetryData.RawHeader, telemetryData);

            ParseFrameSection(telemetryData.RawFrames, telemetryData);

            return telemetryData;
        }
        #endregion

        #region Channel Definitions
        static void ParseChannelDefinitionSection(byte[] telemetryFileBytes, TelemetryFile telemetryData)
        {
            int idx = 0;
            for (int i = 0; i < _fieldCount; i++)
            {               
                idx = ChannelLength + (ChannelLength * i);
                ParseChannel(telemetryFileBytes, idx, telemetryData);
            }
        }
        static void ParseChannel(byte[] telemetryFileBytes, int idx, TelemetryFile telemetryData)
        {
            byte[] channelBytes = new byte[ChannelLength];
            Array.Copy(telemetryFileBytes, idx, channelBytes, 0, ChannelLength);
            TelemetryChannelDefinition channel = new TelemetryChannelDefinition();
            channel.DataType = GetIntFromBytes(channelBytes, ChannelLengthStart, ChannelLengthLength);
            channel.Position = GetIntFromBytes(channelBytes, ChannelPositionStart, ChannelPositionLength);
            channel.Name = GetTextFromBytes(channelBytes, ChannelNameStart, ChannelNameLength);
            channel.Description = GetTextFromBytes(channelBytes, ChannelDescriptionStart, ChannelDescriptionLength);
            channel.Unit = GetTextFromBytes(channelBytes, ChannelUnitStart, ChannelUnitLength);
            telemetryData.Channels.Add(channel);
        }        
        static string GetTextFromBytes(byte[] bytes, int start, int length)
        {
            return _ascii.GetString(bytes, start, length).TrimEnd('\0');
        }
        static int GetIntFromBytes(byte[] bytes, int start, int length)
        {
            byte[] valueBytes = new byte[length];
            Array.Copy(bytes, start, valueBytes, 0, length);
            return (int)(valueBytes[0] + (256 * valueBytes[1]));
        }
        #endregion

        #region Frames   
        static int ParseFrameSection(byte[] frameSectionBytes, TelemetryFile telemetryData)
        {
            var startIdx = 0;
            var frameIdx = 0;
            byte[] frameBytes;
            var frameSize = telemetryData.Channels.Max((f) => f.Position + f.Size);
            while (true)
            {
                for (int frameByteIndex = startIdx; frameByteIndex < frameSectionBytes.Length - 1; frameByteIndex += frameSize)
                {
                    frameBytes = new byte[frameSize];
                    Array.Copy(frameSectionBytes, frameByteIndex, frameBytes, 0, frameSize);
                    var frame = new TelemetryFrame(frameIdx);
                    foreach (TelemetryChannelDefinition channel in telemetryData.Channels)
                    {
                        TelemetryChannelValue channelValue = new TelemetryChannelValue(channel);
                        channelValue.Bytes = new byte[channel.Size];
                        Array.Copy(frameBytes, channel.Position, channelValue.Bytes, 0, channel.Size);
                        frame.ChannelValues.Add(channelValue);
                    }
                    telemetryData.Frames.Add(frame);
                    frameIdx++;
                }
                break;
            }
            return _frameCount;
        }
        static object GetChannelValue(int dataType, byte[] bytes)
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
    }
}
