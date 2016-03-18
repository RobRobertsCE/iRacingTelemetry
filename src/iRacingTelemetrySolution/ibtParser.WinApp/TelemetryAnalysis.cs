using System;
using System.Windows.Forms;
using iRacing.TelemetryParser;
using iRacing.TelemetryAnalysis.Shocks;
using iRacing.TelemetryAnalysis.Composite;

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
    }
}
