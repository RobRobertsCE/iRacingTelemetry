using iRacing.TelemetryParser;
using iRacing.TelemetryParser.Session;
using iRacing;
using iRacing.SetupLibrary.Parsers;
using iRacing.SetupLibrary.Tires;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using iRacing.TrackSession.Data;
using iRacing.TrackSession.Data.Models;
using iRacing.TrackSession.Views;

namespace iRacing.TrackSession
{
    public class TrackSessionManager : IDisposable
    {
        #region events
        public event EventHandler<NewTireSheetArgs> NewTireSheet;
        protected virtual void OnNewTireSheet(TireSheet newTireSheet, Guid? trackSessionRunId)
        {
            EventHandler<NewTireSheetArgs> handler = NewTireSheet;
            if (handler != null)
            {
                var e = new NewTireSheetArgs(newTireSheet, trackSessionRunId);
                handler(this, e);
                WriteLog("Manager:OnNewTireSheet");
            }
        }

        public event EventHandler<TrackSessionStartedArgs> TrackSessionStarted;
        protected virtual void OnTrackSessionStarted(TrackSessionView view)
        {
            EventHandler<TrackSessionStartedArgs> handler = TrackSessionStarted;
            if (handler != null)
            {
                var e = new TrackSessionStartedArgs(view);
                handler(this, e);
                WriteLog("OnTrackSessionStarted");
            }
        }

