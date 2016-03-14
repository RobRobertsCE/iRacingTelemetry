using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtSessionLibrary.CarSetup
{
    public class CupTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public AClassSetup CarSetup { get; set; }
    }
}
