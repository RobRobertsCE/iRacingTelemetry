using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.TrackSession.Data.Models
{
    [Table("Season")]
    public class SeasonModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SeasonId { get; set; }
        [Required, MaxLength(16)]
        public string Name { get; set; }
        [Required()]
        public int Year { get; set; }
        [Required()]
        public int Quarter { get; set; }
        [Required()]
        public bool Current { get; set; }
    }
}
