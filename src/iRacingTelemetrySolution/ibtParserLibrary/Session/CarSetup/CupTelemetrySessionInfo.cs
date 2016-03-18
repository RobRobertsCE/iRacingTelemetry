using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace iRacing.TelemetryParser.Session.CarSetup
{
    public class CupTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public AClassSetup CarSetup { get; set; }
    }
}
