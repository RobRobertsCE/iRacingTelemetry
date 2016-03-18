using iRacing.SetupLibrary.Tires;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSessionLibrary.Data.Models
{
    [Table("TrackSessionRun")]
    public class TrackSessionRunModel
    {
        #region properties
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
        public int LapCount { get; set; }

        // relationships //
        public SetupModel Setup { get; set; }
        public TelemetryModel Telemetry { get; set; }
        public TrackSessionModel TrackSession { get; set; }

        public string TireSheetJson { get; set; }
        public string LapsJson { get; set; }
        #endregion

        #region ctor
        public TrackSessionRunModel()
        {
            
        }
        #endregion
    }
}
