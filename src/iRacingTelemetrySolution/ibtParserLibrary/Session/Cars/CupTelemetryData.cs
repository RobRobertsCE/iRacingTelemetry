﻿using ibtParserLibrary.Session.Info;
using Newtonsoft.Json;

namespace ibtParserLibrary.Session.Cars
{
    public class CupTelemetryData : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public CupSetup CarSetup { get; set; }
    }

    public class CupSetup : ISetupTelemetryData
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
            [JsonProperty("FrontARB")]
            public ChassisFrontARB FrontARB { get; set; }
            [JsonProperty("RightFront")]
            public ChassisRightFront RightFront { get; set; }
            [JsonProperty("RightRear")]
            public ChassisRightRear RightRear { get; set; }
            [JsonProperty("Rear")]
            public ChassisRear Rear { get; set; }

            public class ChassisFront
            {
                [JsonProperty("BallastForward")]
                public string BallastForward { get; set; }
                [JsonProperty("NoseWeight")]
                public string NoseWeight { get; set; }
                [JsonProperty("CrossWeight")]
                public string CrossWeight { get; set; }
                [JsonProperty("SteeringRatio")]
                public string SteeringRatio { get; set; }
                [JsonProperty("SteeringOffset")]
                public string SteeringOffset { get; set; }
                [JsonProperty("FrontBrakeBias")]
                public string FrontBrakeBias { get; set; }
                [JsonProperty("TapeConfiguration")]
                public string TapeConfiguration { get; set; }
            }
            public class ChassisLeftFront
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringDeflection")]
                public string SpringDeflection { get; set; }
                [JsonProperty("SpringPerchOffset")]
                public string SpringPerchOffset { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("ShockDeflection")]
                public string ShockDeflection { get; set; }
                [JsonProperty("ShockCollarOffset")]
                public string ShockCollarOffset { get; set; }
                [JsonProperty("Packer")]
                public string Packer { get; set; }
                [JsonProperty("ShockSpringRate")]
                public string ShockSpringRate { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("Caster")]
                public string Caster { get; set; }
                [JsonProperty("ToeIn")]
                public string ToeIn { get; set; }
            }
            public class ChassisLeftRear
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringDeflection")]
                public string SpringDeflection { get; set; }
                [JsonProperty("SpringPerchOffset")]
                public string SpringPerchOffset { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("ShockDeflection")]
                public string ShockDeflection { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("ToeIn")]
                public string ToeIn { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("TruckArmMount")]
                public string TruckArmMount { get; set; }
                [JsonProperty("TrailingArmMount")]
                public string TrailingArmMount { get; set; }
                [JsonProperty("TrackBarHeight")]
                public string TrackBarHeight { get; set; }
            }
            public class ChassisFrontARB
            {
                [JsonProperty("Diameter")]
                public string Diameter { get; set; }
                [JsonProperty("ArmAsymmetry")]
                public string ArmAsymmetry { get; set; }
                [JsonProperty("Preload")]
                public string Preload { get; set; }
                [JsonProperty("Attach")]
                public string Attach { get; set; }
            }
            public class ChassisRightFront
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringDeflection")]
                public string SpringDeflection { get; set; }
                [JsonProperty("SpringPerchOffset")]
                public string SpringPerchOffset { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("ShockDeflection")]
                public string ShockDeflection { get; set; }
                [JsonProperty("ShockCollarOffset")]
                public string ShockCollarOffset { get; set; }
                [JsonProperty("Packer")]
                public string Packer { get; set; }
                [JsonProperty("ShockSpringRate")]
                public string ShockSpringRate { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("Caster")]
                public string Caster { get; set; }
                [JsonProperty("ToeIn")]
                public string ToeIn { get; set; }
            }
            public class ChassisRightRear
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringDeflection")]
                public string SpringDeflection { get; set; }
                [JsonProperty("SpringPerchOffset")]
                public string SpringPerchOffset { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("ShockDeflection")]
                public string ShockDeflection { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("ToeIn")]
                public string ToeIn { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("TruckArmMount")]
                public string TruckArmMount { get; set; }
                [JsonProperty("TrailingArmMount")]
                public string TrailingArmMount { get; set; }
                [JsonProperty("TrackBarHeight")]
                public string TrackBarHeight { get; set; }
            }
            public class ChassisRear
            {
                [JsonProperty("RearEndRatio")]
                public string RearEndRatio { get; set; }
                [JsonProperty("FuelLevel")]
                public string FuelLevel { get; set; }
                [JsonProperty("ArbDiameter")]
                public string ArbDiameter { get; set; }
                [JsonProperty("Preload")]
                public string Preload { get; set; }
                [JsonProperty("Attach")]
                public string Attach { get; set; }
            }
        }
    }
}