using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.SetupLibrary.Data.Models
{
    [Table("SetupParameterGroup")]
    public class SetupParameterGroupModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SetupParameterGroupId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required()]
        public int DisplayIdx { get; set; }
        public IList<SetupParameterSubGroupModel> SubGroups { get; set; }

        public SetupParameterGroupModel()
        {
            SubGroups = new List<SetupParameterSubGroupModel>();
        }
    }
}
