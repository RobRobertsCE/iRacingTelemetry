using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryViewer.Business
{
    public class WorkspaceMappings
    {
        public IList<MappedChannel> MappedChannels { get; set; }

        public class MappedChannel
        {
            public MappingSource Source { get; set; }
            public MappingTarget Target { get; set; }
        }

        public class MappingSource
        {
            public string Name { get; set; }
        }

        public class MappingTarget
        {
            public string Name { get; set; }
        }
    }
}
