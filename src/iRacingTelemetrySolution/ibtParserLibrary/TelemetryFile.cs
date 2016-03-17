﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Globalization;

namespace ibtParserLibrary
{
    public class TelemetryFile
    {
        #region props
        [Browsable(false)]
        public IList<TelemetryFrame> Frames { get; set; }
        public IList<TelemetryChannelDefinition> Channels { get; set; }
        public string FileName { get; set; }
        public string Yaml { get; set; }
        public byte[] RawHeader { get; set; }
        public byte[] RawYaml { get; set; }
        public byte[] RawFrames { get; set; }
        public DateTime Timestamp { get; set; }
        #endregion

        #region ctor
        public TelemetryFile()
        {
            Frames = new List<TelemetryFrame>();
            Channels = new List<TelemetryChannelDefinition>();
        }
        public TelemetryFile(string fileName) : this()
        {
            FileName = fileName;
            try
            {
                var fileTitle = Path.GetFileNameWithoutExtension(FileName);
                var dt = fileTitle.Substring(fileTitle.Length - 19);
                Timestamp = DateTime.ParseExact(dt, "yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
            }
            catch
            {
            }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return FieldsToString() + Environment.NewLine + ValuesToString();
        }
        public string ValuesToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (TelemetryFrame tout in Frames)
            {
                foreach (TelemetryChannelValue tfv in tout.ChannelValues)
                {
                    sb.AppendFormat("{0}: {1} [{2}] ", tfv.Definition.Name, tfv.ByteString, tfv.Value);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public string FieldsToString()
        {
            StringBuilder sb = new StringBuilder();
            int fieldIdx = 0;
            foreach (TelemetryChannelDefinition field in Channels)
            {
                sb.AppendFormat("{0,-3}) {1,-32} {2,-64} {3,-32} {4,-4} {5,-4}", fieldIdx.ToString(), field.Name, field.Description, field.Unit, field.DataType.ToString(), field.Position.ToString());
                sb.AppendLine();
                fieldIdx++;
            }
            return sb.ToString();
        }
        #endregion
    }
}