using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSessionLibrary.Data
{
    [Table("Car")]
    public class CarModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarNumber { get; set; }
        [Required()]
        public string Name { get; set; }
        [Required()]
        public string Path { get; set; }
        [Required()]
        public string DisplayName { get; set; }
    }
}
