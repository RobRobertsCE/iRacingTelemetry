using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TrackSessionLibrary.Data.Models
{
    public class LapTimes : List<LapModel>
    {
        public LapTimes()
        {

        }
        public static LapTimes FromJson(string json)
        {
            return (LapTimes)JsonConvert.DeserializeObject(json, typeof(LapTimes),
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

    public class LapModel
    {
        public int LapNumber { get; set; }
        public float LapTime { get; set; }   
    }
}
