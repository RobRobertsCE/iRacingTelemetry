using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace iRacing.TrackSession.Views
{
    public class LapTimesView : List<LapTimeView>
    {
        public LapTimesView()
        {

        }

        public static LapTimesView FromJson(string json)
        {
            return (LapTimesView)JsonConvert.DeserializeObject(json, typeof(LapTimesView),
                                                          new JsonSerializerSettings()
                                                          { TypeNameHandling = TypeNameHandling.All });
        }

        public string ToJson()
        {
            JsonSerializer jsonSerializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (var jsonStreamWriter = new StringWriter())
            {
                jsonSerializer.Serialize(jsonStreamWriter, this);
                return jsonStreamWriter.ToString();
            }
        }
    }

    public class LapTimeView
    {
        public int LapNumber { get; set; }
        public float LapTime { get; set; }
    }
}
