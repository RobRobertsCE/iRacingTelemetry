using SetupParameterLibrary.Data.Models;
using System;

namespace SetupParameterLibrary
{
    public class SetupParameter : ISetupParameter
    {
        #region properties
        public virtual Guid SetupParameterId { get; set; }
        public virtual Guid SetupSubGroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Key { get; set; }
        public virtual int DisplayIndex { get; set; }
        public virtual string OriginalSuffix { get; set; }
        public virtual string TranslatedSuffix { get; set; }
        public virtual bool IsTranslatable { get; set; }
        #endregion

        #region ctor
        internal SetupParameter()
        {

        }
        internal SetupParameter(SetupParameterModel model)
        {
            this.SetupParameterId = model.SetupParameterId;
            this.SetupSubGroupId = model.SetupSubGroupId;
            this.Name = model.Name;
            this.Key = model.Key;
            this.DisplayIndex = model.DisplayIndex;
            this.OriginalSuffix = model.OriginalSuffix;
            this.TranslatedSuffix = model.TranslatedSuffix;
            this.IsTranslatable = model.IsTranslatable;
        }
        #endregion

        #region internal
        internal SetupParameterModel ToModel()
        {
            var model = new SetupParameterModel();
            model.SetupParameterId = this.SetupParameterId;
            model.SetupSubGroupId = this.SetupSubGroupId;
            model.Name = this.Name;
            model.Key = this.Key;
            model.DisplayIndex = this.DisplayIndex;
            model.OriginalSuffix = this.OriginalSuffix;
            model.TranslatedSuffix = this.TranslatedSuffix;
            model.IsTranslatable = this.IsTranslatable;            
            return model;
        }
        #endregion
    }
}
