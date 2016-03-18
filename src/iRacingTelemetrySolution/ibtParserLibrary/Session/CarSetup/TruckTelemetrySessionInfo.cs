using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtParserLibrary.Session.CarSetup
{
    public class TruckTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public CClassSetup CarSetup { get; set; }
    }
 
}