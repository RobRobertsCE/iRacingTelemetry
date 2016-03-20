using iRacing.TrackSession.Monitors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace iRacing.TrackSession.Engine
{
    internal class TrackSessionEngine : LoggingBase
    {
        #region consts
        private const bool DefaultLogging_On = false;
        #endregion

        #region events   
        public event EventHandler<EngineFileCreatedArgs> TelemetryFileOpened;
        protected virtual void OnTelemetryFileOpened(string fullFilePath)
        {
            if (!_enableEvents) return;
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
            if (!_enableEvents) return;
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
            if (!_enableEvents) return;
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
            if (!_enableEvents) return;
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
            if (!_enableEvents) return;
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
            if (!_enableEvents) return;
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
            if (!_enableEvents) return;
            EventHandler handler = iRacingProcessStopped;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
                WriteLog("OnProcessStopped");
            }
        }
        #endregion

        #region fields
        private bool _enableEvents = false;
        private bool _exportFileLock = false;
        private string _exportFileName = String.Empty;
        private object _exportFileLockObject = new object();
        protected FileSystemWatcher _telemetryDirectoryWatcher;
        protected FileSystemWatcher _setupExportDirectoryWatcher;
        private FileClosedMonitor _telemetryFileClosedMonitor;
        private FileClosedMonitor _setupExportFileClosedMonitor;
        private EngineProcessMonitor _iRacingProcessMonitor;
        #endregion

        #region properties
        private EngineStatus _status = EngineStatus.Off;
        public EngineStatus Status
        {
            get
            {
                return _status;
            }
        }
        #endregion

        #region ctor
        public TrackSessionEngine() : this(DefaultLogging_On) { }
        public TrackSessionEngine(bool loggingOn) : base(loggingOn)
        {
            InitializeEngine();
        }
        #endregion

        #region public
        public void Start()
        {
            _enableEvents = true;
            SetStatusWaitingForApp();
            EnableProcessMonitors();
        }
        public void Stop()
        {
            SetStatusOff();
            _enableEvents = false;
            DisableProcessMonitors();
            DisableFileSystemMonitors();
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

            _setupExportDirectoryWatcher = new FileSystemWatcher(Constants.iRacingSetupDirectory, Constants.iRacingSetupExportFileFilter);
            _setupExportDirectoryWatcher.IncludeSubdirectories = true;
            _setupExportDirectoryWatcher.NotifyFilter = NotifyFilters.Attributes |
                                                NotifyFilters.CreationTime |
                                                NotifyFilters.FileName |
                                                NotifyFilters.LastAccess |
                                                NotifyFilters.LastWrite |
                                                NotifyFilters.Size |
                                                NotifyFilters.Security;

            _setupExportDirectoryWatcher.Created += _setupExportWatcher_Created;
            _setupExportDirectoryWatcher.Changed += _setupExportWatcher_Changed;

            _iRacingProcessMonitor = new EngineProcessMonitor(new List<string>() { Constants.iRacingDX9ProcessName, Constants.iRacingDX11ProcessName });
            _iRacingProcessMonitor.EnableLogging = this.EnableLogging;
            _iRacingProcessMonitor.ProcessStarted += _iRacingProcessMonitor_ProcessStarted;
            _iRacingProcessMonitor.ProcessStopped += _iRacingProcessMonitor_ProcessStopped;
        }
        #endregion

        #region //*** Monitors On/Off ***//
        protected virtual void EnableProcessMonitors()
        {
            _iRacingProcessMonitor.Start();
        }
        protected virtual void DisableProcessMonitors()
        {
            _iRacingProcessMonitor.Stop();
        }
        protected virtual void EnableFileSystemMonitors()
        {
            _telemetryDirectoryWatcher.EnableRaisingEvents = true;
            _setupExportDirectoryWatcher.EnableRaisingEvents = true;
        }
        protected virtual void DisableFileSystemMonitors()
        {
            _telemetryDirectoryWatcher.EnableRaisingEvents = false;
            _setupExportDirectoryWatcher.EnableRaisingEvents = false;
        }
        #endregion

        #region //*** Process Monitor ***//
        private void _iRacingProcessMonitor_ProcessStopped(object sender, EventArgs e)
        {
            OniRacingProcessStopped();
            SetStatusWaitingForApp();
        }
        private void _iRacingProcessMonitor_ProcessStarted(object sender, EventArgs e)
        {
            OniRacingProcessStarted();
            SetStatusAppRunning();
        }
        #endregion

        #region //*** Telemetry Directory Watcher ***//
        private void _telemetryDirectoryWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                OnTelemetryFileOpened(e.FullPath);
                SetStatusRunInProgress();
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
            Console.WriteLine("Telemetry File Closed");
            ((FileClosedMonitor)sender).FileClosed -= TelemetryMonitor_FileClosed;
            OnTelemetryFileClosed(e);
            SetStatusWaitingForExport();
        }
        #endregion

        #region //*** Export Directory Watcher ***//
        /// <summary>
        /// Handler to catch overwriting an existing export file.
        /// </summary>
        private void _setupExportWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (_exportFileLock) return;
            if (_exportFileName == e.FullPath) return;

            lock (_exportFileLockObject)
            {
                _exportFileLock = true;
                _exportFileName = e.FullPath;
            }

            Console.WriteLine("Setup Export File Changed");
            // wait for setup export file to be closed
            _setupExportFileClosedMonitor = new FileClosedMonitor();
            _setupExportFileClosedMonitor.FileClosed += SetupExportMonitorMonitor_FileClosed;
            _setupExportFileClosedMonitor.StartMonitor(e.FullPath);
        }
        /// <summary>
        /// Handler for creating a new export file.
        /// </summary>
        protected virtual void _setupExportWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (_exportFileLock) return;
                if (_exportFileName == e.FullPath) return;

                lock (_exportFileLockObject)
                {
                    _exportFileLock = true;
                    _exportFileName = e.FullPath;
                }
                Console.WriteLine("Setup Export File Created");
                // wait for setup export file to be closed
                _setupExportFileClosedMonitor = new FileClosedMonitor();
                _setupExportFileClosedMonitor.FileClosed += SetupExportMonitorMonitor_FileClosed;
                _setupExportFileClosedMonitor.StartMonitor(e.FullPath);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void SetupExportMonitorMonitor_FileClosed(object sender, string e)
        {
            Console.WriteLine("Setup Export File Closed");
            ((FileClosedMonitor)sender).FileClosed -= SetupExportMonitorMonitor_FileClosed;
            OnSetupFileExported(e);
            SetStatusAppRunning();
            lock (_exportFileLockObject)
            {
                _exportFileLock = false;
                _exportFileName = String.Empty;
            }
        }
        #endregion

        #region //*** Status ***//
        protected virtual void SetStatusOff()
        {
            SetStatus(EngineStatus.Off);
        }
        protected virtual void SetStatusWaitingForApp()
        {
            DisableFileSystemMonitors();
            SetStatus(EngineStatus.WaitingForApp);
        }
        protected virtual void SetStatusAppRunning()
        {
            EnableFileSystemMonitors();
            SetStatus(EngineStatus.AppRunning);
        }
        protected virtual void SetStatusRunInProgress()
        {
            SetStatus(EngineStatus.RunInProgress);
        }
        protected virtual void SetStatusWaitingForExport()
        {
            SetStatus(EngineStatus.WaitingForExport);
        }
        protected virtual void SetStatus(EngineStatus newStatus)
        {
            var originalStatus = _status;
            _status = newStatus;
            OnEngineStatusChanged(originalStatus, newStatus);
            WriteLog("Status Change: {0}->{1}", originalStatus, newStatus);
        }
        #endregion     
        #endregion        
    }
}
