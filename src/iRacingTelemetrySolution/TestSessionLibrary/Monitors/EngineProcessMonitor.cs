using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace iRacing.TrackSession.Monitors
{
    internal class EngineProcessMonitor
    {
        #region Events
        public event EventHandler ProcessStarted;
        protected virtual void OnProcessStarted()
        {
            EventHandler handler = ProcessStarted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
                WriteLog("OnProcessStarted");
            }
        }

        public event EventHandler ProcessStopped;
        protected virtual void OnProcessStopped()
        {
            EventHandler handler = ProcessStopped;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
                WriteLog("OnProcessStopped");
            }
        }
        #endregion

        #region Fields
        ManagementEventWatcher startWatch;
        ManagementEventWatcher stopWatch;
        #endregion

        #region Properties
        public List<string> ProcessNames { get; set; }
        public bool EnableLogging { get; set; }
        private bool _isMonitoring = false;
        public bool IsMonitoring
        {
            get
            {
                return _isMonitoring;
            }
        }
        #endregion

        #region Ctor
        public EngineProcessMonitor()
        {
            EnableLogging = true;
            ProcessNames = new List<string>();
        }

        public EngineProcessMonitor(string processName) : this()
        {
            ProcessNames.Add(processName);
        }
        public EngineProcessMonitor(IList<string> processNames) : this()
        {
            ProcessNames.AddRange(processNames);
        }
        #endregion

        #region Public Methods
        public void Start()
        {
            StartMonitor();
        }
        public void Stop()
        {
            StopMonitor();
        }
        #endregion

        #region Protected Virtual Methods
        protected virtual void StartMonitor()
        {
            if (IsMonitoring) return;
            startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            startWatch.EventArrived += StartWatch_EventArrived;
            stopWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            stopWatch.EventArrived += StopWatch_EventArrived;
            startWatch.Start();
            stopWatch.Start();
            WriteLog("ProcessMonitor Started");
            if (IsProcessRunning())
                OnProcessStarted();
        }
        protected virtual void StopMonitor()
        {
            if (!IsMonitoring) return;
            startWatch.Stop();
            startWatch.Dispose();
            startWatch = null;
            WriteLog("ProcessMonitor Stopped");
        }

        protected virtual bool IsProcessRunning()
        {
            foreach (var processName in ProcessNames)
            {
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length > 0)
                    return true;
            }
            return false;
        }

        protected virtual void StopWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            foreach (var processName in ProcessNames)
            {
                if (e.NewEvent.Properties["ProcessName"].Value.ToString().Contains(processName))
                    OnProcessStopped();
            }
        }
        protected virtual void StartWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            foreach (var processName in ProcessNames)
            {
                if (e.NewEvent.Properties["ProcessName"].Value.ToString().Contains(processName))
                    OnProcessStarted();
            }
        }

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
        protected virtual void WriteErrorLog(Exception ex)
        {
            Logger.Log.Error(ex);
        }
        #endregion        
    }
}
