using iRacing.SetupLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.SetupLibrary.Data
{
    public class SetupDefinitionData
    {
        #region properties
        private SetupDefinitionDbContext _context;
        public SetupDefinitionDbContext Context
        {
            get
            {
                if (null == _context)
                    _context = new SetupDefinitionDbContext();

                return _context;
            }
            set
            {
                _context = value;
            }
        }
        #endregion

        public virtual IList<SetupParameterDefinitionModel> GetVehicleDefinitions(int vehicleNumber)
        {
            return Context.Definitions.Include("SubGroup").Include("SubGroup.Group").Include("Vehicle").Where(d => d.VehicleNumber == vehicleNumber).ToList();
        }
        public virtual IList<SetupParameterDefinitionModel> GetDefinitions()
        {
            return Context.Definitions.Include("SubGroup").Include("SubGroup.Group").Include("Vehicle").ToList();
        }
        public virtual SetupParameterDefinitionModel GetDefinition(Guid Id)
        {
            return Context.Definitions.Include("SubGroup").Include("SubGroup.Group").Include("Vehicle").FirstOrDefault(s => s.SetupParameterDefinitionId == Id);
        }

        public virtual IList<SetupParameterSubGroupModel> GetSubGroups()
        {
            return Context.SubGroups.Include("Group").ToList();
        }
        public virtual SetupParameterSubGroupModel GetSubGroup(Guid Id)
        {
            return Context.SubGroups.Include("Group").FirstOrDefault(s => s.SetupParameterSubGroupId == Id);
        }

        public virtual IList<SetupParameterGroupModel> GetGroups()
        {
            return Context.Groups.Include("SubGroups").ToList();
        }
        public virtual SetupParameterGroupModel GetGroup(Guid Id)
        {
            return Context.Groups.Include("SubGroups").FirstOrDefault(s => s.SetupParameterGroupId == Id);
        }

        public virtual IList<VehicleModel> GetVehicles()
        {
            return Context.Vehicles.ToList();
        }
        public virtual VehicleModel GetVehicle(int vehicleNumber)
        {
            return Context.Vehicles.FirstOrDefault(v => v.VehicleNumber == vehicleNumber);
        }
    }
}
