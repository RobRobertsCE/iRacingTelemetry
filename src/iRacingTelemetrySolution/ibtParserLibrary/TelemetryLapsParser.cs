using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.TelemetryParser
{
    public static class TelemetryLapsParser
    {
        public static IList<TelemetryLap> ParseLaps(TelemetryFile telemetryData)
        {
            IList<TelemetryLap> telemetryLaps = new List<TelemetryLap>();
            TelemetryLap currentLap = new TelemetryLap();
            int currentLapNumber = -1;
            int currentLapIdx = 0;
            foreach (var frame in telemetryData.Frames.OrderBy(f => f.FrameIndex))
            {
                var lapBuffer = frame.GetValue(TelemetryConstants.LapKey);
                var lapNum = Convert.ToInt32(lapBuffer);
                if (lapNum > currentLapNumber)
                {
                    currentLap = new TelemetryLap(lapNum, currentLapIdx);
                    telemetryLaps.Add(currentLap);
                    currentLapNumber = lapNum;
                    currentLapIdx++;
                }
                currentLap.Frames.Add(frame);
            }
            return telemetryLaps;
        }

        public static int GetLapCount(TelemetryFile telemetryData)
        {
            return telemetryData.Frames.Select(f=>f.GetIntValue(TelemetryKeys.Lap)).Distinct().Count();
        }

        public static KeyValuePair<int, float> GetBestLap(TelemetryFile telemetryData)
        {
            int bestLapNumber = -1;
            float bestLapTime = -1F;
            var lastFrame =  telemetryData.Frames.LastOrDefault();
            if (null!= lastFrame)
            {
                 bestLapNumber = (int)lastFrame.GetIntValue(TelemetryKeys.LapBestLap);
                 bestLapTime = (float)lastFrame.GetSingleValue(TelemetryKeys.LapBestLapTime);                
            }
            return new KeyValuePair<int, float>(bestLapNumber, bestLapTime);
        }
    }
}
