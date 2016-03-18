using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iRacing.TelemetryAnalysis.Shocks
{
    public class ShockAnalysis
    {
        public IList<ShockDeflection> Deflections { get; set; }
        public IList<RideHeight> RideHeights { get; set; }
        public IList<CornerDataRecord> Velocities { get; set; }

        public IEnumerable<Single> LFVelocity
        {
            get
            {
                return Velocities.Select(v => v.LF);
            }
        }
        public IEnumerable<Single> LRVelocity
        {
            get
            {
                return Velocities.Select(v => v.LR);
            }
        }
        public IEnumerable<Single> RFVelocity
        {
            get
            {
                return Velocities.Select(v => v.RF);
            }
        }
        public IEnumerable<Single> RRVelocity
        {
            get
            {
                return Velocities.Select(v => v.RR);
            }
        }

        public IEnumerable<Single> LFRideHeight
        {
            get
            {
                return RideHeights.Select(v => v.LF);
            }
        }
        public IEnumerable<Single> LRRideHeight
        {
            get
            {
                return RideHeights.Select(v => v.LR);
            }
        }
        public IEnumerable<Single> RFRideHeight
        {
            get
            {
                return RideHeights.Select(v => v.RF);
            }
        }
        public IEnumerable<Single> RRRideHeight
        {
            get
            {
                return RideHeights.Select(v => v.RR);
            }
        }

        public IEnumerable<Single> LFDeflection
        {
            get
            {
                return Deflections.Select(v => v.LF);
            }
        }
        public IEnumerable<Single> LRDeflection
        {
            get
            {
                return Deflections.Select(v => v.LR);
            }
        }
        public IEnumerable<Single> RFDeflection
        {
            get
            {
                return Deflections.Select(v => v.RF);
            }
        }
        public IEnumerable<Single> RRDeflection
        {
            get
            {
                return Deflections.Select(v => v.RR);
            }
        }

        public IEnumerable<Single> CornerVelocities(Corner corner)
        {
            switch (corner)
            {
                case Corner.LF:
                    {
                        return LFVelocity;
                    }
                case Corner.LR:
                    {
                        return LRVelocity;
                    }
                case Corner.RF:
                    {
                        return RFVelocity;
                    }
                case Corner.RR:
                    {
                        return RRVelocity;
                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }
        public IEnumerable<Single> CornerRideHeights(Corner corner)
        {
            switch (corner)
            {
                case Corner.LF:
                    {
                        return LFRideHeight;
                    }
                case Corner.LR:
                    {
                        return LRRideHeight;
                    }
                case Corner.RF:
                    {
                        return RFRideHeight;
                    }
                case Corner.RR:
                    {
                        return RRRideHeight;
                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }
        public IEnumerable<Single> CornerDeflection(Corner corner)
        {
            switch (corner)
            {
                case Corner.LF:
                    {
                        return LFDeflection;
                    }
                case Corner.LR:
                    {
                        return LRDeflection;
                    }
                case Corner.RF:
                    {
                        return RFDeflection;
                    }
                case Corner.RR:
                    {
                        return RRDeflection;
                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }

        public Single MaxVelocity(Corner corner)
        {
            return CornerVelocities(corner).Max();
        }
        public Single MinVelocity(Corner corner)
        {
            return CornerVelocities(corner).Min();
        }
        public Single AverageVelocity(Corner corner)
        {
            return CornerVelocities(corner).Average();
        }

        public ShockAnalysis()
        {
            Velocities = new List<CornerDataRecord>();
            RideHeights = new List<RideHeight>();
            Deflections = new List<ShockDeflection>();
        }

        public string PerformDeflectionAnalysis()
        {
            /* calculate */
            int sampleCount = Deflections.Count;
            Single[,] contactAnalysis = new Single[sampleCount, sampleCount];
            for (int i = 0; i < sampleCount; i++)
            {
                contactAnalysis[i, 0] = CornerDeflection(Corner.LF).ElementAtOrDefault(i);
                contactAnalysis[i, 1] = CornerRideHeights(Corner.LF).ElementAtOrDefault(i);
            }

            /* create report */
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sampleCount; i++)
            {
                sb.AppendFormat("{0},{1}\r\n", contactAnalysis[i, 0], contactAnalysis[i, 1]);
            }
            return sb.ToString();
        }

        public string PerformVelocityAnalysis()
        {
            /* calculate */
            Single[] min = new Single[4];
            Single[] max = new Single[4];
            Single[] avgComp = new Single[4];
            Single[] avgReb = new Single[4];
            for (int i = 0; i < 4; i++)
            {
                min[i] = MinVelocity((Corner)i);
                max[i] = MaxVelocity((Corner)i);
                avgComp[i] = CornerVelocities((Corner)i).Where(v => v > 0).Average();
                avgReb[i] = CornerVelocities((Corner)i).Where(v => v <= 0).Average();
            }

            /* create report */
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   Min               Max              Range          Avg Comp            Avg Reb");
            for (int i = 0; i < 4; i++)
            {
                sb.AppendFormat("{5} {0,-12}      {1,-12}     {2,-12}   {3,-12}        {4,-12}\r\n", min[i], max[i], max[i] - min[i], avgComp[i], avgReb[i], ((Corner)i).ToString());
            }
            sb.AppendLine();
            sb.AppendLine();
            for (int i = 0; i < 4; i++)
            {
                var v = CornerVelocities((Corner)i).ToList();
                var d = new ShockVelocityFrequencyDistribution(v);
                sb.AppendLine(d.ToString());
            }
            return sb.ToString();
        }
        
        public override string ToString()
        {
            var csv = new StringBuilder();
            csv.AppendFormat("{0}, {1}, {2}, {3}, {4}", "IDX", "LF", "LR", "RF", "RR");
            csv.AppendLine();
            foreach (var frame in Velocities)
            {
                csv.AppendFormat("{0}, {1:N}, {2:N}, {3:N}, {4:N}", frame.Idx, frame.LF, frame.LR, frame.RF, frame.RR);
                csv.AppendLine();
            }
            return csv.ToString();
        }
    }
}
