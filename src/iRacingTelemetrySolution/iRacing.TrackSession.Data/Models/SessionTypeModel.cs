using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.TrackSession.Data.Models
{
    [Table("SessionType")]
    public class SessionTypeModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SessionTypeId { get; set; }
        [Required, MaxLength(16)]
        public string Name { get; set; }
    }
}
