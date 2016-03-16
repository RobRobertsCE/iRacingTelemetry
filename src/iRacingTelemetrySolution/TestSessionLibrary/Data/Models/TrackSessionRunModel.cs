using iRacing.SetupLibrary.Tires;
using Newtonsoft.Json;
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

        private string _tireSheetJson;
        public string TireSheetJson
        {
            get
            {
                if (null!= TireSheet)
                {
                    _tireSheetJson = TireSheet.ToJson();
                }
                return _tireSheetJson;
            }
            set
            {
                _tireSheetJson = value;
                TireSheet = (TireSheet)JsonConvert.DeserializeObject(_tireSheetJson, typeof(TireSheet),
                                                      new JsonSerializerSettings()
                                                      { TypeNameHandling = TypeNameHandling.All });
            }
        }

        [NotMapped]
        public TireSheet TireSheet { get; set; }
    }
}
