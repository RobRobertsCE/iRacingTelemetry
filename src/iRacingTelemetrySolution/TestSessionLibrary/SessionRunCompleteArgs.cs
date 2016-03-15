using System;
using TestSessionLibrary.Views;

namespace TestSessionLibrary
{
    public class SessionRunCompleteArgs : EventArgs
    {
        public TrackSessionRunView Run { get; set; }
        public SessionRunCompleteArgs(TrackSessionRunView model)
        {
            Run = model;
        }
        public SessionRunCompleteArgs()
        {

        }
    }
}
