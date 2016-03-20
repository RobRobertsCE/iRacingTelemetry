using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.TrackSession.Data.Models
{
    [Table("Track")]
    public class TrackModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrackNumber { get; set; }
        [Required()]
        public string Name { get; set; }
        [Required()]
        public double Length { get; set; }
    }
}
