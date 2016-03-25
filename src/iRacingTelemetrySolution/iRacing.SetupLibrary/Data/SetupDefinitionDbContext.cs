using iRacing.SetupLibrary.Data.Models;
using System.Data.Entity;

namespace iRacing.SetupLibrary.Data
{
    public class SetupDefinitionDbContext : DbContext
    {
        public DbSet<SetupParameterGroupModel> Groups { get; set; }
        public DbSet<SetupParameterSubGroupModel> SubGroups { get; set; }
        public DbSet<SetupParameterDefinitionModel> Definitions { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }

        public SetupDefinitionDbContext()
            : base("TestSessionDb")
        {

        }
    }
}
