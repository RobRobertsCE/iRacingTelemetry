using SetupParameterLibrary.Data.Models;
using System.Data.Entity;

namespace SetupParameterLibrary.Data
{
    class SetupDbContext
        : DbContext
    {
        #region consts
        public const string DefaultConnectionName = "iRacingSetupConnection";
        #endregion

        #region properties
        public virtual DbSet<SetupGroupModel> Groups { get; set; }
        public virtual DbSet<SetupSubGroupModel> SubGroups { get; set; }
        public virtual DbSet<SetupParameterModel> Parameters { get; set; }
        public virtual DbSet<VehicleModel> Vehicles { get; set; }
        public virtual DbSet<VehicleSetupParameterModel> VehicleSetupParameters { get; set; }
        #endregion

        #region ctor
        public SetupDbContext() 
            : this(DefaultConnectionName)
        {  }
        public SetupDbContext(string connectionName) 
            : base(connectionName)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        #endregion
    }
}
