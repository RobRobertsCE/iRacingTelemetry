using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.TelemetryParser.Extensions
{
    public static class TelemetryLapExtensions
    {
        public static IDictionary<int, Single> LapTimesList(this TelemetryLapList telemetryLaps)
        {
            var laps = new Dictionary<int, Single>();
            foreach (TelemetryLap lap in telemetryLaps)
            {
                var lastLapTime = lap.SeriesSingle(TelemetryKeys.LapLastLapTime).LastOrDefault();
                var lapNumber = lap.LapNumber;
                //Console.WriteLine("{0} {1}", lapNumber, lastLapTime);
                if (lapNumber > 1)
                {
                    if (laps.ContainsKey(lapNumber - 1))
                    {
                        laps[lapNumber - 1] = lastLapTime;
                        //Console.WriteLine("Setting Lap {0} to {1}", lapNumber - 1, lastLapTime);
                    }
                    else
                    {
                        laps.Add(lapNumber - 1, lastLapTime);
                        //Console.WriteLine("Adding Lap {0} as {1}", lapNumber - 1, lastLapTime);
                    }
                }
            }
            return laps;
        }
    }
}
