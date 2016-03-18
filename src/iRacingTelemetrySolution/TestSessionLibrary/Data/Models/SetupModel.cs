using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSessionLibrary.Data.Models
{
    [Table("Setup")]
    public class SetupModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SetupId { get; set; }
        public string Name { get; set; }
        public int VehicleNumber { get; set; }
        public byte[] SetupBinary { get; set; }
        public string SetupJSON { get; set; }
    }
}
