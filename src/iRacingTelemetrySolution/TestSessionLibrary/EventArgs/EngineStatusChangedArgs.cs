using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackSessionLibrary
{
    public class EngineStatusChangedArgs : EventArgs
    {
        public EngineStatus OldStatus { get; set; }
        public EngineStatus NewStatus { get; set; }

        public EngineStatusChangedArgs()
        {

        }

        public EngineStatusChangedArgs(EngineStatus oldStatus, EngineStatus newStatus)
        {
            this.OldStatus = oldStatus;
            this.NewStatus = newStatus;
        }
    }
}
