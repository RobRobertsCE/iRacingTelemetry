using System;
using System.Collections.Generic;
using System.Linq;
using TestSessionLibrary.Data.Models;

namespace TestSessionLibrary.Data
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
            var existing = Context.Telemetry.FirstOrDefault(t => t.TelemetryDiskFile == telemetry.TelemetryDiskFile);
            if (null != existing)
                return existing;

            if (Guid.Empty == telemetry.TelemetryId)
            {
                Context.Telemetry.Add(telemetry);
            }
            else
                Context.Telemetry.Attach(telemetry);

            Context.SaveChanges();

            return telemetry;
        }
        public virtual TelemetryModel GetTelemetry(Guid telemetryId)
        {
            return Context.Telemetry.FirstOrDefault(t => t.TelemetryId == telemetryId);
        }
        public virtual IList<string> GetArchivedTelemetry()
        {
            return Context.Telemetry.Select(t => t.TelemetryDiskFile).ToList();
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
            return Context.Sessions.Include("Vehicle").Include("Track").Include("Runs").Include("Runs.Telemetry").FirstOrDefault(s => s.TrackSessionId == trackSessionId);
        }
        #endregion

        #region session run
        public virtual TrackSessionRunModel SaveTrackSessionRun(TrackSessionRunModel run)
        {
            if (Guid.Empty == run.TrackSessionRunId)
            {
                Context.Runs.Add(run);
            }
            else
                Context.Runs.Attach(run);

            Context.SaveChanges();

            return run;
        }
        public virtual TrackSessionRunModel GetTrackSessionRun(Guid trackSessionRunId)
        {
            return Context.Runs.Include("TrackSession").Include("TrackSession.Vehicle").Include("TrackSession.Track").Include("Telemetry").FirstOrDefault(s => s.TrackSessionRunId == trackSessionRunId);
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
        #endregion

        #region setup
        public virtual TrackSessionRunModel SaveSessionRun(TrackSessionRunModel run)
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
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Context.Dispose();
        }
        #endregion
    }
}
