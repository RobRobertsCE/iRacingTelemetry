using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSessionLibrary.Data.Models
{
    [Table("Vehicle")]
    public class VehicleModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VehicleNumber { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Path { get; set; }
        [Required, MaxLength(50)]
        public string DisplayName { get; set; }
    }
}
