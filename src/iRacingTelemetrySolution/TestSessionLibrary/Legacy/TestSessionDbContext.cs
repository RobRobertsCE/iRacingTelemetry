using System.Data.Entity;
using TestSessionLibrary.Data.Models;

namespace TestSessionLibrary.Data
{
    public class TestSessionDbContext : DbContext
    {
        public DbSet<TestSessionRunModel> Runs { get; set; }
        public DbSet<ModifiedSetupModel> Modifieds { get; set; }
        public DbSet<TrackModel> Tracks { get; set; }
        public DbSet<CarModel> Cars { get; set; }

        public TestSessionDbContext()
            : base("TestSessionDb")
        {

        }
    }
}
