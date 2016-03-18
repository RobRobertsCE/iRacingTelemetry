using iRacing.TelemetryParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.TelemetryAnalysis.Composite
{
    public class CompositeLap
    {
        const TelemetryKeys DistPercentKey  = TelemetryKeys.LapDistPct;
        TelemetryFile _telemetryData;
        IList<SingleDistanceValue> _distanceValues;

        public TelemetryLap Lap { get; set; }

        public IList<TelemetryKeys> Keys { get; set; }

        public CompositeLap(TelemetryFile telemetryData)
        {
            _telemetryData = telemetryData;
            BuildCompositeLap();
        }

        void BuildCompositeLap()
        {
            _distanceValues = new List<SingleDistanceValue>();

            Lap = new TelemetryLap(0);
            var sessionLaps = TelemetryLapsParser.ParseLaps(_telemetryData);
            foreach (var lap in sessionLaps)
            {                
                for (int frameIdx = 0; frameIdx < lap.FrameCount; frameIdx++)
                {                    
                    var frame = lap.Frames[frameIdx];
                    var frameDistancePercent = frame.GetSingleValue(DistPercentKey);
                    var frameTicks = frame.GetSingleValue(TelemetryKeys.SessionTime);
                    _distanceValues.Add(new SingleDistanceValue() { DistancePercent = frameDistancePercent, Key = DistPercentKey, Value = frameDistancePercent, Ticks = frameTicks });

                    foreach (TelemetryKeys key in Keys)
                    {
                        var telemValue = frame.GetSingleValue(key);
                        _distanceValues.Add(new SingleDistanceValue() { DistancePercent = frameDistancePercent, Key = key, Value = telemValue });
                    }
                }
            }
            Console.WriteLine("# of records: {0}", _distanceValues.Count);
            foreach (SingleDistanceValue item in _distanceValues.Where(x=>x.Key == TelemetryKeys.LapDistPct).OrderBy(x=>x.DistancePercent))
            {
                Console.WriteLine("{0}", item.DistancePercent);
            }
        }

        public class SingleDistanceValue
        {
            public Single Ticks { get; set; }

            public Single DistancePercent { get; set; }

            public TelemetryKeys Key { get; set; }

            public Single Value { get; set; }
        }
      
    }
}
