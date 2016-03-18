using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtParserLibrary.Session.CarSetup
{
    public class ModifiedTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public ModifiedSetup CarSetup { get; set; }
    }
}
