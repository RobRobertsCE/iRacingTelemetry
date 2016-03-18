using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtParserLibrary.Session.CarSetup
{
    public class SSTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public SSSetup CarSetup { get; set; }
    }
}
