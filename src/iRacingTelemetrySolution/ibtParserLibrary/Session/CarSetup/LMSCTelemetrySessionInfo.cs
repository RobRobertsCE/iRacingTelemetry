using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace iRacing.TelemetryParser.Session.CarSetup
{
    public class LMSCTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public LMSCSetup CarSetup { get; set; }
    }     
}
