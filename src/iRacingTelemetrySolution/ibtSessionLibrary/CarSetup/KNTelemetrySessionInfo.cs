using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtSessionLibrary.CarSetup
{
    public class KNTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public KNSetup CarSetup { get; set; }
    }
}
