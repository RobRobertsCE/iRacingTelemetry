using System;
using iRacing.TrackSession.Views;

namespace iRacing.TrackSession
{
    public class TrackSessionStartedArgs : EventArgs
    {
        public TrackSessionView Session { get; set; }
        public TrackSessionStartedArgs(TrackSessionView model)
        {
            Session = model;
        }
        public TrackSessionStartedArgs()
        {

        }
    }
}
