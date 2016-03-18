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
            int currentLapIdx = -1;
            foreach (var frame in telemetryData.Frames.OrderBy(f => f.FrameIndex))
            {
                var lapBuffer = frame.GetValue(TelemetryConstants.LapKey);
                var lapNum = Convert.ToInt32(lapBuffer);
                if (lapNum > currentLapIdx)
                {
                    currentLap = new TelemetryLap(lapNum);
                    telemetryLaps.Add(currentLap);
                    currentLapIdx = lapNum;
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
