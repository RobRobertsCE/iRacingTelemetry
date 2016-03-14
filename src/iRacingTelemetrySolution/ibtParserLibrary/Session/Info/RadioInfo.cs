﻿using Newtonsoft.Json;

// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

namespace ibtParserLibrary.Session.Info
{
    public class Frequency
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

    public class Radio
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

    public class RadioInfo
    {

        [JsonProperty("SelectedRadioNum")]
        public string SelectedRadioNum { get; set; }

        [JsonProperty("Radios")]
        public Radio[] Radios { get; set; }
    }
}
