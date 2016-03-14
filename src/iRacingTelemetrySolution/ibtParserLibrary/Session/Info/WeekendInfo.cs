﻿using Newtonsoft.Json;

// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

namespace ibtParserLibrary.Session.Info
{
    public class WeekendInfo
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
        public string TrackConfigName { get; set; }

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
        public WeekendOptions WeekendOptions { get; set; }

        [JsonProperty("TelemetryOptions")]
        public TelemetryOptions TelemetryOptions { get; set; }
    }

    public class WeekendOptions
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

    public class TelemetryOptions
    {
        [JsonProperty("TelemetryDiskFile")]
        public string TelemetryDiskFile { get; set; }
    }
}
