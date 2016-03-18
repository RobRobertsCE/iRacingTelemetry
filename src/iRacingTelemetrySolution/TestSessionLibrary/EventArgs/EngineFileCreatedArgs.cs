﻿using System;

namespace TrackSessionLibrary
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
