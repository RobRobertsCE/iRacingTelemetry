using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtSessionLibrary.CarSetup
{
    public class SSTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public SSSetup CarSetup { get; set; }
    }
}
