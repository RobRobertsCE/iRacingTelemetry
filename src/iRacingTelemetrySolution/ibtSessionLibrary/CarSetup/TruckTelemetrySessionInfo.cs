using iRacing.SetupLibrary;
using Newtonsoft.Json;

namespace ibtSessionLibrary.CarSetup
{
    public class TruckTelemetrySessionInfo : TelemetrySessionInfo
    {
        [JsonProperty("CarSetup")]
        public CClassSetup CarSetup { get; set; }
    }
 
}