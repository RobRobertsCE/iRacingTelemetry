using System;
using System.Collections.Generic;
namespace TestSessionLibrary
{
    public class EngineExceptionArgs : EventArgs
    {
        public Exception Exception { get; set; }

        public EngineExceptionArgs()
        {

        }
        public EngineExceptionArgs(Exception ex)
        {
            Exception = ex;
        }
    }
}
