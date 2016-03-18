using System;
using TrackSessionLibrary.Views;

namespace TrackSessionLibrary
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
