using iRacing;
using System;
using System.Diagnostics;
using System.Management;

namespace TestSessionLibrary
{
    internal class EngineProcessMonitor : IDisposable
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
        public string ProcessName { get; set; }
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
        }

        public EngineProcessMonitor(string processName) : this()
        {
            this.ProcessName = processName;
        }
        #endregion

        #region Public Methods
        public void Start()
        {
            if (String.IsNullOrEmpty(ProcessName))
                throw new ArgumentException("ProcessName");

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
            ManagementEventWatcher stopWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            stopWatch.EventArrived += StopWatch_EventArrived;
            startWatch.Start();
            stopWatch.Start();
            WriteLog("ProcessMonitor Started");
            if (IsProcessRunning())
                OnProcessStarted();
        }

        protected virtual bool IsProcessRunning()
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            //Process[] processes = Process.GetProcesses();
            //foreach (var proc in processes)
            //{
            //    if (proc.ProcessName.StartsWith("iRacing"))
            //        Console.WriteLine(proc.ProcessName);
            //}
            return (processes.Length > 0);
        }

        protected virtual void StopMonitor()
        {
            if (!IsMonitoring) return;
            DisposeWatchers();
            WriteLog("ProcessMonitor Stopped");
        }

        protected virtual void StopWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            //Console.WriteLine("Process stopped: {0}", e.NewEvent.Properties["ProcessName"].Value);
            if (e.NewEvent.Properties["ProcessName"].Value.ToString().Contains(ProcessName))
                OnProcessStopped();
        }

        protected virtual void StartWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            //Console.WriteLine("Process started: {0}", e.NewEvent.Properties["ProcessName"].Value);
            if (e.NewEvent.Properties["ProcessName"].Value.ToString().Contains(ProcessName))
                OnProcessStarted();
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

        #region IDisposable
        public void Dispose()
        {
            DisposeWatchers();
        }
        private void DisposeWatchers()
        {
            try
            {
                if (null != startWatch)
                {
                    startWatch.Stop();
                    startWatch.Dispose();
                }
                if (null != stopWatch)
                {
                    stopWatch.Stop();
                    stopWatch.Dispose();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
            }
        }
        #endregion
    }
}
