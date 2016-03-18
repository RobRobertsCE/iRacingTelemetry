using System;

namespace TrackSessionLibrary
{
    public class ManagerStatusChangedArgs : EventArgs
    {
        public ManagerStatus OldStatus { get; set; }
        public ManagerStatus NewStatus { get; set; }

        public ManagerStatusChangedArgs()
        {

        }

        public ManagerStatusChangedArgs(ManagerStatus oldStatus, ManagerStatus newStatus)
        {
            this.OldStatus = oldStatus;
            this.NewStatus = newStatus;
        }
    }
}
