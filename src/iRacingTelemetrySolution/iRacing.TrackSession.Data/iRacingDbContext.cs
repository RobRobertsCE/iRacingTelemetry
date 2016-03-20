using System.Data.Entity;
using iRacing.TrackSession.Data.Models;

namespace iRacing.TrackSession.Data
{
    public class iRacingDbContext : DbContext
    {
        public DbSet<TrackSessionModel> Sessions { get; set; }
        public DbSet<TrackSessionRunModel> Runs { get; set; }
        public DbSet<SetupModel> Setups { get; set; }
        public DbSet<TrackModel> Tracks { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<SessionTypeModel> SessionTypes { get; set; }
        public DbSet<TelemetryModel> Telemetry { get; set; }
        public DbSet<SeasonModel> Seasons { get; set; }

        public iRacingDbContext()
            : base("TestSessionDb")
        {

        }
    }
}
