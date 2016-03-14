using Newtonsoft.Json;

namespace ibtSessionLibrary.Info
{
    public class Camera
    {

        [JsonProperty("CameraNum")]
        public string CameraNum { get; set; }

        [JsonProperty("CameraName")]
        public string CameraName { get; set; }
    }

    public class Group
    {

        [JsonProperty("GroupNum")]
        public string GroupNum { get; set; }

        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("Cameras")]
        public Camera[] Cameras { get; set; }

        [JsonProperty("IsScenic")]
        public string IsScenic { get; set; }
    }

    public class CameraInfo
    {
        [JsonProperty("Groups")]
        public Group[] Groups { get; set; }
    }
}
