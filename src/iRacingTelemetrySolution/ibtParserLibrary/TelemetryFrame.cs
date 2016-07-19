using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace iRacing.TelemetryParser
{
    public class TelemetryFrame : ITelemetryFrame
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
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name.ToUpper() == key.ToUpper());
            return returnValue.Value;
        }

        public Single GetSingleValue(string key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name.ToUpper() == key.ToUpper());
            return Convert.ToSingle(returnValue.Value);
        }

        public int GetIntValue(string key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name.ToUpper() == key.ToUpper());
            return Convert.ToInt32(returnValue.Value);
        }


        // TelemetryKeys
        public string GetValue(TelemetryKeys key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name.ToUpper() == key.ToString().ToUpper());
            if (null == returnValue)
                return String.Empty;
            else
                return returnValue.Value;
        }

        public Single GetSingleValue(TelemetryKeys key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name.ToUpper() == key.ToString().ToUpper());
            if (null == returnValue)
                return (Single)GetIntValue(key);
            else
                return Convert.ToSingle(returnValue.Value);
        }

        public int GetIntValue(TelemetryKeys key)
        {
            var returnValue = ChannelValues.FirstOrDefault(v => v.Definition.Name.ToUpper() == key.ToString().ToUpper());
            if (null == returnValue)
                return -9999;
            else
                return Convert.ToInt32(returnValue.Value);
        }
    }
}
