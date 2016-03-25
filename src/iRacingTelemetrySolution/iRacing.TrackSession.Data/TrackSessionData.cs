using System;
using System.Collections.Generic;
using System.Linq;
using iRacing.TrackSession.Data.Models;
using System.Data.Entity;

namespace iRacing.TrackSession.Data
{
    public class TrackSessionData : IDisposable
    {
        #region properties
        private iRacingDbContext _context;
        public iRacingDbContext Context
        {
            get
            {
                if (null == _context)
                    _context = new iRacingDbContext();

                return _context;
            }
            set
            {
                _context = value;
            }
        }
        #endregion

        #region telemetry
        public virtual TelemetryModel SaveTelemetry(TelemetryModel telemetry)
        {
            if (Guid.Empty == telemetry.TelemetryId)
            {
                Context.Telemetry.Add(telemetry);
            }
            else
            {
                Context.Telemetry.Attach(telemetry);
                Context.Entry(telemetry).State = EntityState.Modified;
            }
            Context.SaveChanges();
            return telemetry;
        }
        public virtual TelemetryModel GetTelemetry(Guid telemetryId)
        {
            return Context.Telemetry.FirstOrDefault(t => t.TelemetryId == telemetryId);
        }
        public virtual IList<Guid> GetTelemetryIdList()
        {
            using (var context = new iRacingTelemetryViewDbContext())
            {
                return context.TelemetrySessionInfo.Where(t => String.IsNullOrEmpty(t.YamlData)).Select(t => t.TelemetryId).ToList();
            }
                
        }
        public virtual IList<TelemetrySessionInfoView> GetTelemetryViews()
        {
            using (var context = new iRacingTelemetryViewDbContext())
            {
                return context.TelemetrySessionInfo.ToList();
            }

        }
        public virtual void SaveTelemetryView(TelemetrySessionInfoView model)
        {
            using (var context = new iRacingTelemetryViewDbContext())
            {
                context.TelemetrySessionInfo.Attach(model);
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
         
        }
        public virtual IList<string> GetArchivedTelemetry()
        {
            return Context.Telemetry.Select(t => t.TelemetryDiskFile).ToList();
        }
        public virtual string GetTelemetryYaml(Guid telemetryId)
        {
            return Context.Telemetry.FirstOrDefault(t => t.TelemetryId == telemetryId).YamlData;
        }
        #endregion

        #region season
        public virtual SeasonModel GetSeason(DateTime dateStamp)
        {
            var quarter = (dateStamp.Month / 3 + 1);
            var model = Context.Seasons.FirstOrDefault(s => s.Year == dateStamp.Year && s.Quarter == quarter);
            if (null == model)
            {
                model = new SeasonModel()
                {
                    Year = dateStamp.Year,
                    Quarter = quarter,
                    Name = String.Format("{0}S{1}", dateStamp.Year, quarter),
                    Current = false
                };
                Context.Seasons.Add(model);
                Context.SaveChanges();
            }
            return model;
        }
        #endregion

        #region vehicle
        public virtual VehicleModel GetVehicle(int vehicleNumber, string vehicleName, string path, string screenName)
        {
            var model = Context.Vehicles.FirstOrDefault(v => v.VehicleNumber == vehicleNumber && v.Name == vehicleName && v.Path == path && v.DisplayName == screenName);
            if (null == model)
            {
                model = new VehicleModel()
                {
                    Name = vehicleName,
                    VehicleNumber = vehicleNumber,
                    Path = path,
                    DisplayName = screenName
                };
                Context.Vehicles.Add(model);
                Context.SaveChanges();
            }
            return model;
        }
        public virtual VehicleModel GetVehicle(int vehicleNumber)
        {
            return Context.Vehicles.FirstOrDefault(v => v.VehicleNumber == vehicleNumber);
        }
        public virtual IList<VehicleModel> GetVehicles()
        {
            return Context.Vehicles.ToList();
        }
        public virtual VehicleModel SaveVehicle(VehicleModel model)
        {
            try
            {
                if (Context.Vehicles.Any(v => v.VehicleNumber == model.VehicleNumber))
                {
                    Context.Vehicles.Attach(model);
                    Context.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    Context.Vehicles.Add(model);
                }

                Context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
        #endregion

        #region track
        public virtual TrackModel GetTrack(int trackNumber, string trackName, double length)
        {
            var model = Context.Tracks.FirstOrDefault(v => v.TrackNumber == trackNumber);
            if (null == model)
            {
                model = new TrackModel()
                {
                    Name = trackName,
                    TrackNumber = trackNumber,
                    Length = length
                };
                Context.Tracks.Add(model);
                Context.SaveChanges();
            }
            return model;
        }
        public virtual IList<TrackModel> GetTracks()
        {
            return Context.Tracks.ToList();
        }
        #endregion

        #region sessionType
        public virtual SessionTypeModel GetSessionType(string name)
        {
            var model = Context.SessionTypes.FirstOrDefault(s => s.Name == name);
            if (null == model)
            {
                model = new SessionTypeModel()
                {
                    Name = name
                };
                Context.SessionTypes.Add(model);
                Context.SaveChanges();
            }
            return model;
        }
        #endregion

        #region session
        public virtual TrackSessionModel SaveTrackSession(TrackSessionModel session)
        {
            Context.Sessions.Add(session);

            Context.SaveChanges();

            return session;
        }
        public virtual TrackSessionModel GetTrackSession(Guid trackSessionId)
        {
            return Context.Sessions.Include("Vehicle").Include("Track").Include("SessionType").Include("Runs").Include("Runs.Telemetry").FirstOrDefault(s => s.TrackSessionId == trackSessionId);
        }
        public virtual IList<TrackSessionModel> GetTrackSessions(int carId, int trackId)
        {
            return Context.Sessions.Include("Vehicle").Include("Track").Include("SessionType").Include("Runs").Where(s => (carId == 0 || carId == s.VehicleNumber) && (trackId == 0 || trackId == s.TrackNumber) && s.Runs.Count > 0).ToList();
        }
        #endregion

        #region session run
        public virtual TrackSessionRunModel SaveTrackSessionRun(TrackSessionRunModel run)
        {
            if (Guid.Empty == run.TrackSessionRunId)
            {
                var sessionRuns = Context.Sessions.Where(s => s.TrackSessionId == run.TrackSessionId).FirstOrDefault();
                if (sessionRuns == null)
                {
                    run.RunNumber = 1;
                }
                else
                {
                    run.RunNumber = sessionRuns.Runs.Count + 1;
                }
                Context.Runs.Add(run);
            }
            else
                Context.Runs.Attach(run);

            Context.SaveChanges();

            return run;
        }
        public virtual TrackSessionRunModel GetTrackSessionRun(Guid trackSessionRunId)
        {
            return Context.Runs.Include("TrackSession").Include("TrackSession.SessionType").Include("TrackSession.Vehicle").Include("TrackSession.Track").Include("Setup").Include("Telemetry").FirstOrDefault(s => s.TrackSessionRunId == trackSessionRunId);
        }
        public virtual IList<TrackSessionRunModel> GetTrackSessionRuns()
        {
            return Context.Runs
                .Include("TrackSession")
                .Include("TrackSession.SessionType")
                .Include("TrackSession.Vehicle")
                .Include("TrackSession.Track")
                .Include("Setup")
                .Include("Telemetry")
                .ToList();
        }
        public virtual TrackSessionRunModel SetTrackSessionRunTireSheet(Guid trackSessionRunId, string tireSheetJson)
        {
            var runModel = GetTrackSessionRun(trackSessionRunId);
            runModel.TireSheetJson = tireSheetJson;
            Context.SaveChanges();
            return runModel;
        }
        #endregion

        #region setup
        public virtual SetupModel SaveSetup(SetupModel setup)
        {
            if (Guid.Empty == setup.SetupId)
            {
                Context.Setups.Add(setup);
            }
            else
            {
                Context.Setups.Attach(setup);
            }


            Context.SaveChanges();

            return setup;
        }
        public virtual SetupModel GetSetup(Guid setupId)
        {
            return Context.Setups.FirstOrDefault(s => s.SetupId == setupId);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Context.Dispose();
        }
        #endregion
    }
}
