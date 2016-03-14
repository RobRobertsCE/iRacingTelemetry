using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestSessionLibrary.Data.Models;

namespace TestSessionLibrary.Data
{
    [Table("ModifiedSetup")]
    public class ModifiedSetupModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ModifiedSetupId { get; set; }
        [Required()]
        public string Name { get; set; }
        [NotMapped]
        public string TrackName { get; set; }
        [NotMapped]
        public string CarName { get; set; }
        [Required(), ForeignKey("Track")]
        public int TrackNumber { get; set; }
        [Required(), ForeignKey("Car")]
        public int CarNumber { get; set; }
        [Required()]
        public int BallastForward { get; set; }
        [Required()]
        public double FrontWeightPercent { get; set; }
        [Required()]
        public double CrossWeightPercent { get; set; }
        [Required()]
        public double ToeIn { get; set; }
        [Required()]
        public int SteerRatio { get; set; }
        [Required()]
        public double FtBrakeBias { get; set; }
        [Required()]
        public double SwayBarSize { get; set; }
        [Required()]
        public int SwayBarArm { get; set; }
        [Required()]
        public double SwayBarLeftClearance { get; set; }
        [Required()]
        public bool SwayBarLeftAttached { get; set; }
        [Required()]
        public double FuelLevel { get; set; }
        [Required()]
        public double FinalGearRatio { get; set; }
        [Required()]
        public double TrackBarLeft { get; set; }
        [Required()]
        public double TrackBarRight { get; set; }
        
        [Required()]
        public double LFCamber { get; set; }
        [Required()]
        public double LFCaster { get; set; }
        [Required()]
        public double LFRideHeight { get; set; }
        [Required()]
        public int LFSpringRate { get; set; }
        [Required()]
        public double LFPSICold { get; set; }
        [Required()]
        public int LFStaticLoad { get; set; }
        [Required()]
        public double LFShockCollarOffset { get; set; }

        [Required()]
        public double RFCamber { get; set; }
        [Required()]
        public double RFCaster { get; set; }
        [Required()]
        public double RFRideHeight { get; set; }
        [Required()]
        public int RFSpringRate { get; set; }
        [Required()]
        public double RFPSICold { get; set; }
        [Required()]
        public int RFStaticLoad { get; set; }
        [Required()]
        public double RFShockCollarOffset { get; set; }
                       
        [Required()]
        public double RRRideHeight { get; set; }
        [Required()]
        public int RRSpringRate { get; set; }
        [Required()]
        public double RRPSICold { get; set; }
        [Required()]
        public int RRStaticLoad { get; set; }
        [Required()]
        public double RRShockCollarOffset { get; set; }

        [Required()]
        public double LRRideHeight { get; set; }
        [Required()]
        public int LRSpringRate { get; set; }
        [Required()]
        public double LRPSICold { get; set; }
        [Required()]
        public int LRStaticLoad { get; set; }
        [Required()]
        public double LRShockCollarOffset { get; set; }
        
        [Required()]
        public int LFBump { get; set; }
        [Required()]
        public int LFRebound { get; set; }
        [Required()]
        public int LRBump { get; set; }
        [Required()]
        public int LRRebound { get; set; }
        [Required()]
        public int RFBump { get; set; }
        [Required()]
        public int RFRebound { get; set; }
        [Required()]
        public int RRBump { get; set; }
        [Required()]
        public int RRRebound { get; set; }

        public string Notes { get; set; }

        public CarModel Car { get; set; }
        public TrackModel Track { get; set; }
    }
}
