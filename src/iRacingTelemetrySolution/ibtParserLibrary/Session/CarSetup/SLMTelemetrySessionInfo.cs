using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace iRacing.TelemetryParser.Session.CarSetup
{
    public class SLMTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public SLMSetup CarSetup { get; set; }
    }
} 
