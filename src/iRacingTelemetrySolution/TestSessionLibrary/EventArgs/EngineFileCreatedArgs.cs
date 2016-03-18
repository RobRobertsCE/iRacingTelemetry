using System;

namespace iRacing.TrackSession
{
    public class EngineFileCreatedArgs : EventArgs
    {
        public string FullPath { get; set; }

        public EngineFileCreatedArgs()
        {

        }
        public EngineFileCreatedArgs(string filePath)
        {
            FullPath = filePath;
        }
    }
}
