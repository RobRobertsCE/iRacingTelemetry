using iRacing.TelemetryAnalysis.Laps;
using iRacing;
using iRacing.Common;
using iRacing.SetupLibrary.Tires;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iRacing.TrackSession;
using iRacing.TrackSession.Data;
using iRacing.TrackSession.Views;
using TrackSession.Dialogs;
using TrackSession.Controls;
using iRacing.TrackSession.Data.Models;
using log4net;
using Newtonsoft.Json;
using TrackSession.Views;
using System.Diagnostics;
using iRacing.SetupLibrary.Parsers;
using iRacing.TelemetryParser.Session;
using iRacing.TelemetryParser.Session.CarSetup;

namespace TrackSession
{
    public partial class TrackSessionManagerForm : Form
    {
        #region constants 
        private const string MessageLogFile = @"Messages.txt";
        #endregion

        #region fields 
        private static readonly ILog Log = LogManager.GetLogger(typeof(TrackSessionManagerForm));
        protected Size _messageDisplaySize;
        protected TrackSessionManager _manager;
        protected IList<ITrackSessionRunDisplay> Displays { get; set; }
        protected TrackSessionRunView _currentRun;
        #endregion

        #region properties 
        private TrackSessionData _trackSessionData;
        public TrackSessionData TrackSessionData
        {
            get
            {
                if (null == _trackSessionData)
                {
                    _trackSessionData = new TrackSessionData();
                }
                return _trackSessionData;
            }
        }

        protected TrackSessionView _currentSession;
        public TrackSessionView CurrentSession
        {
            get
            {
                return _currentSession;
            }
            private set
            {
                _currentSession = value;
                DisplayCurrentTrackSession();
            }
        }
        #endregion

