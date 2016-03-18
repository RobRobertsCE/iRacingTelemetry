using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace iRacing.TelemetryParser.Session.CarSetup
{
    public class XfinityTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public BClassSetup CarSetup { get; set; }
    }
}