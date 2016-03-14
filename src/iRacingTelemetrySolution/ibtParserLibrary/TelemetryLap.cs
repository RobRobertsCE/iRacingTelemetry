using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ibtParserLibrary
{
    public class TelemetryLap
    {
        public int LapNumber { get; set; }

        public int FrameCount {  get { return Frames.Count(); } }

        [Browsable(false)]
        public IList<TelemetryFrame> Frames { get; set; }

        public TelemetryLap()
        {
            Frames = new List<TelemetryFrame>();
        }
        public TelemetryLap(int lapNumber) : this()
        {
            LapNumber = lapNumber;
        }

        public IEnumerable<float> SeriesSingle(TelemetryKeys key)
        {
            return Frames.Select(f => f.GetSingleValue(key));
        }
        public IEnumerable<float> SeriesSingle(string key)
        {
            return Frames.Select(f => f.GetSingleValue(key));
        }
        public IEnumerable<int> SeriesInt(TelemetryKeys key)
        {
            return Frames.Select(f => f.GetIntValue(key));
        }
        public IEnumerable<int> SeriesInt(string key)
        {
            return Frames.Select(f => f.GetIntValue(key));
        }
        public IEnumerable<string> Series(TelemetryKeys key)
        {
            return Frames.Select(f => f.GetValue(key));
        }
        public IEnumerable<string> Series(string key)
        {
            return Frames.Select(f => f.GetValue(key));
        }
    }
}
