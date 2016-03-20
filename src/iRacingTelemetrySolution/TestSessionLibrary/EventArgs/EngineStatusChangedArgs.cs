using iRacing.TrackSession.Engine;
using System;

namespace iRacing.TrackSession
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
