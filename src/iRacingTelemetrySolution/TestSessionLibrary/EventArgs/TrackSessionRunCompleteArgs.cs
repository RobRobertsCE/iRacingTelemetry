using System;
using TestSessionLibrary.Views;

namespace TestSessionLibrary
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
