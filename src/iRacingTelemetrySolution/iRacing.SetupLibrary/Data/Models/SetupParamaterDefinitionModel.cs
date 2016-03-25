using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.SetupLibrary.Data.Models
{
    [Table(" SetupParameterDefinition")]
    public class SetupParameterDefinitionModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SetupParameterDefinitionId { get; set; }
        [ForeignKey("SubGroup")]
        public Guid SetupParameterSubGroupId { get; set; }
        [Required, MaxLength(50)]
        public string DisplayName { get; set; }
        [Required, MaxLength(50)]
        public string Key { get; set; }
        [Required()]
        public int DisplayIdx { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleNumber { get; set; }
        [MaxLength(50)]
        public string DataType { get; set; }
        [MaxLength(16)]
        public string Suffix { get; set; }
        public bool Translate { get; set; }

        public VehicleModel Vehicle { get; set; }
        public SetupParameterSubGroupModel SubGroup { get; set; }

        public SetupParameterDefinitionModel()
        {
           
        }
    }
}
