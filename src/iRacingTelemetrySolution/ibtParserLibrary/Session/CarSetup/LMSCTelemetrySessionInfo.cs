using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtParserLibrary.Session.CarSetup
{
    public class LMSCTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public LMSCSetup CarSetup { get; set; }
    }     
}
