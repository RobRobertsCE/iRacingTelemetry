using System.Collections.Generic;

namespace iRacing.TelemetryParser
{
    public interface ITelemetryLap
    {
        int FrameCount { get; }
        IList<TelemetryFrame> Frames { get; set; }
        int LapIndex { get; set; }
        int LapNumber { get; set; }

        IEnumerable<string> Series(TelemetryKeys key);
        IEnumerable<string> Series(string key);
        IEnumerable<int> SeriesInt(TelemetryKeys key);
        IEnumerable<int> SeriesInt(string key);
        IEnumerable<float> SeriesSingle(TelemetryKeys key);
        IEnumerable<float> SeriesSingle(string key);
    }
}