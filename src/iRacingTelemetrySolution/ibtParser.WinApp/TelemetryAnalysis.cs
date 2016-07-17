using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using iRacing.TelemetryParser;
using iRacing.TelemetryAnalysis.Shocks;
using iRacing.TelemetryAnalysis.Composite;
using Newtonsoft.Json;
using System.Drawing;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using System.Text;

namespace ibtParser.WinApp
{
    public partial class TelemetryAnalysis : Form
    {
        #region locals
        const string DefaultDirectory = @"C:\Users\rroberts\Source\Repos\ircc\src\ibtParser\iRacing.TelemetryParser\Samples\";

        ParserEngine _engine;
        TelemetrySession _session;
        ShockAnalysis _analysis;
        string _shockAnalysisReport;
        string _deflectionAnalysisReport;
        #endregion

        #region ctor
        public TelemetryAnalysis()
        {
            InitializeComponent();
            _engine = new ParserEngine();
        }
        #endregion

        #region control event handlers

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            DisplayLap(_session, dataGridView1.SelectedRows[0].Index);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (dataGridView2.SelectedRows.Count == 0) return;

            DisplayLapFrames(dataGridView1.SelectedRows[0].Index, dataGridView2.SelectedRows[0].Index);
        }

        private void dataGridView3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.ToString());
            e.ThrowException = false;
        }


        private void tsbShockAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                RunShockAnalysis();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        private void tsbCloseFile_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        #endregion

        #region common
        private void DisplayMessage()
        {
            DisplayMessage(String.Empty);
        }
        private void DisplayMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                this.txtMessages.AppendText(Environment.NewLine);

            this.txtMessages.AppendText(message);
        }
        #endregion

        #region Load Telemetry Data
        private void OpenFile()
        {
            try
            {
                ResetFormState();

                var telemetryFile = LoadTelemetryFile();
                if (string.IsNullOrEmpty(telemetryFile)) return;
                _session = ParseTelemetryFile(telemetryFile);
                DisplaySessionData(_session);

                tsbShockAnalysis.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void CloseFile()
        {
            ResetFormState();
        }

        void ResetFormState()
        {
            tsbShockAnalysis.Enabled = false;
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            this.dataGridView3.DataSource = null;
            _engine = null;
            _session = null;
            _analysis = null;
            _shockAnalysisReport = String.Empty;
            _deflectionAnalysisReport = String.Empty;
        }

        private string LoadTelemetryFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".ibt";
            dialog.InitialDirectory = DefaultDirectory;
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.FileName;
            else
                return String.Empty;
        }

        private TelemetrySession ParseTelemetryFile(string telemetryFileName)
        {
            if (null == _engine)
                _engine = new ParserEngine();
            return _engine.ParseTelemetryFile(telemetryFileName, false);
        }

        private void DisplaySessionData(TelemetrySession session)
        {
            lblFile.Text = System.IO.Path.GetFileName(session.FileName);
            lblLapCount.Text = String.Format("{0} Laps", session.Laps.Count);
            lblFrameCount.Text = String.Format("{0} Frames", session.Frames.Count);

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = session.Laps;

            if (session.Laps.Count > 0)
                DisplayLap(session, 0);
        }

        void DisplayLap(TelemetrySession session, int idx)
        {
            this.dataGridView2.AutoGenerateColumns = true;
            int currentSelectedRow = 0;
            if (dataGridView2.SelectedRows.Count > 0)
            {
                currentSelectedRow = dataGridView2.SelectedRows[0].Index;
            }
            dataGridView2.ClearSelection();
            dataGridView2.DataSource = session.Laps[idx].Frames;
            if (_session.Laps[idx].Frames.Count < currentSelectedRow)
                currentSelectedRow = 0;
            dataGridView2.Rows[currentSelectedRow].Selected = true;
            dataGridView2.FirstDisplayedScrollingRowIndex = currentSelectedRow;
        }

        void DisplayLapFrames(int lapIdx, int frameIdx)
        {
            this.dataGridView3.AutoGenerateColumns = true;
            int currentSelectedRow = 0;
            if (dataGridView3.SelectedRows.Count > 0)
            {
                currentSelectedRow = dataGridView3.SelectedRows[0].Index;
            }
            dataGridView3.ClearSelection();
            this.dataGridView3.DataSource = _session.Laps[lapIdx].Frames[frameIdx].ChannelValues;
            if (_session.Laps[lapIdx].Frames[frameIdx].ChannelValues.Count < currentSelectedRow)
                currentSelectedRow = 0;
            dataGridView3.Rows[currentSelectedRow].Selected = true;
            dataGridView3.FirstDisplayedScrollingRowIndex = currentSelectedRow;
        }
        #endregion

        #region Analysis
        private void RunShockAnalysis()
        {
            if (null == _analysis)
                _analysis = LoadShockVelocityAnalysisData();

            _shockAnalysisReport = _analysis.PerformVelocityAnalysis();
            _deflectionAnalysisReport = _analysis.PerformDeflectionAnalysis();

            DisplayMessage(_shockAnalysisReport);
            DisplayMessage();
            DisplayMessage(_deflectionAnalysisReport);

        }

        private ShockAnalysis LoadShockVelocityAnalysisData()
        {
            var shockAnalysis = new ShockAnalysis();
            int idx = 0;
            foreach (var lap in _session.Laps)
            {
                foreach (var frame in lap.Frames)
                {
                    var deflection = new ShockDeflection()
                    {
                        Idx = idx,
                        Lap = frame.GetIntValue(TelemetryKeys.Lap),
                        LapDistance = frame.GetSingleValue(TelemetryKeys.LapDist),
                        LapDistancePercent = frame.GetSingleValue(TelemetryKeys.LapDistPct),
                        LF = frame.GetSingleValue(TelemetryKeys.LFshockDefl),
                        LR = frame.GetSingleValue(TelemetryKeys.LRshockDefl),
                        RF = frame.GetSingleValue(TelemetryKeys.RFshockDefl),
                        RR = frame.GetSingleValue(TelemetryKeys.RRshockDefl)
                    };
                    shockAnalysis.Deflections.Add(deflection);

                    var rideHeight = new RideHeight()
                    {
                        Idx = idx,
                        Lap = frame.GetIntValue(TelemetryKeys.Lap),
                        LapDistance = frame.GetSingleValue(TelemetryKeys.LapDist),
                        LapDistancePercent = frame.GetSingleValue(TelemetryKeys.LapDistPct),
                        LF = frame.GetSingleValue(TelemetryKeys.LFrideHeight),
                        LR = frame.GetSingleValue(TelemetryKeys.LRrideHeight),
                        RF = frame.GetSingleValue(TelemetryKeys.RFrideHeight),
                        RR = frame.GetSingleValue(TelemetryKeys.RRrideHeight)
                    };
                    shockAnalysis.RideHeights.Add(rideHeight);

                    // Converting from m/s to mm/s (*1000)
                    var velo = new ShockVelocity()
                    {
                        Idx = idx,
                        Lap = frame.GetIntValue(TelemetryKeys.Lap),
                        LapDistance = frame.GetSingleValue(TelemetryKeys.LapDist),
                        LapDistancePercent = frame.GetSingleValue(TelemetryKeys.LapDistPct),
                        LF = frame.GetSingleValue(TelemetryKeys.LFshockVel) * 1000,
                        LR = frame.GetSingleValue(TelemetryKeys.LRshockVel) * 1000,
                        RF = frame.GetSingleValue(TelemetryKeys.RFshockVel) * 1000,
                        RR = frame.GetSingleValue(TelemetryKeys.RRshockVel) * 1000
                    };
                    shockAnalysis.Velocities.Add(velo);
                    idx++;
                }
            }
            return shockAnalysis;
        }
        #endregion

        private void tsbComposite_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnWriteTelemetryFile_Click(object sender, EventArgs e)
        {
            try
            {
                //var w = new TelemetryWriterEngine();
                //w.Session = _session;
                //SaveFileDialog dialog = new SaveFileDialog();
                //dialog.InitialDirectory = @"C: \Users\rroberts\Source\Repos\ircc\src\ibtParser\iRacing.TelemetryParser\Samples\";
                //dialog.FileName = "testing.ibt";
                //if (dialog.ShowDialog()==DialogResult.OK)
                //    w.WriteSessionToTemeletryFile(dialog.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnGpsYaw_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                var json = System.IO.File.ReadAllText(@"C:\Users\rroberts\Documents\iRacing\Json\GpsYawData.json");
                var gpsYawDataSet = JsonConvert.DeserializeObject<List<GpsYawData>>(json);
                var analysisDataSet = new List<GpsYawDataAnalysis>();
                GpsYawDataAnalysis previousDataPoint = null;
                var sampleSet = gpsYawDataSet.Skip(4042).Take(1347);
                //sb.AppendLine("[Yaw], [Yaw Delta], [Heading], [Heading Delta], [LatDelta], [LonDelta], [VDelta]");

                sb.Append("analysis.Yaw,");
                sb.Append("analysis.YawDelta,");
                sb.Append("RadianToDegree(analysis.Yaw)," );
                sb.Append("RadianToDegree(analysis.YawDelta)," );
                sb.Append("analysis.Heading," );
                sb.Append("analysis.HeadingDelta," );
                sb.Append("RadianToDegree(analysis.Heading)," );
                sb.Append("RadianToDegree(analysis.HeadingDelta)," );
                sb.Append("analysis.VelocityX," );
                sb.Append("analysis.VelocityY," );
                sb.Append("analysis.Lat," );
                sb.Append("analysis.Lon," );
                sb.Append("analysis.LatDelta," );
                sb.Append("analysis.LonDelta");
                sb.AppendLine();

                foreach (GpsYawData data in sampleSet)
                {
                    var analysis = new GpsYawDataAnalysis()
                    {
                        FrameIdx = data.FrameIdx,
                        LapNumber = data.LapNumber,
                        Lat = data.Lat,
                        Lon = data.Lon,
                        YawRate = data.YawRate,
                        SteeringAngle = data.SteeringAngle,
                        VelocityX = data.VelocityX,
                        VelocityY = data.VelocityY,
                        Yaw = data.Yaw
                    };

                    if (null != previousDataPoint)
                    {
                        analysis.PreviousDataPoint = previousDataPoint;
                        analysis.DistanceTravelled = distance(previousDataPoint.Lat, previousDataPoint.Lon, analysis.Lat, analysis.Lon);
                        if (analysis.DistanceTravelled > 0)
                        {
                            analysis.Heading = heading(previousDataPoint.Lat, previousDataPoint.Lon, analysis.Lat, analysis.Lon);
                            //Single[] velX = { 0, analysis.VelocityX };
                            //Single[] velY = { 0, analysis.VelocityY };
                            //Vector<Single> vX = Vector<Single>.Build.Dense(velX);
                            //Vector<Single> vY = Vector<Single>.Build.Dense(velY);
                            //var vDot = vX.DotProduct(vY);
                            Single[] velLat = { 0, analysis.Lat };
                            Single[] velLon = { 0, analysis.Lon };
                            Vector<Single> vX = Vector<Single>.Build.Dense(velLat);
                            Vector<Single> vY = Vector<Single>.Build.Dense(velLon);
                            analysis.VectorDotProduct = vX.DotProduct(vY);

                            //sb.AppendFormat("{0},{1},{2},{3},{4}\r\n", 
                            //    String.Format("{0},{1}", 
                            //    RadianToDegree(analysis.Yaw), 
                            //    RadianToDegree(analysis.YawDelta)), 
                            //    String.Format("{0},{1}", 
                            //    RadianToDegree(analysis.Heading), 
                            //    RadianToDegree(analysis.HeadingDelta)), 
                            //    analysis.VelocityX, 
                            //    analysis.VelocityY, 
                            //    analysis.VDelta.ToVectorString());

                            sb.AppendFormat("{0},", analysis.Yaw);
                            sb.AppendFormat("{0},", analysis.YawDelta);
                            sb.AppendFormat("{0},", RadianToDegree(analysis.Yaw));
                            sb.AppendFormat("{0},", RadianToDegree(analysis.YawDelta));
                            sb.AppendFormat("{0},", analysis.Heading);
                            sb.AppendFormat("{0},", analysis.HeadingDelta);
                            sb.AppendFormat("{0},", RadianToDegree(analysis.Heading));
                            sb.AppendFormat("{0},", RadianToDegree(analysis.HeadingDelta));
                            sb.AppendFormat("{0},", analysis.VelocityX);
                            sb.AppendFormat("{0},", analysis.VelocityY);
                            sb.AppendFormat("{0},", analysis.Lat);
                            sb.AppendFormat("{0},", analysis.Lon);
                            sb.AppendFormat("{0},", analysis.LatDelta);
                            sb.AppendFormat("{0},", analysis.LonDelta);
                            sb.AppendLine();
                            //sb.AppendFormat("{0},{1},{2},{3},{4}\r\n",
                            //  String.Format("{0},{1}",
                            //  RadianToDegree(analysis.Yaw),
                            //  RadianToDegree(analysis.YawDelta)),
                            //  String.Format("{0},{1}",
                            //  RadianToDegree(analysis.Heading),
                            //  RadianToDegree(analysis.HeadingDelta)),
                            //  analysis.LatDelta,
                            //  analysis.LonDelta,
                            //  );
                        }
                        // velocity x and velocity y are based on the car always pointing at x+, not based on earch x,y coordinates.
                    }
                    analysisDataSet.Add(analysis);
                    previousDataPoint = analysis;

                }
                System.IO.File.WriteAllText(@"C:\Users\rroberts\Documents\iRacing\Json\analysis.csv", sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private Double distance(Double lat1, Double lon1, Double lat2, Double lon2)
        {
            var p = 0.017453292519943295;    // Math.PI / 180
            //var c = Math.cos;
            var a = 0.5 - Math.Cos((lat2 - lat1) * p) / 2 +
                    Math.Cos(lat1 * p) * Math.Cos(lat2 * p) *
                    (1 - Math.Cos((lon2 - lon1) * p)) / 2;

            return 12742 * Math.Asin(Math.Sqrt(a)); // 2 * R; R = 6371 km
        }

      
        // φ1 = lat1
        // λ1 = lon1
        // φ2 = lat2
        // λ2 = lon2
        private Double heading(Double lat1, Double lon1, Double lat2, Double lon2)
        {
            //var y = Math.Sin(λ2 - λ1) * Math.Cos(φ2);
            //var x = Math.Cos(φ1) * Math.Sin(φ2) -
            //        Math.Sin(φ1) * Math.Cos(φ2) * Math.Cos(λ2 - λ1);
            var y = Math.Sin(lon2 - lon1) * Math.Cos(lat2);
            var x = Math.Cos(lat1) * Math.Sin(lat2) -
                    Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1);
            var brng = RadianToDegree(Math.Atan2(y, x));//.toDegrees();
            return brng; // in radians
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DumpGpsYawData();
        }
        void DumpGpsYawData()
        {
            try
            {
                var data = new List<GpsYawData>();
                var frameIdx = 0;
                foreach (var telemetryFrame in _session.Frames)
                {
                    var frameData = new GpsYawData()
                    {
                        FrameIdx = frameIdx,
                        LapNumber = telemetryFrame.GetIntValue("Lap"),
                        Lat = telemetryFrame.GetSingleValue("Lat"),
                        Lon = telemetryFrame.GetSingleValue("Lon"),
                        YawRate = telemetryFrame.GetSingleValue("YawRate"),
                        Yaw = telemetryFrame.GetSingleValue("Yaw"),
                        SteeringAngle = telemetryFrame.GetSingleValue("SteeringWheelAngle"),
                        VelocityX = telemetryFrame.GetSingleValue("VelocityX"),
                        VelocityY = telemetryFrame.GetSingleValue("VelocityY")
                    };
                    data.Add(frameData);
                    frameIdx++;
                }

                var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\Users\rroberts\Documents\iRacing\Json\GpsYawData.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public class GpsYawData
    {
        public int FrameIdx { get; set; }
        public int LapNumber { get; set; }
        public Single Lat { get; set; }
        public Single Lon { get; set; }
        public Single Yaw { get; set; }
        public Single YawRate { get; set; }
        public Single SteeringAngle { get; set; }
        public Single VelocityX { get; set; }
        public Single VelocityY { get; set; }
    }

    public class GpsYawDataAnalysis : GpsYawData
    {
        public GpsYawDataAnalysis PreviousDataPoint { get; set; }
        public PointF DirectionalVector { get; set; }
        public Single VectorDotProduct { get; set; }
        public double DistanceTravelled { get; set; }
        public double Heading { get; set; }
        public double YawDelta
        {
            get
            {
                return Yaw - PreviousDataPoint.Yaw;
            }
        }
        public double HeadingDelta
        {
            get
            {
                return Heading - PreviousDataPoint.Heading;
            }
        }
        public double VectorDotProductDelta
        {
            get
            {
                return VectorDotProduct - PreviousDataPoint.VectorDotProduct;
            }
        }
        public Single LatDelta
        {
            get
            {
                return Lat - PreviousDataPoint.Lat;
            }
        }
        public Single LonDelta
        {
            get
            {
                return Lon - PreviousDataPoint.Lon;
            }
        }
        public Vector<Single> VDelta
        {
            get
            {
                Single[] velLon = { LatDelta, LonDelta };
                return Vector<Single>.Build.Dense(velLon);
            }
        }
        
    }
}
