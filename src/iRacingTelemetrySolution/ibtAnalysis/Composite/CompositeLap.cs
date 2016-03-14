using ibtParserLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibtAnalysis.Composite
{
    public class CompositeLap
    {
        const TelemetryKeys DistPercentKey  = TelemetryKeys.LapDistPct;
        TelemetrySession _session;
        IList<SingleDistanceValue> _distanceValues;


        public TelemetryLap Lap { get; set; }

        public IList<TelemetryKeys> Keys { get; set; }


        public CompositeLap(TelemetrySession session)
        {
            _session = session;
            BuildCompositeLap();
        }

        void BuildCompositeLap()
        {
            _distanceValues = new List<SingleDistanceValue>();

            Lap = new TelemetryLap(0);

            foreach (var lap in _session.Laps)
            {                
                for (int frameIdx = 0; frameIdx < lap.FrameCount; frameIdx++)
                {                    
                    var frame = lap.Frames[frameIdx];
                    var frameDistancePercent = frame.GetSingleValue(DistPercentKey);
                    _distanceValues.Add(new SingleDistanceValue() { DistancePercent = frameDistancePercent, Key = DistPercentKey, Value = frameDistancePercent });

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
            public Single DistancePercent { get; set; }

            public TelemetryKeys Key { get; set; }

            public Single Value { get; set; }
        }
      
    }
}
