using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.TelemetryParser
{
    public class TelemetryChannelDefinition : ITelemetryChannelDefinition
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public Int32 DataType { get; set; }
        public int Size
        {
            get
            {
                if (DataType == 1) // 1 = bool
                    return 1;
                else if (DataType == 2) // 2 = int?
                    return 4;
                else if (DataType == 3) // 3 = irsdk_EngineWarnings only
                    return 4;
                else if (DataType == 4) // 4 = float?
                    return 4;
                else if (DataType == 5) // 5 = float?
                    return 8;
                else
                    return 0;
            }
        }
        public Int32 Position { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Description);
        }
    }
}
