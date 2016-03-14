using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestSessionLibrary.Data;
using SetupExportParser.SetupModels.SKModified;
using TestSessionLibrary.Data.Models;
using iRacing;

namespace TestSessionLibrary
{
    public class TestSessionEngine
    {
        #region consts      
        protected const int ExportFileClosedWaitTime = 1;
        #endregion

        #region events
        public event EventHandler RunStarted;
        protected virtual void OnRunStarted()
        {
            EventHandler handler = RunStarted;
            if (handler != null)
            {
                var e = EventArgs.Empty;
                handler(this, e);
                WriteLog("OnRunStarted");
            }
        }

        public event EventHandler<TestSessionRun> RunEnded;
        protected virtual void OnRunEnded(TestSessionRun run)
        {
            EventHandler<TestSessionRun> handler = RunEnded;
            if (handler != null)
            {
                var e = EventArgs.Empty;
                handler(this, run);
                WriteLog("OnRunEnded");
            }
        }

        public event EventHandler<TrackSessionRunModel> TrackSessionRunEnded;
        protected virtual void OnTrackSessionRunEnded(TrackSessionRunModel trackSessionRun)
        {
            EventHandler<TrackSessionRunModel> handler = TrackSessionRunEnded;
            if (handler != null)
            {
                handler(this, trackSessionRun);
                WriteLog("OnTrackSessionRunEnded");
            }
        }

        public event EventHandler<EngineFileCreatedArgs> ExportFileCreated;
        protected virtual void OnExportFileCreated(string fullFilePath)
        {
            EventHandler<EngineFileCreatedArgs> handler = ExportFileCreated;
            if (handler != null)
            {
                var e = new EngineFileCreatedArgs(fullFilePath);
                handler(this, e);
                WriteLog(String.Format("OnExportFileCreated:  {0}", fullFilePath));
            }
        }

        public event EventHandler<EngineFileCreatedArgs> TelemetryFileCreated;
        protected virtual void OnTelemetryFileCreated(string fullFilePath)
        {
            EventHandler<EngineFileCreatedArgs> handler = TelemetryFileCreated;
            if (handler != null)
            {
                var e = new EngineFileCreatedArgs(fullFilePath);
                handler(this, e);
                WriteLog("OnTelemetryFileCreated:  {0}", fullFilePath);
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
        #endregion

        #region fields
        protected FileSystemWatcher _exportDirectoryWatcher;
        protected FileSystemWatcher _telemetryDirectoryWatcher;
        protected TestSessionTelemetry _telemetry;
        protected string _telemetryFileName;
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

        public IList<TestSessionRun> Runs { get; set; }

        public TestSessionRunData RunData { get; set; }
        #endregion

        #region ctor
        public TestSessionEngine() : this(true) { }
        public TestSessionEngine(bool loggingOn)
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

            return SetStatusReady();
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
            this.Runs = new List<TestSessionRun>();

            _exportDirectoryWatcher = new FileSystemWatcher(Constants.iRacingSetupDirectory, Constants.iRacingSetupExportFileFilter);
            _exportDirectoryWatcher.IncludeSubdirectories = true;
            _exportDirectoryWatcher.Created += _directoryWatcher_Created;
            _exportDirectoryWatcher.NotifyFilter = NotifyFilters.Attributes |
                                                NotifyFilters.CreationTime |
                                                NotifyFilters.FileName |
                                                NotifyFilters.LastAccess |
                                                NotifyFilters.LastWrite |
                                                NotifyFilters.Size |
                                                NotifyFilters.Security;

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
        }
        #endregion

        #region //*** Telemetry Directory Watcher ***//
        private void _telemetryDirectoryWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                OnRunStarted();
                _telemetryFileName = e.FullPath;
                OnTelemetryFileCreated(e.FullPath);
                SetStatusWaitingForExport();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region //*** Export Directory Watcher ***//
        protected virtual void _directoryWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                var engineFileInfo = new FileInfo(e.FullPath);
                var task = WaitUntilFileClosedAsync(engineFileInfo);

                if (task.IsCompleted && !task.IsCanceled && !task.IsFaulted && task.Result == true)
                    OnExportFileCreated(e.FullPath);

                SetupFileExported(e.FullPath);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        protected async Task<bool> WaitUntilFileClosedAsync(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                await Task.Delay(TimeSpan.FromSeconds(ExportFileClosedWaitTime));
                return await WaitUntilFileClosedAsync(file);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //file is not locked
            return true;
        }
        #endregion

        #region //*** Status ***//
        protected virtual bool SetStatusReady()
        {
            _telemetryDirectoryWatcher.EnableRaisingEvents = true;
            _exportDirectoryWatcher.EnableRaisingEvents = true;
            SetStatus(EngineStatus.Monitoring);
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
            _exportDirectoryWatcher.EnableRaisingEvents = false;
            SetStatus(EngineStatus.Off);
        }
        protected virtual void SetStatusError(Exception ex)
        {
            _exportDirectoryWatcher.EnableRaisingEvents = false;
            SetStatus(EngineStatus.Error);
        }
        #endregion
        
        #region //*** Setup Exported ***//
        protected virtual void SetupFileExported(string fileName)
        {
            try
            {
                TestSessionRun run = new TestSessionRun();

                if (Status == EngineStatus.WaitingForExport)
                {
                    run.LoadTelemetryFile(_telemetryFileName);
                    run.LoadExportFile(fileName);
                    var setupDirectory = Path.GetDirectoryName(fileName);
                    run.LoadCurrentSetupFile(setupDirectory);
                    Runs.Add(run);
                    SaveTestSession(run);
                    OnRunEnded(run);
                }

                SetStatusReady();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        protected virtual void SaveTestSession(TestSessionRun run)
        {
            try
            {
                // parse telemetry //
                _telemetry = new TestSessionTelemetry();
                _telemetry.ParseTelemetryFile("telemetry", run.TelemetryFile);
                TestSessionYamlParser.ParseSessionYaml(run, _telemetry.Session);

                run.LapCount = _telemetry.Session.Laps.Count();

                // parse setup //
                var setup = new SKModifiedSetup(run.ExportFile, Convert.ToInt32(run.CarIdNumber), Convert.ToInt32(run.TrackIdNumber));

                TestSessionData sessionDataHelper = new TestSessionData();
                sessionDataHelper.SaveSkModifiedSetup(setup);
                run.SetupId = setup.SetupId;
                sessionDataHelper.SaveRun(run);
                run.Data = new TestSessionRunData(_telemetry.Session, setup);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        public static void LoadTelemetrySession(TestSessionRun run)
        {
            var telemetry = new TestSessionTelemetry();
            telemetry.ParseTelemetryFile("telemetry", run.TelemetryFile);
            TestSessionYamlParser.ParseSessionYaml(run, telemetry.Session);
            var setup = new SKModifiedSetup(run.ExportFile, Convert.ToInt32(run.CarIdNumber), Convert.ToInt32(run.TrackIdNumber));
            run.Data = new TestSessionRunData(telemetry.Session, setup);
        }

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
            if (EnableLogging)
            {
                Logger.Log.Error(ex);
            }
        }
        #endregion        
    }
}
