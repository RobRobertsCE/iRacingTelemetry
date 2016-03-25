using SetupParameterLibrary.Data.Models;
using System;
using System.Collections.Generic;

namespace SetupParameterLibrary
{
    public class SetupSubGroup : ISetupSubGroup
    {
        #region properties
        public virtual Guid SetupSubGroupId { get; set; }
        public virtual Guid SetupGroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Key { get; set; }
        public virtual int DisplayIndex { get; set; }
        public IList<SetupParameter> SetupParameters { get; set; }
        #endregion

        #region ctor
        public SetupSubGroup()
        {
            SetupParameters = new List<SetupParameter>();
        }
        internal SetupSubGroup(SetupSubGroupModel model) : this()
        {
            this.SetupSubGroupId = model.SetupSubGroupId;
            this.SetupGroupId = model.SetupGroupId;
            this.Name = model.Name;
            this.Key = model.Key;
            this.DisplayIndex = model.DisplayIndex;
            foreach (var parameterModel in model.Parameters )
            {
                SetupParameters.Add(new SetupParameter(parameterModel));
            }
        }
        #endregion

        #region internal
        internal SetupSubGroupModel ToModel()
        {
            var model = new SetupSubGroupModel();
            model.SetupSubGroupId = this.SetupSubGroupId;
            model.SetupGroupId = this.SetupGroupId;
            model.Name = this.Name;
            model.Key = this.Key;
            model.DisplayIndex = this.DisplayIndex;
            foreach (var parameter in this.SetupParameters)
            {
                model.Parameters.Add(parameter.ToModel());
            }
            return model;
        }
        #endregion
    }
}
