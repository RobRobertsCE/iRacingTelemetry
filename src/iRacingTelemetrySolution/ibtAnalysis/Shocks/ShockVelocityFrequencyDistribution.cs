using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iRacing.TelemetryAnalysis.Shocks
{
    public class ShockVelocityFrequencyDistribution
    {
        public class MotionDirection
        {
            public Single Average { get; set; }
            public Single LowSpeed { get; set; }
            public Single HighSpeed { get; set; }
        }

        private const int DefaultResolution = 50;
        private const Single DefaultMin = -200F;
        private const Single DefaultMax = 200F;
        private const Single HighLowThreshold = 25F;
        // TODO: Convert M/S to MM/S ( * 1000 )

        private int[] distribution;
        private Single[] percentages;
        private Single[] rangeLabels;

        private IList<Single> _velocities;
        private Single _min;
        private Single _max;
        private int _reboundLowIdx;
        private int _compressionLowIdx;
        private int _zeroIdx;
        private int _resolution;

        public MotionDirection Bump { get; set; }
        public MotionDirection Rebound { get; set; }
        public Single ZeroBin { get; set; }

        public ShockVelocityFrequencyDistribution(IList<Single> velocities)
            : this(DefaultResolution, DefaultMin, DefaultMax, velocities)
        {

        }

        public ShockVelocityFrequencyDistribution(int resolution, Single min, Single max, IList<Single> velocities)
        {
            _velocities = velocities;
            _min = min;
            _max = max;
            _resolution = resolution;
            distribution = new int[resolution];
            percentages = new Single[resolution];
            rangeLabels = new float[resolution];

            Bump = new MotionDirection();
            Rebound = new MotionDirection();

            CalculateFrequencyDistribution();
        }

        void CalculateFrequencyDistribution()
        {
            _reboundLowIdx = -999;
            _zeroIdx = -999;
            _compressionLowIdx = -999;
            Single highReboundCount = 0;
            Single lowReboundCount = 0;
            Single lowCompressionCount = 0;
            Single highCompressionCount = 0;

            var count = (Single)_velocities.Count();
            var step = (_max - _min) / _resolution;
            for (int i = 0; i < _resolution; i++)
            {
                var rangeStart = (step * i) + _min;
                var rangeEnd = rangeStart + step;
                rangeLabels[i] = rangeStart;
                distribution[i] += _velocities.Where(v => v > rangeStart && v <= rangeEnd).Count();
                percentages[i] = (Single)distribution[i] / count;

                // record the starting and ending indexes of the low-speed range.
                // HighRebound-> [HighLowThreshold] ->LowRebound-> [0] <-LowCompression<- [HighLowThreshold] <-HighCompression
                if (rangeStart < (-1 * HighLowThreshold))
                {
                    // High Rebound
                    _reboundLowIdx = i;
                    highReboundCount += distribution[i];
                }
                else if (rangeStart > (-1 * HighLowThreshold) && rangeStart < 0)
                {
                    // Low Rebound
                    _zeroIdx = i;
                    lowReboundCount += distribution[i];
                }
                else if (rangeStart > 0 && rangeStart < HighLowThreshold)
                {
                    // Low Compression
                    _compressionLowIdx = i;
                    lowCompressionCount += distribution[i];
                }
                else if (rangeStart > HighLowThreshold)
                {
                    // High Compression
                    highCompressionCount += distribution[i];
                }
            }

            // Summaries
            ZeroBin = (distribution[_zeroIdx] + distribution[_zeroIdx + 1]) / count;

            Bump.LowSpeed = lowReboundCount / count;
            Bump.HighSpeed = highReboundCount / count;
            Bump.Average = (lowReboundCount + highReboundCount) / (_resolution / 2); ;

            Rebound.LowSpeed = lowCompressionCount / count;
            Rebound.HighSpeed = highCompressionCount / count;
            Rebound.Average = (lowCompressionCount + highCompressionCount) / (_resolution / 2); ; ;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var step = (_max - _min) / _resolution;
            for (int i = 0; i < _resolution; i++)
            {
                var rangeStart = (step * i) + _min;
                if (rangeStart > -.1F && rangeStart < .1F)
                    sb.Append("0         ");
                else
                    sb.AppendFormat("{0,-9} ", rangeStart.ToString("+#.00;-#.00;0"));
            }
            sb.AppendLine();
            for (int i = 0; i < _resolution; i++)
            {
                sb.AppendFormat("{0,-9} ", distribution[i]);
            }
            sb.AppendLine();
            for (int i = 0; i < _resolution; i++)
            {
                sb.AppendFormat("{0,-9:P} ", percentages[i]);
            }
            sb.AppendLine();
            sb.AppendLine("-------------------------------------------");
            sb.AppendFormat("ZeroBin: {0:P}\r\n", ZeroBin);
            sb.AppendFormat("Rebound Average: {0:#.####} | Compress Average: {0:#.####} \r\n", Rebound.Average, Bump.Average);
            sb.AppendFormat("Rebound High: {0:P} Rebound Low: {1:P} | Compress Low: {2:P} Compress High {3:P}\r\n", Rebound.HighSpeed, Rebound.LowSpeed, Bump.LowSpeed, Bump.HighSpeed);

            return sb.ToString();
        }

        public string ToCSVString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _resolution - 1; i++)
            {
                sb.AppendFormat("{0,-5}, ", distribution[i]);
            }
            sb.AppendFormat("{0,-5}", distribution[_resolution - 1]);
            return sb.ToString();
        }
    }

}
