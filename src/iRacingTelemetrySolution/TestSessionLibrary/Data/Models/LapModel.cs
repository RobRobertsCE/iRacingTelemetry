using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TestSessionLibrary.Data.Models
{
    public class LapTimes : List<LapModel>
    {
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
