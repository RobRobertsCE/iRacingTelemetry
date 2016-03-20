using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.TelemetryParser
{
    public class TelemetryLapList : List<TelemetryLap>
    {
        public IDictionary<int, float> GetLapTimes()
        {
            var lapTimes = new Dictionary<int, float>();

            return lapTimes;
        }
    }
}
