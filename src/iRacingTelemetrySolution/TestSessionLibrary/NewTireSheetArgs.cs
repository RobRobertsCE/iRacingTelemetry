using iRacing.SetupLibrary.Tires;
using System;

namespace TestSessionLibrary
{
    public class NewTireSheetArgs : EventArgs
    {
        public TireSheet TireSheet { get; set; }

        public NewTireSheetArgs()
        {

        }
        public NewTireSheetArgs(TireSheet newTireSheet)
        {
            TireSheet = newTireSheet;
        }
    }
}