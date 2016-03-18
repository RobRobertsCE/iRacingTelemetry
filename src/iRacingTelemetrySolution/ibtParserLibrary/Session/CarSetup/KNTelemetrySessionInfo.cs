using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtParserLibrary.Session.CarSetup
{
    public class KNTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public KNSetup CarSetup { get; set; }
    }
}
