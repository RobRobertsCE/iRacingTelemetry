using System.Collections.Generic;

namespace iRacing.TelemetryParser
{
    public interface ITelemetryFrame
    {
        IList<TelemetryChannelValue> ChannelValues { get; set; }
        int FrameIndex { get; set; }

        int GetIntValue(TelemetryKeys key);
        int GetIntValue(string key);
        float GetSingleValue(TelemetryKeys key);
        float GetSingleValue(string key);
        string GetValue(TelemetryKeys key);
        string GetValue(string key);
    }
}