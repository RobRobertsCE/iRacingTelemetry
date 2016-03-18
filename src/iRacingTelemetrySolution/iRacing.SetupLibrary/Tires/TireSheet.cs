using Newtonsoft.Json;
using System;
using System.IO;

namespace iRacing.SetupLibrary.Tires
{
    public class TireSheet
    {
        public Guid? TrackSessionRunId { get; set; }
        public DateTime Timestamp { get; private set; }

        public string VehicleName { get; set; }
        public string SetupName { get; set; }
        public string TrackName { get; set; }

        public TireDetails LF { get; set; }
        public TireDetails LR { get; set; }
        public TireDetails RF { get; set; }
        public TireDetails RR { get; set; }

        public TireSheet()
        {
            Timestamp = DateTime.Now;
        }

        public TireSheet(Guid? trackSessionRunId) : this()
        {
            this.TrackSessionRunId = trackSessionRunId;
            LF = new TireDetails();
            LR = new TireDetails();
            RF = new TireDetails();
            RR = new TireDetails();
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

        public static TireSheet FromJson(string json)
        {
            return (TireSheet)JsonConvert.DeserializeObject(json, typeof(TireSheet),
                                                      new JsonSerializerSettings()
                                                      { TypeNameHandling = TypeNameHandling.All });
        }
    }

    public class TireDetails
    {
        public float OutsideTemp { get; set; }
        public float MiddleTemp { get; set; }
        public float InsideTemp { get; set; }

        public float OutsideWear { get; set; }
        public float MiddleWear { get; set; }
        public float InsideWear { get; set; }

        public float ColdPsi { get; set; }
        public float HotPsi { get; set; }
        public float Gain
        {
            get
            {
                return HotPsi - ColdPsi;
            }
            set
            {

            }
        }

        public float? Stagger { get; set; }

        public TireDetails()
        {

        }
    }
}
