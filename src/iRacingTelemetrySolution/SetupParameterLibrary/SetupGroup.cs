using SetupParameterLibrary.Data.Models;
using System;
using System.Collections.Generic;

namespace SetupParameterLibrary
{
    public class SetupGroup : ISetupGroup
    {
        #region properties
        public virtual Guid SetupGroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Key { get; set; }
        public virtual int DisplayIndex { get; set; }
        public IList<SetupSubGroup> SetupSubGroups { get; set; }
        #endregion

        #region ctor
        public SetupGroup()
        {
            SetupSubGroups = new List<SetupSubGroup>();
        }

        internal SetupGroup(SetupGroupModel model) : this()
        {
            this.SetupGroupId = model.SetupGroupId;
            this.Name = model.Name;
            this.Key = model.Key;
            this.DisplayIndex = model.DisplayIndex;
            foreach (var subGroupModel in model.SubGroups )
            {
                SetupSubGroups.Add(new SetupSubGroup(subGroupModel));
            }
        }
        #endregion

        #region internal
        internal SetupGroupModel ToModel()
        {
            var model = new SetupGroupModel();
            model.SetupGroupId = this.SetupGroupId;
            model.Name = this.Name;
            model.Key = this.Key;
            model.DisplayIndex = this.DisplayIndex;
            foreach (var subGroup in this.SetupSubGroups)
            {
                model.SubGroups.Add(subGroup.ToModel());
            }
            return model;
        }
        #endregion
    }
}
