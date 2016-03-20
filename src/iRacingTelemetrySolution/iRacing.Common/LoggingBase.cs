using System;

namespace iRacing
{
    public class LoggingBase
    {
        #region properties
        public bool EnableLogging { get; set; }
        #endregion

        #region ctor
        protected LoggingBase(bool loggingOn)
        {
            EnableLogging = loggingOn;
        }
        #endregion

        #region exception handling
        protected virtual void ExceptionHandler(Exception ex)
        {
            WriteErrorLog(ex);
        }
        #endregion

        #region logging
        protected virtual void WriteLog(string format, params object[] args)
        {
            WriteLog(String.Format(format, args));
        }
        protected virtual void WriteLog(string message)
        {
            if (EnableLogging)
            {
                Logger.Log.Info(message);
            }
        }
        protected virtual void WriteWarnLog(string message)
        {
            Logger.Log.Warn(message);
        }
        protected virtual void WriteDebugLog(string message)
        {
            Logger.Log.Debug(message);
        }
        protected virtual void WriteInfoLog(string message)
        {
            Logger.Log.Info(message);
        }
        protected virtual void WriteErrorLog(Exception ex)
        {
            Logger.Log.Error(ex);
        } 
        #endregion
    }
}
