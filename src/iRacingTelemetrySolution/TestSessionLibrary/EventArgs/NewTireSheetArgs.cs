using iRacing.SetupLibrary.Tires;
using System;

namespace iRacing.TrackSession
{
    public class NewTireSheetArgs : EventArgs
    {
        public Guid? TrackSessionRunId { get; set; }
        public TireSheet TireSheet { get; set; }

        public NewTireSheetArgs()
        {

        }
        public NewTireSheetArgs(TireSheet newTireSheet):this(newTireSheet, null)
        {
        }
        public NewTireSheetArgs(TireSheet newTireSheet, Guid? trackSessionRunid)
        {
            TireSheet = newTireSheet;
            TrackSessionRunId = trackSessionRunid;
        }
    }
}