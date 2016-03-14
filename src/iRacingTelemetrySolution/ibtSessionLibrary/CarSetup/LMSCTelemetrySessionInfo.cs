using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtSessionLibrary.CarSetup
{
    public class LMSCTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public LMSCSetup CarSetup { get; set; }
    }     
}
