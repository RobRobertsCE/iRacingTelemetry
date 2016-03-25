using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupParameterLibrary
{
    public class VehicleSetupDefinition
    {
        #region properties
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Notes { get; set; }
        public IList<SetupGroup> SetupGroups { get; set; }
        #endregion

        #region ctor
        public VehicleSetupDefinition()
        {
            SetupGroups = new List<SetupGroup>();
        }
        #endregion
    }
}
