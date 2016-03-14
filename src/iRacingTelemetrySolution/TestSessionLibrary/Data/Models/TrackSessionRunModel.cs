using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSessionLibrary.Data.Models
{
    [Table("TrackSessionRun")]
    public class TrackSessionRunModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TrackSessionRunId { get; set; }

        [Required()]
        public int RunNumber { get; set; }
        
        // session //
        [ForeignKey("TrackSession")]
        public Guid TrackSessionId { get; set; }

        // setup //
        [ForeignKey("Setup")]
        public Guid SetupId { get; set; }

        // telemetry //
        [ForeignKey("Telemetry")]
        public Guid TelemetryId { get; set; }

        // relationships //
        public SetupModel Setup { get; set; }
        public TelemetryModel Telemetry { get; set; }
        public TrackSessionModel TrackSession { get; set; }
    }
}
