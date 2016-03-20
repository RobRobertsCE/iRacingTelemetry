using iRacing.TelemetryParser;
using iRacing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using iRacing.TelemetryParser.Extensions;
using Newtonsoft.Json;
using System.IO;

namespace iRacing.TelemetryAnalysis.Laps
{
    public class LapTimeAnalysis
    {
        public double Best { get; set; }
        public double Average { get; private set; }
        public double Median { get; private set; }
        public double StdDev { get; private set; }
        public double Range { get; private set; }
        public IDictionary<float, int> FrequencyDistribution { get; private set; }
        public IList<Single> Dropoff { get; private set; }

        public IDictionary<int, float> Laps { get; private set; }
        public IDictionary<int, float> RawLaps { get; private set; }

        public LapTimeAnalysis()
        {

        }

        public LapTimeAnalysis(TelemetryLapList telemetryLaps)
            : this(telemetryLaps.LapTimesList())
        { }
        public LapTimeAnalysis(IDictionary<int, float> telemetryLaps)
        {
            RawLaps = telemetryLaps;
            Laps = RawLaps.ValidLaps();

            if (Laps.Count > 0)
            {
                Best = Laps.BestLap();
                Average = Laps.Average();
                Median = Laps.Median();
                StdDev = Laps.StdDev();
                Range = Laps.Range();
                FrequencyDistribution = Laps.FrequencyDistribution();
                Dropoff = Laps.Dropoff();
            }
        }

        public static LapTimeAnalysis FromJson(string json)
        {
            return (LapTimeAnalysis)JsonConvert.DeserializeObject(json, typeof(LapTimeAnalysis),
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
}
