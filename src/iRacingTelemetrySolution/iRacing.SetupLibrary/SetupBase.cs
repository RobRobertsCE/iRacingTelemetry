using Newtonsoft.Json;

namespace iRacing.SetupLibrary
{
    public class SetupBase
    {
        [JsonIgnore()]
        public string SetupJSON { get; set; }
    }
}
