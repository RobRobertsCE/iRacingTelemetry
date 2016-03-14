using ibtParserLibrary.Session.Info;
using Newtonsoft.Json;

namespace ibtParserLibrary.Session.Cars
{
    public class SSTelemetryData : TelemetrySessionInfo, ISetupTelemetryData
    {
        [JsonProperty("CarSetup")]
        public StreetStockSetup CarSetup { get; set; }
    }

    public class StreetStockSetup
    {
        [JsonProperty("UpdateCount")]
        public int UpdateCount { get; set; }
        [JsonProperty("Tires")]
        public SetupTires Tires { get; set; }
        [JsonProperty("Chassis")]
        public SetupChassis Chassis { get; set; }

        public class SetupTires
        {
            [JsonProperty("LeftFront")]
            public TiresLeftFront LeftFront { get; set; }
            [JsonProperty("LeftRear")]
            public TiresLeftRear LeftRear { get; set; }
            [JsonProperty("RightFront")]
            public TiresRightFront RightFront { get; set; }
            [JsonProperty("RightRear")]
            public TiresRightRear RightRear { get; set; }

            public class TiresLeftFront
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsOMI")]
                public string LastTempsOMI { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
            }
            public class TiresLeftRear
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsOMI")]
                public string LastTempsOMI { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
            }
            public class TiresRightFront
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsIMO")]
                public string LastTempsIMO { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
                [JsonProperty("Stagger")]
                public string Stagger { get; set; }
            }
            public class TiresRightRear
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsIMO")]
                public string LastTempsIMO { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
                [JsonProperty("Stagger")]
                public string Stagger { get; set; }
            }
        }
        public class SetupChassis
        {
            [JsonProperty("Front")]
            public ChassisFront Front { get; set; }
            [JsonProperty("LeftFront")]
            public ChassisLeftFront LeftFront { get; set; }
            [JsonProperty("LeftRear")]
            public ChassisLeftRear LeftRear { get; set; }
            [JsonProperty("RightFront")]
            public ChassisRightFront RightFront { get; set; }
            [JsonProperty("RightRear")]
            public ChassisRightRear RightRear { get; set; }
            [JsonProperty("Rear")]
            public ChassisRear Rear { get; set; }
            
            public class ChassisFront
            {
                [JsonProperty("CrossWeight")]
                public string CrossWeight { get; set; }
                [JsonProperty("ToeIn")]
                public string ToeIn { get; set; }
                [JsonProperty("SteeringRatio")]
                public string SteeringRatio { get; set; }
                [JsonProperty("SteeringOffset")]
                public string SteeringOffset { get; set; }
                [JsonProperty("FrontBrakeBias")]
                public string FrontBrakeBias { get; set; }
                [JsonProperty("SwayBarSize")]
                public string SwayBarSize { get; set; }
                [JsonProperty("LeftBarEndClearance")]
                public string LeftBarEndClearance { get; set; }
                [JsonProperty("AttachLeftSide")]
                public string AttachLeftSide { get; set; }
                [JsonProperty("SkirtClearance")]
                public string SkirtClearance { get; set; }
            }
            public class ChassisLeftFront
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("SpringPerch")]
                public string SpringPerch { get; set; }
                [JsonProperty("ShockCompression")]
                public string ShockCompression { get; set; }
                [JsonProperty("ShockRebound")]
                public string ShockRebound { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("Caster")]
                public string Caster { get; set; }
                [JsonProperty("SkirtClearance")]
                public string SkirtClearance { get; set; }
            }
            public class ChassisLeftRear
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("LeafSpringRate")]
                public string LeafSpringRate { get; set; }
                [JsonProperty("LeafArchBlock")]
                public string LeafArchBlock { get; set; }
                [JsonProperty("ShockCompression")]
                public string ShockCompression { get; set; }
                [JsonProperty("ShockRebound")]
                public string ShockRebound { get; set; }
                [JsonProperty("SkirtClearance")]
                public string SkirtClearance { get; set; }
            }
            public class ChassisRightFront
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("SpringPerch")]
                public string SpringPerch { get; set; }
                [JsonProperty("ShockCompression")]
                public string ShockCompression { get; set; }
                [JsonProperty("ShockRebound")]
                public string ShockRebound { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("Caster")]
                public string Caster { get; set; }
                [JsonProperty("SkirtClearance")]
                public string SkirtClearance { get; set; }
            }
            public class ChassisRightRear
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("LeafSpringRate")]
                public string LeafSpringRate { get; set; }
                [JsonProperty("LeafArchBlock")]
                public string LeafArchBlock { get; set; }
                [JsonProperty("ShockCompression")]
                public string ShockCompression { get; set; }
                [JsonProperty("ShockRebound")]
                public string ShockRebound { get; set; }
                [JsonProperty("SkirtClearance")]
                public string SkirtClearance { get; set; }
            }
            public class ChassisRear
            {
                [JsonProperty("RearEndRatio")]
                public string RearEndRatio { get; set; }
                [JsonProperty("FuelFillTo")]
                public string FuelFillTo { get; set; }
            }
        }
    }
}
