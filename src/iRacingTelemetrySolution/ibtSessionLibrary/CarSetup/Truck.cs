﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestSession
{

    internal partial class Truck
    {
        internal class WeekendOptions2
        {

            [JsonProperty("NumStarters")]
            public string NumStarters { get; set; }

            [JsonProperty("StartingGrid")]
            public string StartingGrid { get; set; }

            [JsonProperty("QualifyScoring")]
            public string QualifyScoring { get; set; }

            [JsonProperty("CourseCautions")]
            public string CourseCautions { get; set; }

            [JsonProperty("StandingStart")]
            public string StandingStart { get; set; }

            [JsonProperty("Restarts")]
            public string Restarts { get; set; }

            [JsonProperty("WeatherType")]
            public string WeatherType { get; set; }

            [JsonProperty("Skies")]
            public string Skies { get; set; }

            [JsonProperty("WindDirection")]
            public string WindDirection { get; set; }

            [JsonProperty("WindSpeed")]
            public string WindSpeed { get; set; }

            [JsonProperty("WeatherTemp")]
            public string WeatherTemp { get; set; }

            [JsonProperty("RelativeHumidity")]
            public string RelativeHumidity { get; set; }

            [JsonProperty("FogLevel")]
            public string FogLevel { get; set; }

            [JsonProperty("Unofficial")]
            public string Unofficial { get; set; }

            [JsonProperty("CommercialMode")]
            public string CommercialMode { get; set; }

            [JsonProperty("NightMode")]
            public string NightMode { get; set; }

            [JsonProperty("IsFixedSetup")]
            public string IsFixedSetup { get; set; }

            [JsonProperty("StrictLapsChecking")]
            public string StrictLapsChecking { get; set; }

            [JsonProperty("HasOpenRegistration")]
            public string HasOpenRegistration { get; set; }

            [JsonProperty("HardcoreLevel")]
            public string HardcoreLevel { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class TelemetryOptions2
        {

            [JsonProperty("TelemetryDiskFile")]
            public string TelemetryDiskFile { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class WeekendInfo2
        {

            [JsonProperty("TrackName")]
            public string TrackName { get; set; }

            [JsonProperty("TrackID")]
            public string TrackID { get; set; }

            [JsonProperty("TrackLength")]
            public string TrackLength { get; set; }

            [JsonProperty("TrackDisplayName")]
            public string TrackDisplayName { get; set; }

            [JsonProperty("TrackDisplayShortName")]
            public string TrackDisplayShortName { get; set; }

            [JsonProperty("TrackConfigName")]
            public object TrackConfigName { get; set; }

            [JsonProperty("TrackCity")]
            public string TrackCity { get; set; }

            [JsonProperty("TrackCountry")]
            public string TrackCountry { get; set; }

            [JsonProperty("TrackAltitude")]
            public string TrackAltitude { get; set; }

            [JsonProperty("TrackLatitude")]
            public string TrackLatitude { get; set; }

            [JsonProperty("TrackLongitude")]
            public string TrackLongitude { get; set; }

            [JsonProperty("TrackNorthOffset")]
            public string TrackNorthOffset { get; set; }

            [JsonProperty("TrackNumTurns")]
            public string TrackNumTurns { get; set; }

            [JsonProperty("TrackPitSpeedLimit")]
            public string TrackPitSpeedLimit { get; set; }

            [JsonProperty("TrackType")]
            public string TrackType { get; set; }

            [JsonProperty("TrackWeatherType")]
            public string TrackWeatherType { get; set; }

            [JsonProperty("TrackSkies")]
            public string TrackSkies { get; set; }

            [JsonProperty("TrackSurfaceTemp")]
            public string TrackSurfaceTemp { get; set; }

            [JsonProperty("TrackAirTemp")]
            public string TrackAirTemp { get; set; }

            [JsonProperty("TrackAirPressure")]
            public string TrackAirPressure { get; set; }

            [JsonProperty("TrackWindVel")]
            public string TrackWindVel { get; set; }

            [JsonProperty("TrackWindDir")]
            public string TrackWindDir { get; set; }

            [JsonProperty("TrackRelativeHumidity")]
            public string TrackRelativeHumidity { get; set; }

            [JsonProperty("TrackFogLevel")]
            public string TrackFogLevel { get; set; }

            [JsonProperty("TrackCleanup")]
            public string TrackCleanup { get; set; }

            [JsonProperty("TrackDynamicTrack")]
            public string TrackDynamicTrack { get; set; }

            [JsonProperty("SeriesID")]
            public string SeriesID { get; set; }

            [JsonProperty("SeasonID")]
            public string SeasonID { get; set; }

            [JsonProperty("SessionID")]
            public string SessionID { get; set; }

            [JsonProperty("SubSessionID")]
            public string SubSessionID { get; set; }

            [JsonProperty("LeagueID")]
            public string LeagueID { get; set; }

            [JsonProperty("Official")]
            public string Official { get; set; }

            [JsonProperty("RaceWeek")]
            public string RaceWeek { get; set; }

            [JsonProperty("EventType")]
            public string EventType { get; set; }

            [JsonProperty("Category")]
            public string Category { get; set; }

            [JsonProperty("SimMode")]
            public string SimMode { get; set; }

            [JsonProperty("TeamRacing")]
            public string TeamRacing { get; set; }

            [JsonProperty("MinDrivers")]
            public string MinDrivers { get; set; }

            [JsonProperty("MaxDrivers")]
            public string MaxDrivers { get; set; }

            [JsonProperty("DCRuleSet")]
            public string DCRuleSet { get; set; }

            [JsonProperty("QualifierMustStartRace")]
            public string QualifierMustStartRace { get; set; }

            [JsonProperty("NumCarClasses")]
            public string NumCarClasses { get; set; }

            [JsonProperty("NumCarTypes")]
            public string NumCarTypes { get; set; }

            [JsonProperty("WeekendOptions")]
            public WeekendOptions2 WeekendOptions { get; set; }

            [JsonProperty("TelemetryOptions")]
            public TelemetryOptions2 TelemetryOptions { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class ResultsFastestLap2
        {

            [JsonProperty("CarIdx")]
            public string CarIdx { get; set; }

            [JsonProperty("FastestLap")]
            public string FastestLap { get; set; }

            [JsonProperty("FastestTime")]
            public string FastestTime { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Session
        {

            [JsonProperty("SessionNum")]
            public string SessionNum { get; set; }

            [JsonProperty("SessionLaps")]
            public string SessionLaps { get; set; }

            [JsonProperty("SessionTime")]
            public string SessionTime { get; set; }

            [JsonProperty("SessionNumLapsToAvg")]
            public string SessionNumLapsToAvg { get; set; }

            [JsonProperty("SessionType")]
            public string SessionType { get; set; }

            [JsonProperty("SessionTrackRubberState")]
            public string SessionTrackRubberState { get; set; }

            [JsonProperty("ResultsPositions")]
            public object ResultsPositions { get; set; }

            [JsonProperty("ResultsFastestLap")]
            public ResultsFastestLap2[] ResultsFastestLap { get; set; }

            [JsonProperty("ResultsAverageLapTime")]
            public string ResultsAverageLapTime { get; set; }

            [JsonProperty("ResultsNumCautionFlags")]
            public string ResultsNumCautionFlags { get; set; }

            [JsonProperty("ResultsNumCautionLaps")]
            public string ResultsNumCautionLaps { get; set; }

            [JsonProperty("ResultsNumLeadChanges")]
            public string ResultsNumLeadChanges { get; set; }

            [JsonProperty("ResultsLapsComplete")]
            public string ResultsLapsComplete { get; set; }

            [JsonProperty("ResultsOfficial")]
            public string ResultsOfficial { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class SessionInfo2
        {

            [JsonProperty("Sessions")]
            public Session[] Sessions { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Camera
        {

            [JsonProperty("CameraNum")]
            public string CameraNum { get; set; }

            [JsonProperty("CameraName")]
            public string CameraName { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Group
        {

            [JsonProperty("GroupNum")]
            public string GroupNum { get; set; }

            [JsonProperty("GroupName")]
            public string GroupName { get; set; }

            [JsonProperty("Cameras")]
            public Camera[] Cameras { get; set; }

            [JsonProperty("IsScenic")]
            public string IsScenic { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class CameraInfo2
        {

            [JsonProperty("Groups")]
            public Group[] Groups { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Frequency
        {

            [JsonProperty("FrequencyNum")]
            public string FrequencyNum { get; set; }

            [JsonProperty("FrequencyName")]
            public string FrequencyName { get; set; }

            [JsonProperty("Priority")]
            public string Priority { get; set; }

            [JsonProperty("CarIdx")]
            public string CarIdx { get; set; }

            [JsonProperty("EntryIdx")]
            public string EntryIdx { get; set; }

            [JsonProperty("ClubID")]
            public string ClubID { get; set; }

            [JsonProperty("CanScan")]
            public string CanScan { get; set; }

            [JsonProperty("CanSquawk")]
            public string CanSquawk { get; set; }

            [JsonProperty("Muted")]
            public string Muted { get; set; }

            [JsonProperty("IsMutable")]
            public string IsMutable { get; set; }

            [JsonProperty("IsDeletable")]
            public string IsDeletable { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Radio
        {

            [JsonProperty("RadioNum")]
            public string RadioNum { get; set; }

            [JsonProperty("HopCount")]
            public string HopCount { get; set; }

            [JsonProperty("NumFrequencies")]
            public string NumFrequencies { get; set; }

            [JsonProperty("TunedToFrequencyNum")]
            public string TunedToFrequencyNum { get; set; }

            [JsonProperty("ScanningIsOn")]
            public string ScanningIsOn { get; set; }

            [JsonProperty("Frequencies")]
            public Frequency[] Frequencies { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class RadioInfo2
        {

            [JsonProperty("SelectedRadioNum")]
            public string SelectedRadioNum { get; set; }

            [JsonProperty("Radios")]
            public Radio[] Radios { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Driver
        {

            [JsonProperty("CarIdx")]
            public string CarIdx { get; set; }

            [JsonProperty("UserName")]
            public string UserName { get; set; }

            [JsonProperty("AbbrevName")]
            public object AbbrevName { get; set; }

            [JsonProperty("Initials")]
            public object Initials { get; set; }

            [JsonProperty("UserID")]
            public string UserID { get; set; }

            [JsonProperty("TeamID")]
            public string TeamID { get; set; }

            [JsonProperty("TeamName")]
            public string TeamName { get; set; }

            [JsonProperty("CarNumber")]
            public string CarNumber { get; set; }

            [JsonProperty("CarNumberRaw")]
            public string CarNumberRaw { get; set; }

            [JsonProperty("CarPath")]
            public string CarPath { get; set; }

            [JsonProperty("CarClassID")]
            public string CarClassID { get; set; }

            [JsonProperty("CarID")]
            public string CarID { get; set; }

            [JsonProperty("CarIsPaceCar")]
            public string CarIsPaceCar { get; set; }

            [JsonProperty("CarIsAI")]
            public string CarIsAI { get; set; }

            [JsonProperty("CarScreenName")]
            public string CarScreenName { get; set; }

            [JsonProperty("CarScreenNameShort")]
            public string CarScreenNameShort { get; set; }

            [JsonProperty("CarClassShortName")]
            public object CarClassShortName { get; set; }

            [JsonProperty("CarClassRelSpeed")]
            public string CarClassRelSpeed { get; set; }

            [JsonProperty("CarClassLicenseLevel")]
            public string CarClassLicenseLevel { get; set; }

            [JsonProperty("CarClassMaxFuelPct")]
            public string CarClassMaxFuelPct { get; set; }

            [JsonProperty("CarClassWeightPenalty")]
            public string CarClassWeightPenalty { get; set; }

            [JsonProperty("CarClassColor")]
            public string CarClassColor { get; set; }

            [JsonProperty("IRating")]
            public string IRating { get; set; }

            [JsonProperty("LicLevel")]
            public string LicLevel { get; set; }

            [JsonProperty("LicSubLevel")]
            public string LicSubLevel { get; set; }

            [JsonProperty("LicString")]
            public string LicString { get; set; }

            [JsonProperty("LicColor")]
            public string LicColor { get; set; }

            [JsonProperty("IsSpectator")]
            public string IsSpectator { get; set; }

            [JsonProperty("CarDesignStr")]
            public string CarDesignStr { get; set; }

            [JsonProperty("HelmetDesignStr")]
            public string HelmetDesignStr { get; set; }

            [JsonProperty("SuitDesignStr")]
            public string SuitDesignStr { get; set; }

            [JsonProperty("CarNumberDesignStr")]
            public string CarNumberDesignStr { get; set; }

            [JsonProperty("CarSponsor_1")]
            public string CarSponsor1 { get; set; }

            [JsonProperty("CarSponsor_2")]
            public string CarSponsor2 { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class DriverInfo2
        {

            [JsonProperty("DriverCarIdx")]
            public string DriverCarIdx { get; set; }

            [JsonProperty("PaceCarIdx")]
            public string PaceCarIdx { get; set; }

            [JsonProperty("DriverHeadPosX")]
            public string DriverHeadPosX { get; set; }

            [JsonProperty("DriverHeadPosY")]
            public string DriverHeadPosY { get; set; }

            [JsonProperty("DriverHeadPosZ")]
            public string DriverHeadPosZ { get; set; }

            [JsonProperty("DriverCarIdleRPM")]
            public string DriverCarIdleRPM { get; set; }

            [JsonProperty("DriverCarRedLine")]
            public string DriverCarRedLine { get; set; }

            [JsonProperty("DriverCarFuelKgPerLtr")]
            public string DriverCarFuelKgPerLtr { get; set; }

            [JsonProperty("DriverCarFuelMaxLtr")]
            public string DriverCarFuelMaxLtr { get; set; }

            [JsonProperty("DriverCarMaxFuelPct")]
            public string DriverCarMaxFuelPct { get; set; }

            [JsonProperty("DriverCarSLFirstRPM")]
            public string DriverCarSLFirstRPM { get; set; }

            [JsonProperty("DriverCarSLShiftRPM")]
            public string DriverCarSLShiftRPM { get; set; }

            [JsonProperty("DriverCarSLLastRPM")]
            public string DriverCarSLLastRPM { get; set; }

            [JsonProperty("DriverCarSLBlinkRPM")]
            public string DriverCarSLBlinkRPM { get; set; }

            [JsonProperty("DriverPitTrkPct")]
            public string DriverPitTrkPct { get; set; }

            [JsonProperty("DriverCarEstLapTime")]
            public string DriverCarEstLapTime { get; set; }

            [JsonProperty("DriverSetupName")]
            public string DriverSetupName { get; set; }

            [JsonProperty("DriverSetupIsModified")]
            public string DriverSetupIsModified { get; set; }

            [JsonProperty("DriverSetupLoadTypeName")]
            public string DriverSetupLoadTypeName { get; set; }

            [JsonProperty("DriverSetupPassedTech")]
            public string DriverSetupPassedTech { get; set; }

            [JsonProperty("Drivers")]
            public Driver[] Drivers { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Sector
        {

            [JsonProperty("SectorNum")]
            public string SectorNum { get; set; }

            [JsonProperty("SectorStartPct")]
            public string SectorStartPct { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class SplitTimeInfo2
        {

            [JsonProperty("Sectors")]
            public Sector[] Sectors { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class LeftFront2
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
    }

    internal partial class Truck
    {
        internal class LeftRear2
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
    }

    internal partial class Truck
    {
        internal class RightFront2
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

    internal partial class Truck
    {
        internal class RightRear2
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

    internal partial class Truck
    {
        internal class Tires2
        {

            [JsonProperty("LeftFront")]
            public LeftFront2 LeftFront { get; set; }

            [JsonProperty("LeftRear")]
            public LeftRear2 LeftRear { get; set; }

            [JsonProperty("RightFront")]
            public RightFront2 RightFront { get; set; }

            [JsonProperty("RightRear")]
            public RightRear2 RightRear { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Front2
        {

            [JsonProperty("BallastForward")]
            public string BallastForward { get; set; }

            [JsonProperty("NoseWeight")]
            public string NoseWeight { get; set; }

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

            [JsonProperty("TapeConfiguration")]
            public string TapeConfiguration { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class LeftFront3
        {

            [JsonProperty("CornerWeight")]
            public string CornerWeight { get; set; }

            [JsonProperty("RideHeight")]
            public string RideHeight { get; set; }

            [JsonProperty("ShockDeflection")]
            public string ShockDeflection { get; set; }

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

            [JsonProperty("Camber")]
            public string Camber { get; set; }

            [JsonProperty("Caster")]
            public string Caster { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class LeftRear3
        {

            [JsonProperty("CornerWeight")]
            public string CornerWeight { get; set; }

            [JsonProperty("RideHeight")]
            public string RideHeight { get; set; }

            [JsonProperty("ShockDeflection")]
            public string ShockDeflection { get; set; }

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

            [JsonProperty("LeftRearToeIn")]
            public string LeftRearToeIn { get; set; }

            [JsonProperty("Camber")]
            public string Camber { get; set; }

            [JsonProperty("TrackBarHeight")]
            public string TrackBarHeight { get; set; }

            [JsonProperty("TruckArmMount")]
            public string TruckArmMount { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class FrontArb2
        {

            [JsonProperty("Diameter")]
            public string Diameter { get; set; }

            [JsonProperty("ArmAsymmetry")]
            public string ArmAsymmetry { get; set; }

            [JsonProperty("ChainOrSolidLink")]
            public string ChainOrSolidLink { get; set; }

            [JsonProperty("LinkSlack")]
            public string LinkSlack { get; set; }

            [JsonProperty("Preload")]
            public string Preload { get; set; }

            [JsonProperty("Attach")]
            public string Attach { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class RightFront3
        {

            [JsonProperty("CornerWeight")]
            public string CornerWeight { get; set; }

            [JsonProperty("RideHeight")]
            public string RideHeight { get; set; }

            [JsonProperty("ShockDeflection")]
            public string ShockDeflection { get; set; }

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

            [JsonProperty("Camber")]
            public string Camber { get; set; }

            [JsonProperty("Caster")]
            public string Caster { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class RightRear3
        {

            [JsonProperty("CornerWeight")]
            public string CornerWeight { get; set; }

            [JsonProperty("RideHeight")]
            public string RideHeight { get; set; }

            [JsonProperty("ShockDeflection")]
            public string ShockDeflection { get; set; }

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

            [JsonProperty("RightRearToeIn")]
            public string RightRearToeIn { get; set; }

            [JsonProperty("Camber")]
            public string Camber { get; set; }

            [JsonProperty("TrackBarHeight")]
            public string TrackBarHeight { get; set; }

            [JsonProperty("TruckArmMount")]
            public string TruckArmMount { get; set; }

            [JsonProperty("TruckArmPreload")]
            public string TruckArmPreload { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Rear2
        {

            [JsonProperty("RearEndRatio")]
            public string RearEndRatio { get; set; }

            [JsonProperty("ArbDiameter")]
            public string ArbDiameter { get; set; }

            [JsonProperty("ArmAsymmetry")]
            public string ArmAsymmetry { get; set; }

            [JsonProperty("ChainOrSolidLink")]
            public string ChainOrSolidLink { get; set; }

            [JsonProperty("Preload")]
            public string Preload { get; set; }

            [JsonProperty("LinkSlack")]
            public string LinkSlack { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class Chassis2
        {

            [JsonProperty("Front")]
            public Front2 Front { get; set; }

            [JsonProperty("LeftFront")]
            public LeftFront3 LeftFront { get; set; }

            [JsonProperty("LeftRear")]
            public LeftRear3 LeftRear { get; set; }

            [JsonProperty("FrontArb")]
            public FrontArb2 FrontArb { get; set; }

            [JsonProperty("RightFront")]
            public RightFront3 RightFront { get; set; }

            [JsonProperty("RightRear")]
            public RightRear3 RightRear { get; set; }

            [JsonProperty("Rear")]
            public Rear2 Rear { get; set; }
        }
    }

    internal partial class Truck
    {
        internal class CarSetup2
        {

            [JsonProperty("UpdateCount")]
            public string UpdateCount { get; set; }

            [JsonProperty("Tires")]
            public Tires2 Tires { get; set; }

            [JsonProperty("Chassis")]
            public Chassis2 Chassis { get; set; }
        }
    }

    internal partial class Truck
    {

        [JsonProperty("WeekendInfo")]
        public WeekendInfo2 WeekendInfo { get; set; }

        [JsonProperty("SessionInfo")]
        public SessionInfo2 SessionInfo { get; set; }

        [JsonProperty("CameraInfo")]
        public CameraInfo2 CameraInfo { get; set; }

        [JsonProperty("RadioInfo")]
        public RadioInfo2 RadioInfo { get; set; }

        [JsonProperty("DriverInfo")]
        public DriverInfo2 DriverInfo { get; set; }

        [JsonProperty("SplitTimeInfo")]
        public SplitTimeInfo2 SplitTimeInfo { get; set; }

        [JsonProperty("CarSetup")]
        public CarSetup2 CarSetup { get; set; }
    }

}
