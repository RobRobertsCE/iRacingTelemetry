using iRacing.SetupLibrary.Tires;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

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
        public int LapCount { get; set; }

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
                if (!String.IsNullOrEmpty(_tireSheetJson))
                {
                    TireSheet = (TireSheet)JsonConvert.DeserializeObject(_tireSheetJson, typeof(TireSheet),
                                                          new JsonSerializerSettings()
                                                          { TypeNameHandling = TypeNameHandling.All });
                }
            }
        }

        private string _lapsJson;
        public string LapsJson
        {
            get
            {
                if (null != Laps)
                {
                    _lapsJson = Laps.ToJson();
                }
                return _lapsJson;
            }
            set
            {
                _lapsJson = value;
                if (!String.IsNullOrEmpty(_lapsJson))
                {
                    Laps = (LapTimes)JsonConvert.DeserializeObject(_lapsJson, typeof(LapTimes),
                                                          new JsonSerializerSettings()
                                                          { TypeNameHandling = TypeNameHandling.All });
                }
            }
        }

        [NotMapped]
        public TireSheet TireSheet { get; set; }
        [NotMapped]
        public LapTimes Laps { get; set; }

        public TrackSessionRunModel()
        {
            Laps = new LapTimes();
        }

    }
}
