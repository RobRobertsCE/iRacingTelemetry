using System;
using TestSessionLibrary.Views;

namespace TestSessionLibrary
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
