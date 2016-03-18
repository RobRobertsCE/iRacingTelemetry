using iRacing.TelemetryParser;
using iRacing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using iRacing.TelemetryParser.Extensions;

namespace iRacing.TelemetryAnalysis.Laps
{
    public class LapTimeAnalysis
    {
        public double BestLapTime { get; set; }
        public double Average { get; private set; }
        public double Median { get; private set; }
        public double StdDev { get; private set; }
        public double Range { get; private set; }
        public IDictionary<float, int> FrequencyDistribution { get; private set; }
        public IList<Single> Dropoff { get; private set; }

        public IDictionary<int, float> Laps { get; private set; }
        public IDictionary<int, float> RawLaps { get; private set; }
        

        public LapTimeAnalysis(TelemetryLapList telemetryLaps)
        {
            RawLaps = telemetryLaps.LapTimesList();
            Laps = RawLaps.ValidLaps();

            if (Laps.Count > 0)
            {
                BestLapTime = Laps.Average();
                Average = Laps.Average();
                Median = Laps.Median();
                StdDev = Laps.StdDev();
                Range = Laps.Range();
                FrequencyDistribution = Laps.FrequencyDistribution();
                Dropoff = Laps.Dropoff();
            }
        }        
    }
}
