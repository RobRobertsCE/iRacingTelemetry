using ibtParserLibrary;
using ibtSessionLibrary;
using iRacing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using TestSessionLibrary.Data;
using TestSessionLibrary.Data.Models;
using TestSessionLibrary.Views;

namespace TestSessionLibrary
{   
    public class TrackSessionManager : IDisposable
    {
        #region events
        public event EventHandler<SessionRunCompleteArgs> SessionRunComplete;
        protected virtual void OnSessionRunComplete(TrackSessionRunView run)
        {
            EventHandler<SessionRunCompleteArgs> handler = SessionRunComplete;
            if (handler != null)
            {
                var e = new SessionRunCompleteArgs(run);
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

        public event EventHandler<EngineStatusChangedArgs> EngineStatusChanged;
        protected virtual void OnEngineStatusChanged(EngineStatus oldStatus, EngineStatus newStatus)
        {
            var e = new EngineStatusChangedArgs(oldStatus, newStatus);
            OnEngineStatusChanged(e);
        }
        protected virtual void OnEngineStatusChanged(EngineStatusChangedArgs e)
        {
            EventHandler<EngineStatusChangedArgs> handler = EngineStatusChanged;
            if (handler != null)
            {
                handler(this, e);
                WriteLog("TrackSessionManager:OnEngineStatusChanged:  {0}->{1}", e.OldStatus, e.NewStatus);
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

        private EngineStatus _status;
        public EngineStatus EngineStatus
        {
            get
            {
                return _status;
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
                _managerStatus = value;
            }
        }
        #endregion

        #region ctor
        public TrackSessionManager() : this(true)
        {

        }
        public TrackSessionManager(bool loggingOn)
        {
            EnableLogging = loggingOn;
            InitializeEngine();
        }
        protected virtual void InitializeEngine()
        {
            _engine = new TrackSessionEngine();
            _engine.EngineException += _engine_EngineException;
            _engine.EngineStatusChanged += _engine_EngineStatusChanged;
            _engine.TelemetryFileOpened += _engine_TelemetryFileOpened;
            _engine.TelemetryFileClosed += _engine_TelemetryFileClosed;
            _engine.iRacingProcessStarted += _engine_ProcessStarted;
            _engine.iRacingProcessStopped += _engine_ProcessStopped;
        }
        #endregion

        #region engine events
        private void _engine_TelemetryFileOpened(object sender, EngineFileCreatedArgs e)
        {
            RunStarted();
        }
        private void _engine_TelemetryFileClosed(object sender, EngineFileCreatedArgs e)
        {
            RunEnded(e.FullPath);
        }
        private void _engine_EngineStatusChanged(object sender, EngineStatusChangedArgs e)
        {
            _status = e.NewStatus;
            OnEngineStatusChanged(e);
        }
        private void _engine_EngineException(object sender, EngineExceptionArgs e)
        {
            OnEngineException(e);
        }
        private void _engine_ProcessStopped(object sender, EventArgs e)
        {
            iRacingProcessEnded();
        }
        private void _engine_ProcessStarted(object sender, EventArgs e)
        {
            iRacingProcessRunning();
        }
        #endregion

        #region public
        public void StartManager()
        {
            SetManagerStatus(ManagerStatus.Idle);
            _engine.Start();
        }
        public void StopManager()
        {
            _engine.Stop();
            if (ManagerStatus == ManagerStatus.RunInProgress)
            {
                RunEnded(String.Empty, true);
            }
            SetManagerStatus(ManagerStatus.Off);
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
            var oldStatus = ManagerStatus;
            ManagerStatus = newStatus;
            OnManagerStatusChanged(oldStatus, newStatus);
        }

        protected virtual void iRacingProcessRunning()
        {
            SetManagerStatus(ManagerStatus.Monitoring);
        }
        protected virtual void iRacingProcessEnded()
        {
            SetManagerStatus(ManagerStatus.Idle);
        }

        protected virtual void RunStarted()
        {
            SetManagerStatus(ManagerStatus.RunInProgress);
        }

        protected virtual void RunEnded(string telemetryFile)
        {
            RunEnded(telemetryFile, false);
        }
        protected virtual void RunEnded(string telemetryFile, bool forceEnd)
        {
            try
            {
                using (var data = new TrackSessionData())
                {
                    // get the telemetry file
                    var telemetry = GetTelemetryModel(telemetryFile);

                    // parse the telemetry file
                    var telemetryParser = new ParserEngine();
                    //var telemetrySession = telemetryParser.ParseTelemetryBytes(telemetry.TelemetryDiskFile, telemetry.BinaryData, false);
                    //return;
                    var info = telemetryParser.ParseTelemetrySessionInfo(telemetry.TelemetryDiskFile, telemetry.BinaryData);
                    
                    // get the session run details
                    var season = data.GetSeason(telemetry.Timestamp);
                    var sessionType = data.GetSessionType(info.SessionInfo.Sessions[0].SessionType );
                    var vehicle = data.GetVehicle(Convert.ToInt32(info.DriverInfo.CurrentDriver().CarID),
                        info.DriverInfo.CurrentDriver().CarScreenNameShort,
                        info.DriverInfo.CurrentDriver().CarPath,
                        info.DriverInfo.CurrentDriver().CarScreenName);
                    var track = data.GetTrack(Convert.ToInt32(info.WeekendInfo.TrackID),
                        info.WeekendInfo.TrackName, 
                        Convert.ToDouble(info.WeekendInfo.TrackLength.Substring(0, info.WeekendInfo.TrackLength.Length-3)));

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
                    }

                    // get the run model.
                    var run = GetTrackSessionRunModel(Session, setup, telemetry);
                    Session.Runs.Add(run);
                    data.SaveTrackSessionRun(run);

                    Session = data.GetTrackSession(Session.TrackSessionId);

                    var view = new TrackSessionRunView(run);
                    OnSessionRunComplete(view);
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

        //public virtual void EndOfRunProcess()
        //{
        //    try
        //    {
        //        if (!String.IsNullOrEmpty(_currentTelemetryFile))
        //        {
        //            // TODO: Need to populate the session, and runs.
        //            ////TestSessionRun run = new TestSessionRun();
        //            ////run.LoadTelemetryFile(_currentTelemetryFile);

        //            ////if (!String.IsNullOrEmpty(_currentExportFile))
        //            ////{
        //            ////    run.LoadExportFile(_currentExportFile);
        //            ////    var setupDirectory = Path.GetDirectoryName(_currentExportFile);
        //            ////    run.LoadCurrentSetupFile(setupDirectory);
        //            ////}

        //            // NEW
        //            var data = new TrackSessionData();

        //            var telemetryModel = GetTelemetryModel(_currentTelemetryFile);
        //            telemetryModel = data.SaveTelemetry(telemetryModel);

        //            var telemetryParser = new ParserEngine();
        //            var telemetrySession = telemetryParser.ParseTelemetryBytes(telemetryModel.TelemetryDiskFile, telemetryModel.BinaryData, false);

        //            var season = data.GetSeason(telemetryModel.Timestamp);
        //            var sessionType = data.GetSessionType(telemetrySession.SessionType);
        //            var vehicle = data.GetVehicle(Convert.ToInt32(telemetrySession.CarIdNumber), telemetrySession.CarName, telemetrySession.CarPath, telemetrySession.CarScreenName);
        //            var track = data.GetTrack(Convert.ToInt32(telemetrySession.TrackIdNumber), telemetrySession.TrackName, Convert.ToDouble(telemetrySession.TrackLength));

        //            var sessionModel = new TrackSessionModel()
        //            {
        //                Season = season,
        //                SessionType = sessionType,
        //                Vehicle = vehicle,
        //                Track = track,
        //                Timestamp = telemetryModel.Timestamp,
        //                TrackTemp = telemetrySession.TrackTemp,
        //                AirTemp = telemetrySession.AirTemp,
        //                Skies = telemetrySession.Skies,
        //                Night = telemetrySession.Night,
        //                Humidity = Convert.ToSingle(telemetrySession.RelativeHumidity)
        //            };
        //            sessionModel = data.SaveTrackSession(sessionModel);

        //            var setupDirectory = Path.GetDirectoryName(_currentExportFile);
        //            var currentSetupFile = Path.Combine(setupDirectory, Constants.iRacingDefaultCurrentSetupFile);
        //            var setupModel = new SetupModel()
        //            {
        //                Name = telemetrySession.SetupName,
        //                VehicleNumber = vehicle.VehicleNumber,
        //                SetupData = File.ReadAllBytes(currentSetupFile),
        //                SetupExport = File.ReadAllText(_currentExportFile)
        //            };
        //            setupModel = data.SaveSetup(setupModel);

        //            var runModel = new TrackSessionRunModel()
        //            {
        //                SetupId = setupModel.SetupId,
        //                TelemetryId = telemetryModel.TelemetryId,
        //                TrackSessionId = sessionModel.TrackSessionId
        //            };
        //            runModel = data.SaveSessionRun(runModel);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler(ex);
        //    }
        //    finally
        //    {
        //        ResetRunState();
        //    }
        //}

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
        //private TrackSessionModel GetTrackSessionModel(SeasonModel season, VehicleModel vehicle, TrackModel track, SessionTypeModel sessionType, TelemetrySession telemetrySession)
        //{
        //    var model = new TrackSessionModel()
        //    {
        //        Season = season,
        //        SessionType = sessionType,
        //        Track = track,
        //        Vehicle = vehicle,
        //        Timestamp = telemetrySession.Timestamp,
        //        TrackTemp = telemetrySession.TelemetrySessionInfo.WeekendInfo.TrackSurfaceTemp,
        //        AirTemp = telemetrySession.TelemetrySessionInfo.WeekendInfo.TrackAirTemp,
        //        Skies = telemetrySession.TelemetrySessionInfo.WeekendInfo.TrackSkies,
        //        Night = (telemetrySession.TelemetrySessionInfo.WeekendInfo.WeekendOptions.NightMode.Trim() == "1"),
        //        Humidity = Convert.ToSingle(telemetrySession.TelemetrySessionInfo.WeekendInfo.TrackRelativeHumidity)
        //    };
        //    return model;
        //}

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
        //private SetupModel GetSetupModel(TelemetrySession telemetry)
        //{
        //    var model = new SetupModel()
        //    {
        //        Name = telemetry.TelemetrySessionInfo.DriverInfo.DriverSetupName,
        //        VehicleNumber = Convert.ToInt32(telemetry.TelemetrySessionInfo.DriverInfo.CurrentDriver().CarID),
        //        SetupJSON = telemetry.TelemetrySessionInfo.SetupJSON,
        //        SetupBinary = GetSetupBinary(telemetry.TelemetrySessionInfo.DriverInfo.CurrentDriver().CarPath)
        //    };
        //    return model;
        //}
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
                _engine.TelemetryFileOpened -= _engine_TelemetryFileOpened;
                _engine.TelemetryFileClosed -= _engine_TelemetryFileClosed;
                _engine = null;
            }
        }
        #endregion
    }
}
