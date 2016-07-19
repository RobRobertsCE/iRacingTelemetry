using iRacing.TelemetryParser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJsonSerialization
{
    public partial class Form1 : Form
    {
        #region fields
        JsonSerializerSettings _settings = null;
        ParserEngine _engine;
        TelemetrySessionEx _session;
        #endregion

        #region properties
        protected virtual JsonSerializerSettings Settings
        {
            get
            {
                if (null == _settings)
                {
                    _settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        Formatting = Formatting.Indented
                    };
                }
                return _settings;
            }
        }
        protected virtual string SerializedList { get; set; }
        protected virtual List<ITelemetryFieldDefinition> DeserializedList { get; set; }
        protected virtual List<ITelemetryFieldDefinition> InheritanceList { get; set; }
        protected virtual TelemetrySessionEx Session { get; set; }
        protected virtual GraphData GraphData { get; set; }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _engine = new ParserEngine();

                GraphData = new GraphData();

                SerializeClasses();
                DeserializeClasses();

                LoadTelemetrySessionData();

                ReadStaticValues();
                ReadSessionValues();
                ReadLapValues();
                ReadFrameValues();

                ReadTelemetryValues();

                DisplayValues();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private TelemetrySessionEx ParseTelemetryFile(string telemetryFileName)
        {
            if (null == _engine)
                _engine = new ParserEngine();
            var session = _engine.ParseTelemetryFile(telemetryFileName, false);

            var sessionEx = new TelemetrySessionEx();

            int lapIdx = 0;
            foreach (var sessionLap in session.Laps)
            {
                TelemetryLap lap = new TelemetryLap() { LapIndex = lapIdx, LapNumber = sessionLap.LapNumber };
                lapIdx++;
                int frameIdx = 0;
                foreach (var sessionLapFrame in sessionLap.Frames)
                {
                    TelemetryFrame frame = new TelemetryFrame() { FrameIndex = frameIdx };
                    for (int fieldIdx = 0; fieldIdx < sessionLapFrame.ChannelValues.Count; fieldIdx++)
                    {
                        var channel = sessionLapFrame.ChannelValues[fieldIdx];
                        try
                        {
                            Single singleValue = 0;
                            if (channel.Value.ToString()=="True")
                            {
                                singleValue = 1;
                            }
                            else if (channel.Value.ToString() == "False")
                            {
                                singleValue = 0;
                            }
                            else
                            {
                                singleValue = Convert.ToSingle(channel.Value);
                            }                               
                            frame.Values.Add(channel.Definition.Name, singleValue);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error parsing " + channel.Definition.Name + ": " + channel.Value);
                        }                       
                    }
                    frameIdx++;
                }
            }

            return sessionEx;
        }

        TelemetrySessionEx GetTelemetrySession()
        {
            const int lapCount = 3;
            const int frameCount = 4;
            //const int fieldCount = 3;
            var rnd = new Random(DateTime.Now.Millisecond);
            var session = new TelemetrySessionEx();

            for (int lapIdx = 0; lapIdx < lapCount; lapIdx++)
            {
                TelemetryLap lap = new TelemetryLap() { LapIndex = lapIdx, LapNumber = lapIdx };
                //for (int frameIdx = 0; frameIdx < frameCount; frameIdx++)
                //{
                //TelemetryFrame frame = new TelemetryFrame() { FrameIndex = frameIdx };
                //for (int fieldIdx = 0; fieldIdx < fieldCount; fieldIdx++)
                //{
                //    frame.Values.Add(String.Format("Field{0}", fieldIdx), fieldIdx);
                //}                 
                //lap.LapFrames.Add(frame);
                //}

                // front stretch
                for (int frameIdx = 0; frameIdx < 4; frameIdx++)
                {
                    TelemetryFrame frame = new TelemetryFrame() { FrameIndex = frameIdx };
                    frame.Values.Add("LfRideHeight", (Single)(2.0 + rnd.NextDouble()));
                    frame.Values.Add("LrRideHeight", (Single)(2.2 + rnd.NextDouble()));
                    frame.Values.Add("RfRideHeight", (Single)(3.0 + rnd.NextDouble()));
                    frame.Values.Add("RrRideHeight", (Single)(3.5 + rnd.NextDouble()));
                    frame.Values.Add("LapTime", (Single)(18.0F + rnd.NextDouble()));
                    lap.LapFrames.Add(frame);
                }
                // turn 1-2
                for (int frameIdx = 4; frameIdx < 14; frameIdx++)
                {
                    TelemetryFrame frame = new TelemetryFrame() { FrameIndex = frameIdx };
                    frame.Values.Add("LfRideHeight", (Single)(1.5 + rnd.NextDouble()));
                    frame.Values.Add("LrRideHeight", (Single)(1.75 + rnd.NextDouble()));
                    frame.Values.Add("RfRideHeight", (Single)(2.0 + rnd.NextDouble()));
                    frame.Values.Add("RrRideHeight", (Single)(2.125 + rnd.NextDouble()));
                    frame.Values.Add("LapTime", (Single)(18.0F + rnd.NextDouble()));
                    lap.LapFrames.Add(frame);
                }
                // back stretch
                for (int frameIdx = 14; frameIdx < 22; frameIdx++)
                {
                    TelemetryFrame frame = new TelemetryFrame() { FrameIndex = frameIdx };
                    frame.Values.Add("LfRideHeight", (Single)(2.0 + rnd.NextDouble()));
                    frame.Values.Add("LrRideHeight", (Single)(2.2 + rnd.NextDouble()));
                    frame.Values.Add("RfRideHeight", (Single)(3.0 + rnd.NextDouble()));
                    frame.Values.Add("RrRideHeight", (Single)(3.5 + rnd.NextDouble()));
                    frame.Values.Add("LapTime", (Single)(18.0F + rnd.NextDouble()));
                    lap.LapFrames.Add(frame);
                }
                // turn 3-4
                for (int frameIdx = 22; frameIdx < 32; frameIdx++)
                {
                    TelemetryFrame frame = new TelemetryFrame() { FrameIndex = frameIdx };
                    frame.Values.Add("LfRideHeight", (Single)(1.5 + rnd.NextDouble()));
                    frame.Values.Add("LrRideHeight", (Single)(1.75 + rnd.NextDouble()));
                    frame.Values.Add("RfRideHeight", (Single)(2.0 + rnd.NextDouble()));
                    frame.Values.Add("RrRideHeight", (Single)(2.125 + rnd.NextDouble()));
                    frame.Values.Add("LapTime", (Single)(18.0F + rnd.NextDouble()));
                    lap.LapFrames.Add(frame);
                }
                // fs
                for (int frameIdx = 32; frameIdx < 36; frameIdx++)
                {
                    TelemetryFrame frame = new TelemetryFrame() { FrameIndex = frameIdx };
                    frame.Values.Add("LfRideHeight", (Single)(2.0 + rnd.NextDouble()));
                    frame.Values.Add("LrRideHeight", (Single)(2.2 + rnd.NextDouble()));
                    frame.Values.Add("RfRideHeight", (Single)(3.0 + rnd.NextDouble()));
                    frame.Values.Add("RrRideHeight", (Single)(3.5 + rnd.NextDouble()));
                    frame.Values.Add("LapTime", (Single)(18.0F + rnd.NextDouble()));
                    lap.LapFrames.Add(frame);
                }
                session.Laps.Add(lap);
            }
            return session;
        }

        void SerializeClasses()
        {
            try
            {
                InheritanceList = new List<ITelemetryFieldDefinition>() {
                    new TelemetryFieldDefinition() { Name = "LrRideHeight" },
                    new TelemetryFieldDefinition() { Name = "RrRideHeight" },
                    new TelemetryFieldDefinition() { Name = "LfRideHeight" },
                    new TelemetryFieldDefinition() { Name = "RfRideHeight" },
                    new MyCarNumberStaticField(),
                    new LrSpringRateField(),
                    new RrSpringRateField(),
                    new LfSpringRateField(),
                    new RfSpringRateField(),
                    new LrStaticRideHeightField(),
                    new RrStaticRideHeightField(),
                    new LfStaticRideHeightField(),
                    new RfStaticRideHeightField(),
                    new LrDynamicLoadField(),
                    new RrDynamicLoadField(),
                    new LfDynamicLoadField(),
                    new RfDynamicLoadField(),
                    new LapFrameCountField(),
                    new LapTimeField(),
                    new SwayBarRateField(),
                    new LrStaticLoadField(),
                    new RrStaticLoadField(),
                    new RfStaticLoadField(),
                    new LfStaticLoadField()
                };

                SerializedList = JsonConvert.SerializeObject(InheritanceList, Settings);
               // Console.WriteLine(SerializedList);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void DeserializeClasses()
        {
            try
            {
                DeserializedList = JsonConvert.DeserializeObject<List<ITelemetryFieldDefinition>>(SerializedList, Settings);
                //Console.WriteLine("Deserialized...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        void LoadTelemetrySessionData()
        {
            Session = ParseTelemetryFile(@"C:\Users\rroberts\Documents\iRacing\telemetry\skmodified_irp 2016-02-25 21-09-25.ibt");//   GetTelemetrySession();
        }

        void ReadStaticValues()
        {
            try
            {
                foreach (var field in DeserializedList.Where(i => i.FieldDefinitionType == FieldDefinitionType.Static))
                {
                    var staticField = (TelemetryStaticFieldDefinition)field;
                    var staticValue = staticField.GetValue();
                    GraphData.StaticValues.Add(staticField.Name, staticValue);
                }
                Console.WriteLine("Static values read...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ReadSessionValues()
        {
            try
            {
                foreach (var field in DeserializedList.Where(i => i.FieldDefinitionType == FieldDefinitionType.Session))
                {
                    var sessionField = (TelemetrySessionFieldDefinition)field;
                    var sessionValue = sessionField.GetValue(Session);
                    GraphData.SessionValues.Add(sessionField.Name, sessionValue);
                }
                Console.WriteLine("Session values read...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ReadLapValues()
        {
            try
            {
                for (int lapIdx = 0; lapIdx < Session.Laps.Count; lapIdx++)
                {
                    var lapGraphData = new Dictionary<string, Single>();
                    foreach (var field in DeserializedList.Where(i => i.FieldDefinitionType == FieldDefinitionType.Lap))
                    {
                        var lapField = (TelemetryLapFieldDefinition)field;
                        var lapValue = lapField.GetValue(Session, lapIdx);
                        lapGraphData.Add(lapField.Name, lapValue);
                    }
                    GraphData.LapValues.Add(lapIdx, lapGraphData);
                }
                Console.WriteLine("Lap values read...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ReadFrameValues()
        {
            try
            {
                foreach (var lap in Session.Laps)
                {
                    var lapValues = new Dictionary<int, IDictionary<string, Single>>();
                    foreach (var lapFrame in lap.LapFrames)
                    {
                        var frameValues = new Dictionary<string, Single>();
                        foreach (var field in DeserializedList.Where(i => i.FieldDefinitionType == FieldDefinitionType.Frame))
                        {
                            // read the value for this series (field) from this frame.
                            var lapField = (TelemetryFrameFieldDefinition)field;
                            var value = lapField.GetValue(GraphData, Session, lap.LapIndex, lapFrame.FrameIndex);
                            frameValues.Add(lapField.Name, value);
                        }
                        lapValues.Add(lapFrame.FrameIndex, frameValues);
                    }
                    GraphData.FrameValues.Add(lap.LapIndex, lapValues);
                }
                Console.WriteLine("Telemetry values read...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ReadTelemetryValues()
        {
            try
            {
                foreach (var lap in Session.Laps)
                {
                    var lapValues = new Dictionary<int, IDictionary<string, Single>>();
                    foreach (var lapFrame in lap.LapFrames)
                    {
                        var frameValues = new Dictionary<string, Single>();
                        foreach (var field in DeserializedList.Where(i => i.FieldDefinitionType == FieldDefinitionType.Value))
                        {
                            // read the value for this series (field) from this frame.
                            var value = lapFrame.Values[field.Name];
                            if (frameValues.ContainsKey(field.Name))
                            {
                                Console.WriteLine("Already has this key..." + field.Name);
                            }
                            else
                            {
                                frameValues.Add(field.Name, value);
                            }
                        }
                        lapValues.Add(lapFrame.FrameIndex, frameValues);
                    }
                    GraphData.TelemetryValues.Add(lap.LapIndex, lapValues);
                }
                Console.WriteLine("Telemetry values read...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void DisplayValues()
        {
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(">> Static Values:");
            //foreach (var item in GraphData.StaticValues)
            //{
            //    Console.WriteLine("{0}: {1}", item.Key, item.Value.ToString());
            //}
            //Console.WriteLine();

            //Console.WriteLine(">> Session Values:");
            //foreach (var item in GraphData.SessionValues)
            //{
            //    Console.WriteLine("{0}: {1}", item.Key, item.Value.ToString());
            //}
            //Console.WriteLine();

            //Console.WriteLine(">> Lap Values:");
            //foreach (var item in GraphData.LapValues)
            //{
            //    foreach (var lapItem in item.Value)
            //    {
            //        Console.WriteLine("{0}: {1}: {2}", item.Key, lapItem.Key, lapItem.Value.ToString());
            //    }

            //}
            //Console.WriteLine();

            //Console.WriteLine(">> Frame Values:");
            StringBuilder sb = new StringBuilder();

            foreach (var item in GraphData.FrameValues)
            {
                foreach (var lapItem in item.Value)
                {
                    foreach (var frameItem in lapItem.Value)
                    {
                        sb.AppendFormat("{0}: {1}: {2}: {3}\r\n", item.Key, lapItem.Key, frameItem.Key, frameItem.Value.ToString());
                        //Console.WriteLine("{0}: {1}: {2}: {3}", item.Key, lapItem.Key, frameItem.Key, frameItem.Value.ToString());
                    }
                }
            }
            System.IO.File.WriteAllText(@"C:\Users\rroberts\Documents\iRacing\telemetry\test1.text", sb.ToString());
            //Console.WriteLine();


            //Console.WriteLine(">> Telemetry Values:");
            //foreach (var item in GraphData.TelemetryValues)
            //{
            //    foreach (var lapItem in item.Value)
            //    {
            //        foreach (var frameItem in lapItem.Value)
            //        {
            //            Console.WriteLine("{0}: {1}: {2}: {3}", item.Key, lapItem.Key, frameItem.Key, frameItem.Value.ToString());
            //        }
            //    }
            //}
            //Console.WriteLine();
        }
    }

    public enum FieldDefinitionType
    {
        Value,
        Session,
        Lap,
        Frame,
        Static
    }

    public interface ITelemetryFieldDefinition
    {
        string Name { get; set; }
        FieldDefinitionType FieldDefinitionType { get; set; }

        Single GetValue();
    }

    public class TelemetryFieldDefinition : ITelemetryFieldDefinition
    {
        public string Name { get; set; }
        public FieldDefinitionType FieldDefinitionType { get; set; }

        public TelemetryFieldDefinition()
            : this(FieldDefinitionType.Value)
        {
        }
        public TelemetryFieldDefinition(FieldDefinitionType fieldType)
        {
            FieldDefinitionType = fieldType;
        }

        public virtual Single GetValue()
        {
            return 123;
        }
    }

    public class TelemetryFrameFieldDefinition : TelemetryFieldDefinition, ITelemetryFieldDefinition
    {
        public TelemetryFrameFieldDefinition()
            : base(FieldDefinitionType.Frame)
        {

        }

        public virtual Single GetValue(GraphData graph, TelemetrySessionEx session, int lapIndex, int lapFrameIndex)
        {
            return 0F;
        }
    }

    public class TelemetryLapFieldDefinition : TelemetryFieldDefinition, ITelemetryFieldDefinition
    {
        public TelemetryLapFieldDefinition()
            : base(FieldDefinitionType.Lap)
        { }

        public virtual Single GetValue(TelemetrySessionEx session, int lapIndex)
        {
            return 0;
        }
    }

    public class TelemetrySessionFieldDefinition : TelemetryFieldDefinition, ITelemetryFieldDefinition
    {
        public TelemetrySessionFieldDefinition()
            : base(FieldDefinitionType.Session)
        {

        }

        public virtual Single GetValue(TelemetrySessionEx session)
        {
            return 456;
        }
    }

    public class TelemetryStaticFieldDefinition : TelemetryFieldDefinition, ITelemetryFieldDefinition
    {
        protected Single _value = 0.0F;

        protected TelemetryStaticFieldDefinition(string name, Single value)
            : this()
        {
            this.Name = name;
            _value = value;
        }

        public TelemetryStaticFieldDefinition()
            : base(FieldDefinitionType.Static)
        {
        }

        public override Single GetValue()
        {
            return _value;
        }
    }

    public class TelemetrySessionEx
    {
        public IList<TelemetryLap> Laps { get; set; }

        public TelemetrySessionEx()
        {
            Laps = new List<TelemetryLap>();
        }
    }

    public class TelemetryFrame
    {
        public int FrameIndex { get; set; }

        public IDictionary<string, Single> Values { get; set; }

        public TelemetryFrame()
        {
            Values = new Dictionary<string, Single>();
        }
    }

    public class TelemetryLap
    {
        public int LapIndex { get; set; }
        public int LapNumber { get; set; }

        public IList<TelemetryFrame> LapFrames { get; set; }

        public TelemetryLap()
        {
            LapFrames = new List<TelemetryFrame>();
        }
    }


    public class GraphSeries
    {
        public string Name { get; set; }
        public Single MinValue { get; set; }
        public Single MaxValue { get; set; }
        public Single Range
        {
            get
            {
                return MaxValue - MinValue;
            }
        }
        public string Unit { get; set; }
        public string Format { get; set; }
        public ITelemetryFieldDefinition Field { get; set; }

        public GraphSeries()
        {
        }
    }

    public class GraphPoint
    {

        public Single Value { get; set; }

        public PointF Point { get; set; }
    }

    public class GraphData
    {
        // ValueKey
        public IDictionary<string, Single> StaticValues { get; set; }

        // ValueKey
        public IDictionary<string, Single> SessionValues { get; set; }

        // LapIdx, FValueKey
        public IDictionary<int, IDictionary<string, Single>> LapValues { get; set; }

        // LapIdx, FrameIdx, ValueKey
        public IDictionary<int, IDictionary<int, IDictionary<string, Single>>> FrameValues { get; set; }

        // LapIdx, FrameIdx, ValueKey
        public IDictionary<int, IDictionary<int, IDictionary<string, Single>>> TelemetryValues { get; set; }

        public GraphData()
        {
            StaticValues = new Dictionary<string, Single>();
            SessionValues = new Dictionary<string, Single>();
            LapValues = new Dictionary<int, IDictionary<string, Single>>();
            FrameValues = new Dictionary<int, IDictionary<int, IDictionary<string, Single>>>();
            TelemetryValues = new Dictionary<int, IDictionary<int, IDictionary<string, Single>>>();
        }
    }


    // custom fields
    public class MyCarNumberStaticField : TelemetryStaticFieldDefinition
    {
        const string Key = "MyCarNumber";
        const Single Value = 82;

        public MyCarNumberStaticField() : base(Key, Value) { }
    }

    public class LrSpringRateField : TelemetrySessionFieldDefinition
    {
        public LrSpringRateField() : base()
        {
            Name = "LrSpringRate";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 225;
        }
    }
    public class RrSpringRateField : TelemetrySessionFieldDefinition
    {
        public RrSpringRateField() : base()
        {
            Name = "RrSpringRate";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 200;
        }
    }
    public class LfSpringRateField : TelemetrySessionFieldDefinition
    {
        public LfSpringRateField() : base()
        {
            Name = "LfSpringRate";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 450;
        }
    }
    public class RfSpringRateField : TelemetrySessionFieldDefinition
    {
        public RfSpringRateField() : base()
        {
            Name = "RfSpringRate";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 425;
        }
    }

    public class SwayBarRateField : TelemetrySessionFieldDefinition
    {
        public SwayBarRateField() : base()
        {
            Name = "SwayBarRate";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 350;
        }
    }

    public class LrStaticRideHeightField : TelemetrySessionFieldDefinition
    {
        public LrStaticRideHeightField() : base()
        {
            Name = "LrStaticRideHeight";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 3.0F;
        }
    }
    public class RrStaticRideHeightField : TelemetrySessionFieldDefinition
    {
        public RrStaticRideHeightField() : base()
        {
            Name = "RrStaticRideHeight";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 4.0F;
        }
    }
    public class LfStaticRideHeightField : TelemetrySessionFieldDefinition
    {
        public LfStaticRideHeightField() : base()
        {
            Name = "LfStaticRideHeight";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 2.0F;
        }
    }
    public class RfStaticRideHeightField : TelemetrySessionFieldDefinition
    {
        public RfStaticRideHeightField() : base()
        {
            Name = "RfStaticRideHeight";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 2.5F;
        }
    }

    public class RrStaticLoadField : TelemetrySessionFieldDefinition
    {
        public RrStaticLoadField() : base()
        {
            Name = "RrStaticLoad";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 535F;
        }
    }
    public class LrStaticLoadField : TelemetrySessionFieldDefinition
    {
        public LrStaticLoadField() : base()
        {
            Name = "LrStaticLoad";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 735F;
        }
    }
    public class RfStaticLoadField : TelemetrySessionFieldDefinition
    {
        public RfStaticLoadField() : base()
        {
            Name = "RfStaticLoad";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 676;
        }
    }
    public class LfStaticLoadField : TelemetrySessionFieldDefinition
    {
        public LfStaticLoadField() : base()
        {
            Name = "LfStaticLoad";
        }

        public override Single GetValue(TelemetrySessionEx session)
        {
            return 623;
        }
    }

    public class LrDynamicLoadField : TelemetryFrameFieldDefinition
    {
        public LrDynamicLoadField() : base()
        {
            Name = "LrDynamicLoad";
        }

        public override Single GetValue(GraphData graph, TelemetrySessionEx session, int lapIndex, int lapFrameIndex)
        {
            var staticLoad = (Single)graph.SessionValues["LrStaticLoad"];
            var staticHeight = (Single)graph.SessionValues["LrStaticRideHeight"];
            var springRate = (Single)graph.SessionValues["LrSpringRate"];
            var dynamicHeight = (Single)session.Laps[lapIndex].LapFrames[lapFrameIndex].Values["LrRideHeight"];
            var rideHeightDelta = dynamicHeight - staticHeight;
            var dynamicSpringLoadDelta = -1 * (rideHeightDelta * springRate);
            var dynamicLoad = staticLoad + dynamicSpringLoadDelta;
            return dynamicLoad;
        }
    }
    public class RrDynamicLoadField : TelemetryFrameFieldDefinition
    {
        public RrDynamicLoadField() : base()
        {
            Name = "RrDynamicLoad";
        }

        public override Single GetValue(GraphData graph, TelemetrySessionEx session, int lapIndex, int lapFrameIndex)
        {
            var staticLoad = (Single)graph.SessionValues["RrStaticLoad"];
            var staticHeight = (Single)graph.SessionValues["RrStaticRideHeight"];
            var springRate = (Single)graph.SessionValues["RrSpringRate"];
            var dynamicHeight = (Single)session.Laps[lapIndex].LapFrames[lapFrameIndex].Values["RrRideHeight"];
            var rideHeightDelta = dynamicHeight - staticHeight;
            var dynamicSpringLoadDelta = -1 * (rideHeightDelta * springRate);
            var dynamicLoad = staticLoad + dynamicSpringLoadDelta;
            return dynamicLoad;
        }
    }
    public class LfDynamicLoadField : TelemetryFrameFieldDefinition
    {
        public LfDynamicLoadField() : base()
        {
            Name = "LfDynamicLoad";
        }

        public override Single GetValue(GraphData graph, TelemetrySessionEx session, int lapIndex, int lapFrameIndex)
        {
            var staticLoad = (Single)graph.SessionValues["LfStaticLoad"];
            var staticHeight = (Single)graph.SessionValues["LfStaticRideHeight"];
            var springRate = (Single)graph.SessionValues["LfSpringRate"];
            var dynamicHeight = (Single)session.Laps[lapIndex].LapFrames[lapFrameIndex].Values["LfRideHeight"];
            var rideHeightDelta = dynamicHeight - staticHeight;
            var dynamicSpringLoadDelta = -1 * (rideHeightDelta * springRate);

            var oppositeDynamicHeight = (Single)session.Laps[lapIndex].LapFrames[lapFrameIndex].Values["RfRideHeight"];
            var swayBarTwist = dynamicHeight - oppositeDynamicHeight;
            var swayBarRate = (Single)graph.SessionValues["SwayBarRate"];
            var dynamicBarLoadDelta = swayBarTwist * swayBarRate;

            var dynamicLoad = staticLoad + dynamicSpringLoadDelta + dynamicBarLoadDelta;

            return dynamicLoad;
        }
    }
    public class RfDynamicLoadField : TelemetryFrameFieldDefinition
    {
        public RfDynamicLoadField() : base()
        {
            Name = "RfDynamicLoad";
        }

        public override Single GetValue(GraphData graph, TelemetrySessionEx session, int lapIndex, int lapFrameIndex)
        {
            var staticLoad = (Single)graph.SessionValues["RfStaticLoad"];
            var staticHeight = (Single)graph.SessionValues["RfStaticRideHeight"];
            var springRate = (Single)graph.SessionValues["RfSpringRate"];
            var dynamicHeight = (Single)session.Laps[lapIndex].LapFrames[lapFrameIndex].Values["RfRideHeight"];
            var rideHeightDelta = dynamicHeight - staticHeight;
            var dynamicSpringLoadDelta = -1 * (rideHeightDelta * springRate);

            var oppositeDynamicHeight = (Single)session.Laps[lapIndex].LapFrames[lapFrameIndex].Values["LfRideHeight"];
            var swayBarTwist = dynamicHeight - oppositeDynamicHeight;
            var swayBarRate = (Single)graph.SessionValues["SwayBarRate"];
            var dynamicBarLoadDelta = swayBarTwist * swayBarRate;

            var dynamicLoad = staticLoad + dynamicSpringLoadDelta + dynamicBarLoadDelta;

            return dynamicLoad;
        }
    }

    public class LapFrameCountField : TelemetryLapFieldDefinition
    {
        public LapFrameCountField() : base()
        {
            Name = "LapFrameCount";
        }

        public override Single GetValue(TelemetrySessionEx session, int lapIndex)
        {
            var value = session.Laps[lapIndex].LapFrames.Count();
            return (Single)value;
        }
    }
    public class LapTimeField : TelemetryLapFieldDefinition
    {
        public LapTimeField() : base()
        {
            Name = "LapTime";
        }

        public override Single GetValue(TelemetrySessionEx session, int lapIndex)
        {
            var value = session.Laps[lapIndex].LapFrames.SelectMany(f => f.Values.Where(v => v.Key == "LapTime")).Min(t => t.Value);
            return (Single)value;
        }
    }
}
