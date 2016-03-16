using iRacing;
using System;
using System.IO;
using System.Threading;

namespace TestSessionLibrary
{
    internal class TrackSessionEngine : IDisposable
    {
        #region events   
        public event EventHandler<EngineFileCreatedArgs> TelemetryFileOpened;
        protected virtual void OnTelemetryFileOpened(string fullFilePath)
        {
            EventHandler<EngineFileCreatedArgs> handler = TelemetryFileOpened;
            if (handler != null)
            {
                var e = new EngineFileCreatedArgs(fullFilePath);
                handler(this, e);
                WriteLog("OnTelemetryFileOpened: {0}", fullFilePath);
            }
        }

        public event EventHandler<EngineFileCreatedArgs> TelemetryFileClosed;
        protected virtual void OnTelemetryFileClosed(string fullFilePath)
        {
            EventHandler<EngineFileCreatedArgs> handler = TelemetryFileClosed;
            if (handler != null)
            {
                var e = new EngineFileCreatedArgs(fullFilePath);
                handler(this, e);
                WriteLog("OnTelemetryFileClosed: {0}", fullFilePath);
            }
        }

        public event EventHandler<EngineFileCreatedArgs> SetupFileExported;
        protected virtual void OnSetupFileExported(string fullFilePath)
        {
            EventHandler<EngineFileCreatedArgs> handler = SetupFileExported;
            if (handler != null)
            {
                Thread.Sleep(1000);
                var e = new EngineFileCreatedArgs(fullFilePath);
                handler(this, e);
                WriteLog("OnSetupFileExported: {0}", fullFilePath);
            }
        }

        public event EventHandler<EngineExceptionArgs> EngineException;
        protected virtual void OnEngineException(Exception ex)
        {
            EventHandler<EngineExceptionArgs> handler = EngineException;
            if (handler != null)
            {
                var e = new EngineExceptionArgs(ex);
                handler(this, e);
                WriteLog("OnEngineException:  {0}", ex.Message);
            }
        }

        public event EventHandler<EngineStatusChangedArgs> EngineStatusChanged;
        protected virtual void OnEngineStatusChanged(EngineStatus oldStatus, EngineStatus newStatus)
        {
            EventHandler<EngineStatusChangedArgs> handler = EngineStatusChanged;
            if (handler != null)
            {
                var e = new EngineStatusChangedArgs(oldStatus, newStatus);
                handler(this, e);
                WriteLog("OnEngineStatusChanged:  {0}->{1}", oldStatus, newStatus);
            }
        }

        public event EventHandler iRacingProcessStarted;
        protected virtual void OniRacingProcessStarted()
        {
            EventHandler handler = iRacingProcessStarted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
                WriteLog("OnProcessStarted");
            }
        }

