using System;
using System.Collections.Generic;
using System.Linq;

namespace ibtParserLibrary
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
    }
}
