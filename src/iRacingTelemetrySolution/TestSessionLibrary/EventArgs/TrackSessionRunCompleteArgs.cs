using System;

namespace iRacing.TrackSession
{
    public class TrackSessionRunCompleteArgs : EventArgs
    {
        public Guid TrackSessionRunId { get; set; }

        public TrackSessionRunCompleteArgs(Guid id)
        {
            TrackSessionRunId = id;
        }
        public TrackSessionRunCompleteArgs()
        {

        }
    }
}
