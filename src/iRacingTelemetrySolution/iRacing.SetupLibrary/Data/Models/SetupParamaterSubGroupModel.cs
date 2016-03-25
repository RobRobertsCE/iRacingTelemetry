using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.SetupLibrary.Data.Models
{
    [Table("SetupParameterSubGroup")]
    public class SetupParameterSubGroupModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SetupParameterSubGroupId { get; set; }
        [ForeignKey("Group")]
        public Guid SetupParameterGroupId { get; set; }
        [Required, MaxLength(50)]
        public string DisplayName { get; set; }
        [Required, MaxLength(50)]
        public string Key { get; set; }
        [Required()]
        public int DisplayIdx { get; set; }
        public SetupParameterGroupModel Group { get; set; }
        public IList<SetupParameterDefinitionModel> Definitions { get; set; }

        public SetupParameterSubGroupModel()
        {
            Definitions = new List<SetupParameterDefinitionModel>();
        }
    }
}
