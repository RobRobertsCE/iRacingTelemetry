using iRacing.TelemetryParser;
using iRacing.TelemetryParser.Session;
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
using iRacing.TrackSession.Engine;
using iRacing.TelemetryAnalysis.Laps;
using Newtonsoft.Json;

namespace iRacing.TrackSession
{
    public class TrackSessionManager : LoggingBase
    {
        #region events
        public event EventHandler<NewTireSheetArgs> NewTireSheet;
        protected virtual void OnNewTireSheet(TireSheet newTireSheet, Guid? trackSessionRunId)
        {
            if (!_enableEvents) return;
            EventHandler<NewTireSheetArgs> handler = NewTireSheet;
            if (handler != null)
            {
                var e = new NewTireSheetArgs(newTireSheet, trackSessionRunId);
                handler(this, e);
                WriteLog("Manager:OnNewTireSheet");
            }
        }

        public event EventHandler<TrackSessionStartedArgs> TrackSessionStarted;
        protected virtual void OnTrackSessionStarted(Guid sessionId)
        {
            if (!_enableEvents) return;
            EventHandler<TrackSessionStartedArgs> handler = TrackSessionStarted;
            if (handler != null)
            {
                var e = new TrackSessionStartedArgs(sessionId);
                handler(this, e);
                WriteLog("OnTrackSessionStarted");
            }
        }

        public event EventHandler<TrackSessionRunCompleteArgs> SessionRunComplete;
        protected virtual void OnSessionRunComplete(Guid runId)
        {
            if (!_enableEvents) return;
            EventHandler<TrackSessionRunCompleteArgs> handler = SessionRunComplete;
            if (handler != null)
            {
                var e = new TrackSessionRunCompleteArgs(runId);
                handler(this, e);
                WriteLog("OnSessionRunComplete");
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
        protected virtual void OnEngineException(EngineExceptionArgs e)
        {
            if (!_enableEvents) return;
            EventHandler<EngineExceptionArgs> handler = EngineException;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ManagerStatusChangedArgs> ManagerStatusChanged;
        protected virtual void OnManagerStatusChanged(ManagerStatus oldStatus, ManagerStatus newStatus)
        {
            if (!_enableEvents) return;
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
        bool _enableEvents = false;
        TrackSessionEngine _engine;
        #endregion

        #region properties
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

        private TrackSessionData _trackSessionData;
        public TrackSessionData TrackSessionData
        {
            get
            {
                if (null == _trackSessionData)
                {
                    _trackSessionData = new TrackSessionData();
                }
                return _trackSessionData;
            }
        }

        public EngineStatus EngineStatus
        {
            get
            {
                return _engine.Status;
            }
        }
        private ManagerStatus _managerStatus = ManagerStatus.Initializing;
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
        public TrackSessionManager(bool loggingOn, bool useTestMode) : base(loggingOn)
        {
            InitializeEngine();
        }
        protected virtual void InitializeEngine()
        {
            _engine = new TrackSessionEngine(EnableLogging);
            _engine.EngineException += _engine_EngineException;
            _engine.EngineStatusChanged += _engine_EngineStatusChanged;
            _engine.TelemetryFileClosed += _engine_TelemetryFileClosed;
            _engine.SetupFileExported += _engine_SetupFileExported;
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
            switch (e.NewStatus)
            {
                case EngineStatus.Off:
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
        public void Start()
        {
            _enableEvents = true;
            _engine.Start();
        }
        public void Stop()
        {
            _enableEvents = false;
            _engine.Stop();
        }
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
        protected virtual void CloseTestSession()
        {
            Session = null;
        }

        //*** Tire Sheet ***//
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
                            data.SetTrackSessionRunTireSheet(runId.Value, lastRun.TireSheetJson);
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

        //*** Track Session Run ***//
        protected virtual void RunEnded(string telemetryFile)
        {
            try
            {
                // get the telemetry file
                var telemetry = GetTelemetryModel(telemetryFile);

                // parse the telemetry file
                var telemetryParser = new ParserEngine();
                var info = telemetryParser.ParseTelemetrySessionInfo(telemetry.TelemetryDiskFile, telemetry.BinaryData);

                // get the session run details
                var season = TrackSessionData.GetSeason(telemetry.Timestamp);
                var sessionType = TrackSessionData.GetSessionType(info.SessionInfo.Sessions[0].SessionType);
                var vehicle = TrackSessionData.GetVehicle(Convert.ToInt32(info.DriverInfo.CurrentDriver().CarID),
                    info.DriverInfo.CurrentDriver().CarScreenNameShort,
                    info.DriverInfo.CurrentDriver().CarPath,
                    info.DriverInfo.CurrentDriver().CarScreenName);
                var track = TrackSessionData.GetTrack(Convert.ToInt32(info.WeekendInfo.TrackID),
                    info.WeekendInfo.TrackDisplayName,
                    Convert.ToDouble(info.WeekendInfo.TrackLength.Substring(0, info.WeekendInfo.TrackLength.Length - 3)));

                // get the setup model
                var setup = GetSetupModel(info);

                // prep the session
                if ((null != Session) && (Session.TrackNumber != track.TrackNumber ||
                    Session.VehicleNumber != vehicle.VehicleNumber ||
                    Session.SessionTypeId != sessionType.SessionTypeId))
                {
                    // Session has changed.
                    CloseTestSession();
                }

                if (null == Session)
                {
                    Session = GetTrackSessionModel(season, vehicle, track, sessionType, info);
                    Session = TrackSessionData.SaveTrackSession(Session);
                    OnTrackSessionStarted(Session.TrackSessionId);
                }

                // get the run model.
                var run = GetTrackSessionRunModel(Session, setup, telemetry);
                Session.Runs.Add(run);
                TrackSessionData.SaveTrackSessionRun(run);
                // update the session.
                Session = TrackSessionData.GetTrackSession(Session.TrackSessionId);
                OnSessionRunComplete(run.TrackSessionRunId);
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

        //*** Models ***//
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
            var analysis = GetTrackSessionRunLaps(telemetry);
            var laps = analysis.RawLaps;
            var model = new TrackSessionRunModel()
            {
                TrackSessionId = session.TrackSessionId,
                Setup = setup,
                Telemetry = telemetry,
                RunNumber = session.Runs.Count + 1,
                LapsJson = LapsToJson(laps),
                LapCount = laps.Count()
            };
            return model;
        }
        private LapTimeAnalysis GetTrackSessionRunLaps(TelemetryModel telemetryModel)
        {
            var tFile = TelemetryFileParser.ParseTelemetryBinaryData(telemetryModel.TelemetryDiskFile, telemetryModel.BinaryData);
            var tLaps =  TelemetryLapsParser.ParseLaps(tFile);
            var analysis = new LapTimeAnalysis(tLaps);
            return analysis;
        }
        protected virtual string LapsToJson(IDictionary<int, float> laps)
        {
            JsonSerializer jsonSerializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (var jsonStreamWriter = new StringWriter())
            {
                jsonSerializer.Serialize(jsonStreamWriter, laps);
                return jsonStreamWriter.ToString();
            }
        }
        protected virtual IDictionary<int, float> JsonToLaps(string lapsJson)
        {
            return JsonConvert.DeserializeObject<Dictionary<int, float>>(lapsJson);
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
    }
}
