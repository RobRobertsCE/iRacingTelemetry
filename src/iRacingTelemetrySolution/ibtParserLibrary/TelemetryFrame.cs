using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace ibtParserLibrary
{
    public class TelemetryFrame
    {
        public int FrameIndex { get; set; }

        [Browsable(false)]
        public IList<TelemetryChannelValue> ChannelValues { get; set; }

        public TelemetryFrame()
        {
            ChannelValues = new List<TelemetryChannelValue>();
        }

        public TelemetryFrame(int frameIdx) : this()
        {
            FrameIndex = frameIdx;
        }

        public string GetValue(string key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name == key);
            return returnValue.Value;
        }

        public Single GetSingleValue(string key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name == key);
            return Convert.ToSingle(returnValue.Value);
        }

        public int GetIntValue(string key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name == key);
            return Convert.ToInt32(returnValue.Value);
        }


        // TelemetryKeys
        public string GetValue(TelemetryKeys key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name == key.ToString());
            if (null == returnValue)
                return String.Empty;
            else
                return returnValue.Value;
        }

        public Single GetSingleValue(TelemetryKeys key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name == key.ToString());
            if (null == returnValue)
                return (Single)GetIntValue(key);
            else
                return Convert.ToSingle(returnValue.Value);
        }

        public int GetIntValue(TelemetryKeys key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name == key.ToString());
            if (null == returnValue)
                return -9999;
            else
                return Convert.ToInt32(returnValue.Value);
        }
    }
}