        #region ctor / init / load
        public TrackSessionManagerForm()
        {
            InitializeComponent();

            InitializeTrackSessionManager();
        }
        protected virtual void InitializeTrackSessionManager()
        {
            try
            {
                _manager = new TrackSessionManager();
                _manager.ManagerStatusChanged += _manager_ManagerStatusChanged;
                _manager.EngineException += _manager_EngineException;
                _manager.SessionRunComplete += _manager_SessionRunComplete;
                _manager.NewTireSheet += _manager_NewTireSheet;
                _manager.TrackSessionStarted += _manager_TrackSessionStarted;

                Displays = new List<ITrackSessionRunDisplay>();
                lstRuns.DisplayMember = "Caption";
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void TrackSessionManager_Load(object sender, EventArgs e)
        {
            try
            {
                ClearRunList();

                if (TrackSessionSettings.AutoStartMonitor)
                    StartManagerEngine();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region start/stop manager engine
        private void tsbStartEngine_Click(object sender, EventArgs e)
        {
            StartManagerEngine();
        }
        private void tsbStopEngine_Click(object sender, EventArgs e)
        {
            StopManagerEngine();
        }
        protected virtual void StartManagerEngine()
        {
            _manager.Start(); ;
            tsbStartEngine.Enabled = false;
            tsbStopEngine.Enabled = true;
        }
        protected virtual void StopManagerEngine()
        {
            _manager.Stop(); ;
            tsbStartEngine.Enabled = true;
            tsbStopEngine.Enabled = false;
        }
        #endregion

        #region run list
        protected virtual void ClearRunList()
        {
            lstRuns.Items.Clear();
        }
        protected virtual void AddRunsToList(IList<TrackSessionRunView> runs)
        {
            ClearRunList();
            foreach (var run in runs)
            {
                AddRunToList(run);
            }
        }
        protected virtual void AddRunToList(TrackSessionRunView run)
        {
            lstRuns.Items.Add(run);
            lstRuns.SelectedItems.Add(run);
        }
        private void lstRuns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRuns.SelectedItems.Count < 1)
                return;

            var lastRun = (TrackSessionRunView)lstRuns.SelectedItems[lstRuns.SelectedItems.Count - 1];
            DisplayRun(lastRun);
        }
        #endregion

        #region open session     
        private void tsbOpenSession_Click(object sender, EventArgs e)
        {
            OpenTrackSession();
        }
        private void openSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTrackSession();
        }
        protected virtual void OpenTrackSession()
        {
            var trackSessionId = DisplayOpenSessionDialog();
            if (trackSessionId.HasValue)
            {
                LoadTrackSession(trackSessionId.Value);
            }
        }
        protected virtual Guid? DisplayOpenSessionDialog()
        {
            try
            {
                using (var dialog = new OpenTrackSession())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        return dialog.TrackSessionId;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            return null;
        }

        protected virtual void LoadTrackSession(Guid trackSessionId)
        {
            try
            {
                var model = LoadTrackSessionModel(trackSessionId);
                if (null != model)
                {
                    ClearTrackSession();
                    CurrentSession = new TrackSessionView(model);
                    DisplayCurrentTrackSession();
                    var runViews = model.Runs.Select(r => new TrackSessionRunView(r)).ToList();
                    AddRunsToList(runViews);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        protected virtual TrackSessionModel LoadTrackSessionModel(Guid trackSessionId)
        {
            TrackSessionModel model = null;
            try
            {
                model = TrackSessionData.GetTrackSession(trackSessionId);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            return model;
        }
        #endregion

        #region open run
        private void tsbOpenRun_Click(object sender, EventArgs e)
        {
            OpenTrackSessionRun();
        }
        private void openRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTrackSessionRun();
        }
        protected virtual void OpenTrackSessionRun()
        {
            var trackSessionRunId = DisplayOpenRunDialog();
            if (trackSessionRunId.HasValue)
                LoadTrackSessionRun(trackSessionRunId.Value);
        }
        protected virtual Guid? DisplayOpenRunDialog()
        {
            return DisplayOpenRunDialog(String.Empty);
        }
        protected virtual Guid? DisplayOpenRunDialog(string caption)
        {
            try
            {
                using (var dialog = new OpenTrackSessionRun())
                {
                    dialog.Text = caption;
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
        protected virtual void LoadTrackSessionRun(Guid trackSessionRunId)
        {
            try
            {
                using (var data = new TrackSessionData())
                {
                    var model = data.GetTrackSessionRun(trackSessionRunId);
                    if (null != model)
                    {
                        CurrentSession = new TrackSessionView(model.TrackSession);
                        DisplayCurrentTrackSession();
                        var view = new TrackSessionRunView(model);
                        AddRunToList(view);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region setups
        private void tsbSaveSetup_Click(object sender, EventArgs e)
        {
            SaveSetup();
        }
        private void saveSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSetup();
        }
        protected virtual void SaveSetup()
        {
            if (null != _currentRun)
            {
                using (var data = new TrackSessionData())
                {
                    var setupModel = data.GetSetup(_currentRun.SetupId);
                    var vehicle = data.GetVehicle(setupModel.VehicleNumber);
                    var directoryPath = Path.Combine(iRacing.Constants.iRacingSetupDirectory, vehicle.Path);
                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.InitialDirectory = directoryPath;
                        dialog.FileName = setupModel.Name;
                        dialog.Filter = "Setup Files (*.sto)|*.sto|All Files (*.*)|*.*";
                        dialog.FilterIndex = 0;
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            SaveSetupBinary(dialog.FileName, setupModel.SetupBinary);
                        }
                    }
                }
            }
        }
        protected virtual void AutoSaveSetup()
        {
            if (null != _currentRun)
            {
                using (var data = new TrackSessionData())
                {
                    var setupModel = data.GetSetup(_currentRun.SetupId);
                    var vehicle = data.GetVehicle(setupModel.VehicleNumber);
                    var directoryPath = Path.Combine(iRacing.Constants.iRacingSetupDirectory, vehicle.Path);
                    var fileTitle = Path.GetFileNameWithoutExtension(setupModel.Name);
                    var fileName = String.Format("{0}_Run{1:0#}.sto", fileTitle, _currentRun.RunNumber);
                    SaveSetupBinary(fileName, setupModel.SetupBinary);
                }
            }
        }
        protected virtual void SaveSetupBinary(string fileName, byte[] setupBinary)
        {
            File.WriteAllBytes(fileName, setupBinary);
        }
        private void compareSetupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareSetups();
        }
        protected virtual SetupViewBase.SetupValues GetSetupValues(string setupJson)
        {
            var sessionInfo = TelemetrySessionInfoFactory.GetSessionInfo(setupJson);

            if (sessionInfo is ModifiedTelemetrySessionInfo)
            {
                var modSetup = ((ModifiedTelemetrySessionInfo)sessionInfo).CarSetup;
                return SetupViewBase.GetProperties(modSetup);
            }

            return null;
        }
        protected virtual void CompareSetups()
        {
            var trackSessionRunId1 = DisplayOpenRunDialog("Select the first Setup to compare");
            if (!trackSessionRunId1.HasValue) return;
            var trackSessionRunId2 = DisplayOpenRunDialog("Select the second Setup to compare");
            if (!trackSessionRunId2.HasValue) return;

            using (var data = new TrackSessionData())
            {
                var model1 = data.GetTrackSessionRun(trackSessionRunId1.Value);
                var setupModel1 = model1.Setup;
                var model2 = data.GetTrackSessionRun(trackSessionRunId2.Value);
                var setupModel2 = model2.Setup;
                var differences = CompareSetups(setupModel1, setupModel2);
                DisplaySetupDifferences(differences);
            }
        }
        protected virtual IList<string> CompareSetups(SetupModel setupModel1, SetupModel setupModel2)
        {
            var changes = new List<string>();
            try
            {
                SetupViewBase.SetupValues sv1 = GetSetupValues(setupModel1.SetupJSON);
                SetupViewBase.SetupValues sv2 = GetSetupValues(setupModel2.SetupJSON);
                foreach (var group1 in sv1.SetupGroups)
                {
                    var group2 = sv2.SetupGroups[group1.Key];
                    foreach (var item1 in group1.Value)
                    {
                        var item2 = group2[item1.Key];
                        if (item1.Value != item2)
                        {
                            var change = String.Format("{0}: {1} -> {2}", item1.Key, item1.Value, item2);
                            changes.Add(change);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return changes;
        }
        protected virtual void DisplaySetupDifferences(IList<string> differences)
        {
            foreach (var diff in differences)
            {
                Console.WriteLine(diff);
            }
        }
        #endregion

        #region manager events
        private void _manager_TrackSessionStarted(object sender, TrackSessionStartedArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                LoadTrackSession(e.TrackSessionId); // runs on UI thread
            });
        }

        private void _manager_NewTireSheet(object sender, NewTireSheetArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                DisplayTireSheet(e.TireSheet); // runs on UI thread
            });
        }

        private void _manager_SessionRunComplete(object sender, TrackSessionRunCompleteArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                LoadTrackSessionRun(e.TrackSessionRunId); // runs on UI thread

                if (TrackSessionSettings.AutoSaveSetup)
                    AutoSaveSetup();
            });
        }

        private void _manager_EngineException(object sender, EngineExceptionArgs e)
        {
            ExceptionHandler(e.Exception);
        }

        private void _manager_ManagerStatusChanged(object sender, ManagerStatusChangedArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ManagerStatusChanged(e); // runs on UI thread
            });
        }
        #endregion

        #region status changes
        protected virtual void ManagerStatusChanged(ManagerStatusChangedArgs e)
        {
            Console.WriteLine("Manager Status Changed: {0}->{1}", e.OldStatus, e.NewStatus);

            if (e.NewStatus == ManagerStatus.Off)
            {
                lblSession.Text = "App Not Running";
                lblProcessStatus.BackColor = Color.Gray;
            }
            if (e.NewStatus == ManagerStatus.Idle)
            {
                lblSession.Text = "No Active Session";
                lblProcessStatus.BackColor = Color.White;
            }
            if (e.NewStatus == ManagerStatus.Monitoring)
            {
                lblProcessStatus.BackColor = Color.Green;
            }
            if (e.NewStatus == ManagerStatus.Busy)
            {
                lblProcessStatus.BackColor = Color.LimeGreen;
            }
        }
        #endregion

        #region track session   
        /// <summary>
        /// Displays the currently TrackSessionView
        /// </summary>  
        protected virtual void DisplayCurrentTrackSession()
        {
            lblSession.Text = String.Format("{0} {1} {2}", CurrentSession.SessionTypeName, CurrentSession.TrackName, CurrentSession.CarName);

        }
        protected virtual void ClearTrackSession()
        {
            ClearRunList();
            lblSession.Text = "No Active Session";
        }
        #endregion

        #region track session run       
        protected virtual void DisplayRun(TrackSessionRunView run)
        {
            _currentRun = run;
            // this.lblRunNumber.Text = String.Format("Run {0}", run.RunNumber);

            var analysis = GetLapTimesAnalysis(run);
            lapsView1.LapTimes = analysis.Laps.LapTimesOnly();

            using (var data = new TrackSessionData())
            {
                var setupModel = data.GetSetup(run.SetupId);
                var sessionInfo = TelemetrySessionInfoFactory.GetSessionInfo(setupModel.SetupJSON);
                //var parser = new JsonSetupParser();
                //var vehicle = data.GetVehicle(CurrentSession.CarID);
                //var setup = parser.GetSetup((Vehicles)CurrentSession.CarID, sessionInfo.SetupJSON);
                setupView1.modifiedSetupBindingSource.DataSource = ((ModifiedTelemetrySessionInfo)sessionInfo).CarSetup;
            }

            //if (analysis.Laps.Count > 0)
            //{
            //    this.lblRunLapCount.Text = String.Format("{0} Laps", analysis.Laps.Count);
            //    if (analysis.Laps.Count() > 0)
            //    {
            //        this.lblBestLap.Text = analysis.Best.ToString("0.###");
            //        this.lblAverageLap.Text = analysis.Average.ToString("0.###");
            //    }
            //    else
            //    {
            //        this.lblBestLap.Text = "-";
            //        this.lblAverageLap.Text = "-";
            //    }
            //}
            //else
            //{
            //    this.lblRunLapCount.Text = "-";
            //    this.lblBestLap.Text = "-";
            //    this.lblAverageLap.Text = "-";
            //}      
        }
        #endregion

        #region tire sheet
        private void tsbOpenTireSheet_Click(object sender, EventArgs e)
        {
            OpenTireSheet();
        }
        private void openTireSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTireSheet();
        }
        protected virtual void OpenTireSheet()
        {
            var tireSheetFile = DisplayOpenTireSheetDialog();
            if (!String.IsNullOrEmpty(tireSheetFile))
                LoadTireSheet(tireSheetFile);
        }
        protected virtual string DisplayOpenTireSheetDialog()
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = iRacing.Constants.iRacingSetupDirectory;
                    dialog.Filter = "Setup Exports (*.htm)|*.htm|All Files (*.*)|*.*";
                    dialog.FilterIndex = 0;
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        return dialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            return null;
        }
        protected virtual void LoadTireSheet(string tireSheetFile)
        {
            try
            {
                var tireSheetContents = File.ReadAllText(tireSheetFile);
                var parser = new HtmlExportParser();
                TireSheet tireSheet = parser.GetTireSheet(tireSheetContents);
                DisplayTireSheet(tireSheet);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void DisplayTireSheet(TireSheet tireSheet)
        {
            this.tireSheetView.tireSheetBindingSource.DataSource = tireSheet;
        }
        #endregion

        #region laps
        protected virtual LapTimeAnalysis GetLapTimesAnalysis(TrackSessionRunView run)
        {
            var telemetryParser = new iRacing.TelemetryParser.ParserEngine();
            using (var data = new TrackSessionData())
            {
                var telemetry = data.GetTelemetry(run.TelemetryId);
                var telemetryData = telemetryParser.ParseTelemetryBytes(telemetry.BinaryData);
                return new LapTimeAnalysis(telemetryData.Laps);
            }
        }
        #endregion

        #region telemetry
        private void tsbOpenTelemetry_Click(object sender, EventArgs e)
        {
            OpenTelemetry();
        }
        private void openTelemetryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTelemetry();
        }
        protected virtual void OpenTelemetry()
        {
            using (var dialog = new TelemetryDialog())
            {
                dialog.ShowDialog(this);
            }
        }
        #endregion

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test();
        }
        private void Test()
        {
            SetupViewBase.SetupValues sv1 = null;
            SetupViewBase.SetupValues sv2 = null;

            try
            {
                var telemetryParser = new iRacing.TelemetryParser.ParserEngine();
                using (var data = new TrackSessionData())
                {
                    var runs = data.GetTrackSessionRuns();
                    var modRuns = runs.Where(r => r.Setup.VehicleNumber == (int)Vehicles.skmodified).ToList();

                    var run1 = modRuns[0];
                    var setupModel1 = data.GetSetup(run1.SetupId);
                    var sessionInfo1 = TelemetrySessionInfoFactory.GetSessionInfo(setupModel1.SetupJSON);

                    if (sessionInfo1 is ModifiedTelemetrySessionInfo)
                    {
                        var modSetup1 = ((ModifiedTelemetrySessionInfo)sessionInfo1).CarSetup;
                        sv1 = SetupViewBase.GetProperties(modSetup1);
                    }

                    var run2 = modRuns.LastOrDefault();
                    var setupModel2 = data.GetSetup(run2.SetupId);
                    var sessionInfo2 = TelemetrySessionInfoFactory.GetSessionInfo(setupModel2.SetupJSON);

                    if (sessionInfo2 is ModifiedTelemetrySessionInfo)
                    {
                        var modSetup2 = ((ModifiedTelemetrySessionInfo)sessionInfo2).CarSetup;
                        sv2 = SetupViewBase.GetProperties(modSetup2);
                    }

                    // compare the two setups
                    foreach (var group1 in sv1.SetupGroups)
                    {
                        var group2 = sv2.SetupGroups[group1.Key];
                        foreach (var item1 in group1.Value)
                        {
                            var item2 = group2[item1.Key];
                            if (item1.Value == item2)
                            {
                                Console.WriteLine("{0}: {1} matches {2}", item1.Key, item1.Value, item2);
                            }
                            else
                            {
                                Console.WriteLine("{0}: {1} DOES NOT MATCH {2}", item1.Key, item1.Value, item2);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected virtual string LapsToJson(IDictionary<int, float> laps)
        {
            JsonSerializer jsonSerializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (var jsonStreamWriter = new StringWriter())
            {
                jsonSerializer.Serialize(jsonStreamWriter, laps);
                return jsonStreamWriter.ToString();
            }
        }

        #region common
        #region settings
        private void tsbSettings_Click(object sender, EventArgs e)
        {
            DisplaySettingsDialog();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplaySettingsDialog();
        }
        protected virtual void DisplaySettingsDialog()
        {
            using (var dialog = new TrackSessionSettingsDialog())
            {
                dialog.ShowDialog(this);
            }
        }
        #endregion
        #region messages
        #region control events
        private void messagesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (messagesToolStripMenuItem.Checked)
            {
                ShowMessages();
            }
            else
            {
                HideMessages();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMessages();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CopyMessages();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearMessages();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                messagesToolStripMenuItem.Checked = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion
        protected virtual void DisplayMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(message);
            });
            PrintMessage(message);
        }
        protected virtual void PrintMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                var newMessage = String.Format("{0}: {1}\r\n", DateTime.Now, message);
                txtMessages.AppendText(newMessage);
                txtMessages.SelectionStart = txtMessages.TextLength;
                txtMessages.ScrollToCaret();
            });
        }
        protected virtual void HideMessages()
        {
            _messageDisplaySize = pnlMessages.Size;
            pnlMessages.Height = 0;
        }
        protected virtual void ShowMessages()
        {
            pnlMessages.Size = _messageDisplaySize;
        }
        protected virtual void ClearMessages()
        {
            txtMessages.Clear();
        }
        protected virtual void CopyMessages()
        {
            txtMessages.SelectAll();
            txtMessages.Copy();
            txtMessages.SelectionLength = 0;
            DisplayMessage("Message Log text copied to clipboard");
        }
        protected virtual void SaveMessages()
        {
            try
            {
                File.WriteAllText(MessageLogFile, txtMessages.Text);
                DisplayMessage(String.Format("Message Log saved to {0}", MessageLogFile));
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion
        #region exceptions
        protected virtual void ExceptionHandler(Exception ex)
        {
            var exceptionMessage = String.Format("***** EXCEPTION *****\r\n{0}\r\n", ex.ToString());
            PrintMessage(exceptionMessage);
            LogMessage(exceptionMessage);
            Console.WriteLine(exceptionMessage);
        }
        #endregion
        #region logging
        protected virtual void LogMessage(string message)
        {
            Log.Info(message);
        }
        protected virtual void LogErrorMessage(string message)
        {
            Log.Error(message);
        }

        private void openMessageLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLogFile();
        }
        private void tsbLogView_Click(object sender, EventArgs e)
        {
            OpenLogFile();
        }
        protected virtual void OpenLogFile()
        {
            Process.Start(Logger.LogFileName);
        }
        #endregion

        #region form close
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseRequested();
        }
        protected virtual void CloseRequested()
        {
            this.Close();
        }

        #endregion

        #endregion

        #region displays  
        private void tsbLapView_CheckedChanged(object sender, EventArgs e)
        {
            this.splLaps.Panel1Collapsed = !tsbLapView.Checked;
        }
        #endregion
    }
}
