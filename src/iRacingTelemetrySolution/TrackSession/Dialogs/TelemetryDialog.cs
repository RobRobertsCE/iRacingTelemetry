using ibtParserLibrary;
using iRacing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestSessionLibrary.Data;
using TestSessionLibrary.Data.Models;

namespace TrackSession.Dialogs
{
    public partial class TelemetryDialog : Form
    {
        #region properties
        public TelemetryModel Telemetry { get; set; }
        #endregion

        #region ctor/load
        public TelemetryDialog()
        {
            InitializeComponent();
        }
        public TelemetryDialog(TelemetryModel telemetry) : this()
        {
            this.Telemetry = telemetry;
        }
        private void TelemetryDialog_Load(object sender, EventArgs e)
        {
            if (null != Telemetry)
            {
                DisplayTelemetry(Telemetry);
            }
        }
        #endregion

        #region open telemetry
        private void openRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTrackSessionRun();
        }
        protected virtual void OpenTrackSessionRun()
        {
            var trackSessionRunId = DisplayOpenRunDialog();
            if (trackSessionRunId.HasValue)
            {
                Telemetry = LoadTelemetry(trackSessionRunId.Value);
                if (null != Telemetry)
                {
                    DisplayTelemetry(Telemetry);
                }
            }
        }
        protected virtual Guid? DisplayOpenRunDialog()
        {
            try
            {
                using (var dialog = new OpenTrackSessionRun())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        return dialog.TrackSessionRunId;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            return null;
        }
        protected virtual TelemetryModel LoadTelemetry(Guid trackSessionRunId)
        {
            try
            {
                using (var data = new TrackSessionData())
                {
                    var model = data.GetTrackSessionRun(trackSessionRunId);
                    if (null != model)
                    {
                        return model.Telemetry;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            return null;
        }
        protected virtual void DisplayTelemetry(TelemetryModel model)
        {

        }
        #endregion

        #region exceptions
        protected virtual void ExceptionHandler(Exception ex)
        {
            var exceptionMessage = String.Format("***** EXCEPTION *****\r\n{0}\r\n", ex.ToString());
            DisplayMessage(exceptionMessage);
            LogErrorMessage(exceptionMessage);
            Console.WriteLine(exceptionMessage);
        }
        protected virtual void DisplayMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(message);
            });
        }
        #endregion

        #region logging
        protected virtual void LogMessage(string message)
        {
            Logger.Log.Info(message);
        }
        protected virtual void LogErrorMessage(string message)
        {
            Logger.Log.Error(message);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sampleFile = @"C:\Users\rroberts\Source\Repos\iRacingTelemetry\src\iRacingTelemetrySolution\Samples\Telemetry\skmodified_langley 2015-05-28 14-50-46.ibt";

                var data = TelemetryFileParser.ParseTelemetryFile(sampleFile);

                var laps = TelemetryLapsParser.ParseLaps(data);

                LapInfos = new List<LapInfo>();
                var lapBuffer = new Dictionary<int, float>();
                
                foreach (var lap in laps)
                {
                    var lastFrame = lap.Frames.LastOrDefault();
                    if (lastFrame!= null)
                    {
                        int currentlap = Convert.ToInt32(lastFrame.ChannelValues[(int)TelemetryKeys.Lap].Value);
                        if (currentlap>0)
                        {
                            int previousLap = currentlap - 1;
                            if (!lapBuffer.ContainsKey(previousLap))
                            {
                                var lastLapTime = Convert.ToSingle(lastFrame.ChannelValues[(int)TelemetryKeys.LapLastLapTime].Value);
                                lapBuffer.Add(previousLap, 0F);
                                LapInfos.Add(new LapInfo()
                                {
                                    Lap = previousLap,                                    
                                    LastLapTime = lastLapTime
                                });
                            }
                        }
                    }
                }

                dg.DataSource = LapInfos;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        public IList<LapInfo> LapInfos { get; set; }
        public class LapInfo
        {
            public int Lap { get; set; }
            public float LastLapTime { get; set; }
        }
    }
}
