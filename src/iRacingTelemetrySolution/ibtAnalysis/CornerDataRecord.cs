using System;

namespace iRacing.TelemetryAnalysis.Shocks
{
    public class CornerDataRecord
    {
        public int Idx { get; set; }
        public int Lap { get; set; }
        public float LapDistance { get; set; }
        public float LapDistancePercent { get; set; }

        public Single LF { get; set; }
        public Single LR { get; set; }
        public Single RF { get; set; }
        public Single RR { get; set; }

        public Single GetCorner(Corner corner)
        {
            switch (corner)
            {
                case Corner.LF:
                    {
                        return LF;
                    }
                case Corner.LR:
                    {
                        return LR;
                    }
                case Corner.RF:
                    {
                        return RF;
                    }
                case Corner.RR:
                    {
                        return RR;
                    }
            }
            return -1;
        }
    }
}
