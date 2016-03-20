using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iRacing.TrackSession.Data.Models
{
    [Table("TrackSession")]
    public class TrackSessionModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TrackSessionId { get; set; }
        [ForeignKey("Season")]
        public Guid SeasonId { get; set; }
        [ForeignKey("SessionType")]
        public Guid SessionTypeId { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleNumber { get; set; }
        [ForeignKey("Track")]
        public int TrackNumber { get; set; }
        [Required()]
        public DateTime Timestamp { get; set; }
        public string Notes { get; set; }

        // weather //
        public string TrackTemp { get; set; }
        public string AirTemp { get; set; }
        public string Skies { get; set; }
        public bool Night { get; set; }
        public float Humidity { get; set; }
        public float Barometer { get; set; }

        // relationships //
        public SeasonModel Season { get; set; }
        public SessionTypeModel SessionType { get; set; }
        public VehicleModel Vehicle { get; set; }
        public TrackModel Track { get; set; }

        public IList<TrackSessionRunModel> Runs { get; set; }

        public TrackSessionModel()
        {
            Runs = new List<TrackSessionRunModel>();
        }

    }  
}
