using System;
using TrackSessionLibrary.Views;

namespace TrackSessionLibrary
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
