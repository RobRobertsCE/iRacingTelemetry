using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.TrackSession.Data.Models
{
    [Table("Telemetry")]
    public class TelemetrySessionInfoView
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TelemetryId { get; set; }
        public string YamlData { get; set; }
    }
}
