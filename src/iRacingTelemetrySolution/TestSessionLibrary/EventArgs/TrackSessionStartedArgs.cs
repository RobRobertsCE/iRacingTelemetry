using System;

namespace iRacing.TrackSession
{
    public class TrackSessionStartedArgs : EventArgs
    {
        public Guid TrackSessionId { get; set; }

        public TrackSessionStartedArgs(Guid id)
        {
            TrackSessionId = id;
        }
        public TrackSessionStartedArgs()
        {

        }
    }
}