        public event EventHandler iRacingProcessStopped;
        protected virtual void OniRacingProcessStopped()
        {
            EventHandler handler = iRacingProcessStopped;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
                WriteLog("OnProcessStopped");
            }
        }
        #endregion

        #region fields
        protected FileSystemWatcher _telemetryDirectoryWatcher;
        protected FileSystemWatcher _setupExportWatcher;
        private FileClosedMonitor _telemetryFileClosedMonitor;
        private EngineProcessMonitor _iRacingProcessMonitor;
        #endregion

        #region properties
        private EngineStatus _status;
        public EngineStatus Status
        {
            get
            {
                return _status;
            }
        }
        public bool EnableLogging { get; set; }
        #endregion

        #region ctor
        public TrackSessionEngine() : this(true) { }
        public TrackSessionEngine(bool loggingOn)
        {
            EnableLogging = loggingOn;
            InitializeEngine();
        }
        #endregion

        #region public
        public virtual bool Start()
        {
            if (Status == EngineStatus.Error)
                return false;

            return SetStatusMonitoring();
        }
        public virtual void Stop()
        {
            SetStatusOff();
        }
        #endregion

        #region protected
        #region //*** Initialization ***//
        protected virtual void InitializeEngine()
        {
            _telemetryDirectoryWatcher = new FileSystemWatcher(Constants.iRacingTelemetryDirectory, Constants.iRacingTelemetryFileFilter);
            _telemetryDirectoryWatcher.IncludeSubdirectories = false;
            _telemetryDirectoryWatcher.NotifyFilter = NotifyFilters.Attributes |
                                                NotifyFilters.CreationTime |
                                                NotifyFilters.FileName |
                                                NotifyFilters.LastAccess |
                                                NotifyFilters.LastWrite |
                                                NotifyFilters.Size |
                                                NotifyFilters.Security;

            _telemetryDirectoryWatcher.Created += _telemetryDirectoryWatcher_Created;

            _setupExportWatcher = new FileSystemWatcher(Constants.iRacingSetupDirectory, Constants.iRacingSetupExportFileFilter);
            _setupExportWatcher.IncludeSubdirectories = true;
            _setupExportWatcher.NotifyFilter = NotifyFilters.Attributes |
                                                NotifyFilters.CreationTime |
                                                NotifyFilters.FileName |
                                                NotifyFilters.LastAccess |
                                                NotifyFilters.LastWrite |
                                                NotifyFilters.Size |
                                                NotifyFilters.Security;

            _setupExportWatcher.Created += _setupExportWatcher_Created;
            _setupExportWatcher.Changed += _setupExportWatcher_Changed;

            _iRacingProcessMonitor = new EngineProcessMonitor(Constants.iRacingProcessName);
            _iRacingProcessMonitor.EnableLogging = this.EnableLogging;
            _iRacingProcessMonitor.ProcessStarted += _iRacingProcessMonitor_ProcessStarted;
            _iRacingProcessMonitor.ProcessStopped += _iRacingProcessMonitor_ProcessStopped;
        }
        #endregion

        #region //*** Process Monitor ***//
        private void _iRacingProcessMonitor_ProcessStopped(object sender, EventArgs e)
        {
            SetStatusMonitoring();
            OniRacingProcessStopped();
        }

        private void _iRacingProcessMonitor_ProcessStarted(object sender, EventArgs e)
        {
            SetStatusSessionStarted();
            OniRacingProcessStarted();
        }
        #endregion

        #region //*** Telemetry Directory Watcher ***//
        private void _telemetryDirectoryWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                OnTelemetryFileOpened(e.FullPath);
                SetStatusWaitingForExport();
                // wait for telemetry file to be closed
                _telemetryFileClosedMonitor = new FileClosedMonitor();
                _telemetryFileClosedMonitor.FileClosed += TelemetryMonitor_FileClosed;
                _telemetryFileClosedMonitor.StartMonitor(e.FullPath);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void TelemetryMonitor_FileClosed(object sender, string e)
        {
            ((FileClosedMonitor)sender).FileClosed -= TelemetryMonitor_FileClosed;
            OnTelemetryFileClosed(e);
        }
        #endregion

        #region //*** Export Directory Watcher ***//
        private void _setupExportWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Changed");
        }
        protected virtual void _setupExportWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                Console.WriteLine("Created");
                OnSetupFileExported(e.FullPath);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region //*** Status ***//
        protected virtual bool SetStatusMonitoring()
        {
            _telemetryDirectoryWatcher.EnableRaisingEvents = true;
            _setupExportWatcher.EnableRaisingEvents = true;
            _iRacingProcessMonitor.Start();
            SetStatus(EngineStatus.Monitoring);
            return true;
        }
        protected virtual bool SetStatusSessionStarted()
        {
            _telemetryDirectoryWatcher.EnableRaisingEvents = true;
            _setupExportWatcher.EnableRaisingEvents = true;
            SetStatus(EngineStatus.SessionStarted);
            return true;
        }
        protected virtual void SetStatusRunInProgress()
        {
            SetStatus(EngineStatus.RunInProgress);
        }
        protected virtual void SetStatusWaitingForExport()
        {
            SetStatus(EngineStatus.WaitingForExport);
        }
        protected virtual void SetStatusOff()
        {
            _telemetryDirectoryWatcher.EnableRaisingEvents = false;
            _setupExportWatcher.EnableRaisingEvents = false;
            _iRacingProcessMonitor.Stop();
            SetStatus(EngineStatus.Off);
        }
        protected virtual void SetStatusError(Exception ex)
        {
            SetStatus(EngineStatus.Error);
        }
        #endregion

        #region // Common //
        protected virtual void ExceptionHandler(Exception ex)
        {
            OnEngineException(ex);
            WriteErrorLog(ex);
            SetStatusError(ex);
        }
        protected virtual void SetStatus(EngineStatus newStatus)
        {
            var originalStatus = _status;
            _status = newStatus;
            OnEngineStatusChanged(originalStatus, newStatus);
            WriteLog("Status Change: {0}->{1}", originalStatus, newStatus);
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
        #endregion

        #region IDisposable
        public void Dispose()
        {
            try
            {
                _iRacingProcessMonitor.Stop();
                _iRacingProcessMonitor.Dispose();
            }
            catch
            {
                
            }           
        }
        #endregion
    }
}
