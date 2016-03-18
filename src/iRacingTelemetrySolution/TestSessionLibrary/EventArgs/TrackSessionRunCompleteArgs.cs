using System;
using iRacing.TrackSession.Views;

namespace iRacing.TrackSession
{
    public class TrackSessionRunCompleteArgs : EventArgs
    {
        public TrackSessionRunView Run { get; set; }
        public TrackSessionRunCompleteArgs(TrackSessionRunView model)
        {
            Run = model;
        }
        public TrackSessionRunCompleteArgs()
        {

        }
    }
}
