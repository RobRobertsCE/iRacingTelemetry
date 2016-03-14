using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSessionLibrary.Data.Models
{
    [Table("Telemetry")]
    public class TelemetryModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TelemetryId { get; set; }
        public string TelemetryDiskFile { get; set; }
        [Required]
        public byte[] BinaryData { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
