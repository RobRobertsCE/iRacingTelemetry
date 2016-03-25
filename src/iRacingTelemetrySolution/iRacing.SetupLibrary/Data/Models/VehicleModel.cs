using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.SetupLibrary.Data.Models
{
    [Table("Vehicle")]
    public class VehicleModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VehicleNumber { get; set; }
        [Required, MaxLength(50)]
        public string DisplayName { get; set; }
        [MaxLength(50)]
        public string ClassName { get; set; }
        public int CarClassId { get; set; }
        [MaxLength(50)]
        public string CarClassShortName { get; set; }
        public IList<SetupParameterDefinitionModel> Definitions { get; set; }

        public VehicleModel()
        {
            Definitions = new List<SetupParameterDefinitionModel>();
        }
    }
}
