using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetupParameterLibrary.Data.Models
{
    [Table("SetupGroup")]
    class SetupGroupModel
    {
        #region properties
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid SetupGroupId { get; set; }
        [Required, MaxLength(50)]
        public virtual string Name { get; set; }
        [Required, MaxLength(50)]
        public virtual string Key { get; set; }
        [Required()]
        public virtual int DisplayIndex { get; set; }
        public IList<SetupSubGroupModel> SubGroups { get; set; }
        #endregion

        #region ctor
        public SetupGroupModel()
        {
            SubGroups = new List<SetupSubGroupModel>();
        }
        #endregion
    }
}