        public event EventHandler<TrackSessionRunCompleteArgs> SessionRunComplete;
        protected virtual void OnSessionRunComplete(TrackSessionRunView run)
        {
            EventHandler<TrackSessionRunCompleteArgs> handler = SessionRunComplete;
            if (handler != null)
            {
                var e = new TrackSessionRunCompleteArgs(run);
                handler(this, e);
                WriteLog("OnSessionRunComplete");
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
        protected virtual void OnEngineException(EngineExceptionArgs e)
        {
            EventHandler<EngineExceptionArgs> handler = EngineException;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ManagerStatusChangedArgs> ManagerStatusChanged;
        protected virtual void OnManagerStatusChanged(ManagerStatus oldStatus, ManagerStatus newStatus)
        {
            EventHandler<ManagerStatusChangedArgs> handler = ManagerStatusChanged;

            if (handler != null)
            {
                var e = new ManagerStatusChangedArgs(oldStatus, newStatus);
                handler(this, e);
                WriteLog("TrackSessionManager:OnManagerStatusChanged:  {0}->{1}", e.OldStatus, e.NewStatus);
            }
        }
        #endregion

        #region fields
        private TrackSessionEngine _engine;
        #endregion

        #region properties
        public bool EnableLogging { get; set; }
        public bool EnableTestMode { get; set; }

        private TrackSessionModel _session;
        public TrackSessionModel Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }

        public TrackSessionRunView CurrentRun { get; set; }

        private EngineStatus _engineStatus;
        public EngineStatus EngineStatus
        {
            get
            {
                return _engineStatus;
            }
        }

        private ManagerStatus _managerStatus;
        public ManagerStatus ManagerStatus
        {
            get
            {
                return _managerStatus;
            }
            private set
            {
                if (_managerStatus == value) return;
                OnManagerStatusChanged(_managerStatus, value);
                _managerStatus = value;
            }
        }
        #endregion

        #region ctor
        public TrackSessionManager() : this(true)
        { }
        public TrackSessionManager(bool loggingOn) : this(loggingOn, false)
        { }
        public TrackSessionManager(bool loggingOn, bool useTestMode)
        {
            EnableLogging = loggingOn;
            EnableTestMode = useTestMode;
            InitializeEngine();
            SetManagerStatus(ManagerStatus.Idle);
        }
        protected virtual void InitializeEngine()
        {
            _engine = new TrackSessionEngine(EnableLogging, EnableTestMode);
            _engine.EngineException += _engine_EngineException;
            _engine.EngineStatusChanged += _engine_EngineStatusChanged;
            _engine.TelemetryFileClosed += _engine_TelemetryFileClosed;
            _engine.SetupFileExported += _engine_SetupFileExported;
            _engine.Start();
        }
        #endregion

        #region engine events
        private void _engine_SetupFileExported(object sender, EngineFileCreatedArgs e)
        {
            GetTireSheet(e.FullPath);
        }
        private void _engine_TelemetryFileClosed(object sender, EngineFileCreatedArgs e)
        {
            RunEnded(e.FullPath);
        }
        private void _engine_EngineStatusChanged(object sender, EngineStatusChangedArgs e)
        {
            _engineStatus = e.NewStatus;
            switch (_engineStatus)
            {
                case EngineStatus.Initializing:
                    {
                        SetManagerStatus(ManagerStatus.Off);
                        break;
                    }
                case EngineStatus.WaitingForApp:
                    {
                        SetManagerStatus(ManagerStatus.Idle);
                        break;
                    }
                case EngineStatus.AppRunning:
                    {
                        SetManagerStatus(ManagerStatus.Monitoring);
                        break;
                    }
                case EngineStatus.RunInProgress:
                    {
                        SetManagerStatus(ManagerStatus.Busy);
                        break;
                    }
                case EngineStatus.WaitingForExport:
                    {
                        SetManagerStatus(ManagerStatus.Monitoring);
                        break;
                    }
            }
        }
        private void _engine_EngineException(object sender, EngineExceptionArgs e)
        {
            OnEngineException(e);
        }
        #endregion

        #region public      
        #region archive
        private int _count;
        private int _maxCount;
        private IList<string> _archived;
        public IList<TelemetryFileDetails> ArchiveTelemetry()
        {
            return ArchiveTelemetry(10);
        }
        public IList<TelemetryFileDetails> ArchiveTelemetry(int count)
        {
            if (count == -1)
                count = Int32.MaxValue;

            _maxCount = count;
            _count = 0;
            using (var data = new TrackSessionData())
            {
                _archived = data.GetArchivedTelemetry();
            }
            var telemetryDirInfo = new DirectoryInfo(Constants.iRacingTelemetryDirectory);
            return ArchiveDirectory(telemetryDirInfo);
        }
        private IList<TelemetryFileDetails> ArchiveDirectory(DirectoryInfo dir)
        {
            var results = new List<TelemetryFileDetails>();
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                if (_count >= _maxCount)
                    break;
                results.AddRange(ArchiveDirectory(subDir));
            }
            foreach (FileInfo telemetryFile in dir.GetFileSystemInfos("*.ibt"))
            {
                if (_count >= _maxCount)
                    break;
                if (!_archived.Contains(telemetryFile.FullName))
                {
                    if (Path.GetFileNameWithoutExtension(telemetryFile.FullName).Length > 25)
                    {
                        results.Add(ArchiveTelemetryFile(telemetryFile));
                        _count++;
                    }
                }
            }
            return results;
        }
        private TelemetryFileDetails ArchiveTelemetryFile(FileInfo telemetryFile)
        {
            var telemetryDetail = new TelemetryFileDetails(telemetryFile);
            var data = new TrackSessionData();
            var model = GetTelemetryModel(telemetryDetail);
            data.SaveTelemetry(model);
            telemetryDetail.TelemetryId = model.TelemetryId;
            return telemetryDetail;
        }
        private TelemetryModel GetTelemetryModel(TelemetryFileDetails details)
        {
            var model = new TelemetryModel();
            model.TelemetryDiskFile = details.Path;
            model.BinaryData = File.ReadAllBytes(details.Path);
            Debug.Assert(details.FileName.Length > 0);
            var fileTitle = Path.GetFileNameWithoutExtension(details.FileName);
            Debug.Assert(fileTitle.Length > 19);
            var dt = fileTitle.Substring(fileTitle.Length - 19);
            model.Timestamp = DateTime.ParseExact(dt, "yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
            return model;
        }
        public class TelemetryFileDetails
        {
            public string FileName { get; set; }
            public string Path { get; set; }
            public long Size { get; set; }
            public Guid TelemetryId { get; set; }

            public TelemetryFileDetails()
            {

            }
            public TelemetryFileDetails(FileInfo telemetryFile)
            {
                FileName = telemetryFile.Name;
                Path = telemetryFile.FullName;
                Size = telemetryFile.Length;
            }
        }
        #endregion
        #endregion

        #region protected
        protected virtual void SetManagerStatus(ManagerStatus newStatus)
        {
            ManagerStatus = newStatus;
        }

        protected virtual void GetTireSheet(string htmlSetupExportFile)
        {
            var htmlParser = new HtmlExportParser();
            var htmlSetupExport = File.ReadAllText(htmlSetupExportFile);
            var tireSheet = htmlParser.GetTireSheet(htmlSetupExport);
            SetCurrentRunTireSheet(tireSheet);
        }

        protected virtual void SetCurrentRunTireSheet(TireSheet tireSheet)
        {
            if (null != Session)
            {
                Guid? runId = null;
                try
                {
                    var lastRun = Session.Runs.LastOrDefault();
                    if (null != lastRun)
                    {
                        runId = lastRun.TrackSessionRunId;
                        lastRun.TireSheetJson = tireSheet.ToJson();
                        using (var data = new TrackSessionData())
                        {
                            data.SaveTrackSessionRun(lastRun);
                            Session = data.GetTrackSession(Session.TrackSessionId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteErrorLog(ex);
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    OnNewTireSheet(tireSheet, runId);
                }
            }
        }

        protected virtual void RunEnded(string telemetryFile)
        {
            try
            {
                using (var data = new TrackSessionData())
                {
                    // get the telemetry file
                    var telemetry = GetTelemetryModel(telemetryFile);

                    // parse the telemetry file
                    var telemetryParser = new ParserEngine();

                    var info = telemetryParser.ParseTelemetrySessionInfo(telemetry.TelemetryDiskFile, telemetry.BinaryData);

                    // get the session run details
                    var season = data.GetSeason(telemetry.Timestamp);
                    var sessionType = data.GetSessionType(info.SessionInfo.Sessions[0].SessionType);
                    var vehicle = data.GetVehicle(Convert.ToInt32(info.DriverInfo.CurrentDriver().CarID),
                        info.DriverInfo.CurrentDriver().CarScreenNameShort,
                        info.DriverInfo.CurrentDriver().CarPath,
                        info.DriverInfo.CurrentDriver().CarScreenName);
                    var track = data.GetTrack(Convert.ToInt32(info.WeekendInfo.TrackID),
                        info.WeekendInfo.TrackName,
                        Convert.ToDouble(info.WeekendInfo.TrackLength.Substring(0, info.WeekendInfo.TrackLength.Length - 3)));

                    // get the setup model
                    var setup = GetSetupModel(info);

                    // prep the session
                    if ((null != Session) && (Session.TrackNumber != track.TrackNumber ||
                        Session.VehicleNumber != vehicle.VehicleNumber ||
                        Session.SessionTypeId != sessionType.SessionTypeId))
                    {
                        CloseTestSession();
                    }

                    if (null == Session)
                    {
                        Session = GetTrackSessionModel(season, vehicle, track, sessionType, info);
                        data.SaveTrackSession(Session);
                        OnTrackSessionStarted(new TrackSessionView(Session));
                    }

                    // get the run model.
                    var run = GetTrackSessionRunModel(Session, setup, telemetry);
                    Session.Runs.Add(run);
                    data.SaveTrackSessionRun(run);

                    Session = data.GetTrackSession(Session.TrackSessionId);

                    CurrentRun = new TrackSessionRunView(run);
                    OnSessionRunComplete(CurrentRun);
                }
            }
            catch (Exception ex)
            {
                OnEngineException(ex);
            }
            finally
            {
                SetManagerStatus(ManagerStatus.Monitoring);
            }
        }

        protected virtual void CloseTestSession()
        {
            Session = null;
        }

        private TelemetryModel GetTelemetryModel(string fullPath)
        {
            var model = new TelemetryModel();
            model.TelemetryDiskFile = fullPath;
            model.BinaryData = File.ReadAllBytes(fullPath);
            var fileTitle = Path.GetFileNameWithoutExtension(fullPath);
            var dt = fileTitle.Substring(fileTitle.Length - 19);
            model.Timestamp = DateTime.ParseExact(dt, "yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
            return model;
        }

        private TrackSessionModel GetTrackSessionModel(SeasonModel season, VehicleModel vehicle, TrackModel track, SessionTypeModel sessionType, ITelemetrySessionInfo info)
        {
            var model = new TrackSessionModel()
            {
                Season = season,
                SessionType = sessionType,
                Track = track,
                Vehicle = vehicle,
                Timestamp = DateTime.Now,
                TrackTemp = info.WeekendInfo.TrackSurfaceTemp,
                AirTemp = info.WeekendInfo.TrackAirTemp,
                Skies = info.WeekendInfo.TrackSkies,
                Night = (info.WeekendInfo.WeekendOptions.NightMode.Trim() == "1"),
                Humidity = Convert.ToSingle(info.WeekendInfo.TrackRelativeHumidity.TrimEnd('%'))
            };
            return model;
        }

        private TrackSessionRunModel GetTrackSessionRunModel(TrackSessionModel session, SetupModel setup, TelemetryModel telemetry)
        {
            var model = new TrackSessionRunModel()
            {
                TrackSessionId = session.TrackSessionId,
                Setup = setup,
                Telemetry = telemetry,
                RunNumber = session.Runs.Count + 1
            };
            return model;
        }

        private SetupModel GetSetupModel(ITelemetrySessionInfo info)
        {
            var model = new SetupModel()
            {
                Name = info.DriverInfo.DriverSetupName,
                VehicleNumber = Convert.ToInt32(info.DriverInfo.CurrentDriver().CarID),
                SetupJSON = info.SetupJSON,
                SetupBinary = GetSetupBinary(info.DriverInfo.CurrentDriver().CarPath)
            };
            return model;
        }

        protected virtual byte[] GetSetupBinary(string carPath)
        {
            var setupDirectory = Path.Combine(iRacing.Constants.iRacingSetupDirectory, carPath);
            var setupFilePath = Path.Combine(setupDirectory, iRacing.Constants.iRacingDefaultSetupFile);
            return File.ReadAllBytes(setupFilePath);
        }
        #endregion

        #region common
        protected virtual void ExceptionHandler(Exception ex)
        {
            WriteErrorLog(ex);
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
            DisposeEngine();
        }
        protected virtual void DisposeEngine()
        {
            if (null != _engine)
            {
                _engine.EngineException -= _engine_EngineException;
                _engine.EngineStatusChanged -= _engine_EngineStatusChanged;
                _engine.TelemetryFileClosed -= _engine_TelemetryFileClosed;
                _engine.SetupFileExported -= _engine_SetupFileExported;

                _engine = null;
            }
        }
        #endregion
    }
}
