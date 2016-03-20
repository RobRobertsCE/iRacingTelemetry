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
        public LapTimesView(List<LapTimeView> laps)
        {
            this.AddRange(laps);
        }

        public LapTimesView(IDictionary<int, float> rawLaps)
        {
            foreach (var rawLap in rawLaps)
            {
                this.Add(new LapTimeView() { LapNumber = rawLap.Key, LapTime = rawLap.Value });
            }
        }

        public static LapTimesView FromJson(string json)
        {
            var laps = (Dictionary<int, float>)JsonConvert.DeserializeObject(json, typeof(Dictionary<int, float>),
                                                         new JsonSerializerSettings()
                                                         { TypeNameHandling = TypeNameHandling.All });
            return new LapTimesView(laps);
        }

        public string ToJson()
        {
            var buffer = new List<LapTimeView>();
            JsonSerializer jsonSerializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (var jsonStreamWriter = new StringWriter())
            {
                jsonSerializer.Serialize(jsonStreamWriter, buffer);
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
