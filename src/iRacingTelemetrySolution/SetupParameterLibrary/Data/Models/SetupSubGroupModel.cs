using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetupParameterLibrary.Data.Models
{
    [Table("SetupSubGroup")]
    class SetupSubGroupModel
    {
        #region properties
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid SetupSubGroupId { get; set; }
        [ForeignKey("Group")]
        public virtual Guid SetupGroupId { get; set; }
        [Required, MaxLength(50)]
        public virtual string Name { get; set; }
        [Required, MaxLength(50)]
        public virtual string Key { get; set; }
        [Required()]
        public virtual int DisplayIndex { get; set; }
        public virtual SetupGroupModel Group { get; set; }
        public virtual IList<SetupParameterModel> Parameters { get; set; }
        #endregion

        #region ctor
        public SetupSubGroupModel()
        {
            Parameters = new List<SetupParameterModel>();
        }
        #endregion
    }
}
