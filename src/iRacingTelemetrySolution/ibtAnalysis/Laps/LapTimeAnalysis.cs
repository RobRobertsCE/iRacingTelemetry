using ibtParserLibrary;
using iRacing.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ibtAnalysis.Laps
{
    public class LapTimeAnalysis
    {
        public float Average { get; set; }
        public double Median { get; set; }
        public double StdDev { get; set; }
        public double Range { get; set; }
        public IDictionary<float, int> FrequencyDistribution { get; set; }
        public IList<Single> Dropoff { get; set; }

        public IDictionary<int, float> LapTimesList { get; set; }
        public IList<float> LapTimes { get; set; }
        public IList<float> CoreLapTimes { get; set; }

        public LapTimeAnalysis(IList<TelemetryLap> telemetryLaps)
        {
            LapTimesList = ParseLapTimes(telemetryLaps);
            LapTimes = LapTimesList.Values.ToList();
            CoreLapTimes = LapTimes.CoreLaps();

            Average = CoreLapTimes.Average();
            Median = CoreLapTimes.Median();
            StdDev = CoreLapTimes.StdDev();
            Range = CoreLapTimes.Range();
            FrequencyDistribution = CoreLapTimes.FrequencyDistribution();
            Dropoff = CoreLapTimes.Dropoff();
        }

        public static IDictionary<int, Single> ParseLapTimes(IList<TelemetryLap> telemetryLaps)
        {
            var laps = new Dictionary<int, Single>();
            foreach (TelemetryLap lap in telemetryLaps)
            {
                var lastLapTime = lap.SeriesSingle(TelemetryKeys.LapLastLapTime).LastOrDefault();
                var lapNumber = lap.LapNumber;
                Console.WriteLine("{0} {1}", lapNumber, lastLapTime);
                if (lapNumber > 1)
                {
                    if (laps.ContainsKey(lapNumber - 1))
                    {
                        laps[lapNumber - 1] = lastLapTime;
                        Console.WriteLine("Setting Lap {0} to {1}", lapNumber - 1, lastLapTime);
                    }
                    else
                    {
                        laps.Add(lapNumber - 1, lastLapTime);
                        Console.WriteLine("Adding Lap {0} as {1}", lapNumber - 1, lastLapTime);
                    }
                }
            }
            return laps;
        }
    }
}
