using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetupParameterLibrary.Data.Models
{
    [Table("SetupParameter")]
    class SetupParameterModel
    {
        #region properties
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid SetupParameterId { get; set; }
        [ForeignKey("SubGroup")]
        public virtual Guid SetupSubGroupId { get; set; }
        [Required, MaxLength(50)]
        public virtual string Name { get; set; }
        [Required, MaxLength(50)]
        public virtual string Key { get; set; }
        [Required()]
        public virtual int DisplayIndex { get; set; }
        [Required, MaxLength(16)]
        public virtual string OriginalSuffix { get; set; }
        [Required, MaxLength(16)]
        public virtual string TranslatedSuffix { get; set; }
        public virtual bool IsTranslatable { get; set; }
        public virtual SetupSubGroupModel SubGroup { get; set; }
        #endregion

        #region ctor
        public SetupParameterModel()
        {

        }
        #endregion
    }
}
