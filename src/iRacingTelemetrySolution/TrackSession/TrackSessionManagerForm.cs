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
using TrackSession.Views;

namespace TrackSession
{
    public partial class TrackSessionManagerForm : Form
    {
        #region constants 
        private const string MessageLogFile = @"Messages.txt";
        #endregion

        #region fields 
        protected Size _messageDisplaySize;
        protected TrackSessionManager _manager;
        protected TrackSessionView _currentSession;
        protected IList<ITrackSessionRunDisplay> Displays { get; set; }
        #endregion

        #region properties 

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
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
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
            Logger.Log.Info(message);
        }
        protected virtual void LogErrorMessage(string message)
        {
            Logger.Log.Error(message);
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
        protected virtual void DisplayRun(TrackSessionRunView run)
        {
            DisplayRunDetails(run);
            foreach (var display in Displays)
            {
                if (display.IsActive)
                    display.DisplayRun(run);
            }
        }
        protected virtual void DisplayRunDetails(TrackSessionRunView run)
        {
            this.lblRunNumber.Text = String.Format("Run {0}", run.RunNumber);
           
            var analysis = GetLapTimesAnalysis(run);
            trackRunResultsView1.lapsView1.LapTimes = analysis.Laps.LapTimesOnly();

            if (analysis.Laps.Count>0)
            {
                this.lblRunLapCount.Text = String.Format("{0} Laps", analysis.Laps.Count);
                if (analysis.Laps.Count() > 0)
                {
                    this.lblBestLap.Text = analysis.BestLapTime.ToString();
                    this.lblAverageLap.Text = analysis.Average.ToString();
                }
                else
                {
                    this.lblBestLap.Text = "-";
                    this.lblAverageLap.Text = "-";
                }
            }
            else
            {
                this.lblRunLapCount.Text = "-";
                this.lblBestLap.Text = "-";
                this.lblAverageLap.Text = "-";
            }
        }
        #endregion

        #region open session       
        private void openSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTrackSession();
        }
        protected virtual void OpenTrackSession()
        {
            var trackSessionId = DisplayOpenSessionDialog();
            if (trackSessionId.HasValue)
                LoadTrackSession(trackSessionId.Value);
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
                using (var data = new TrackSessionData())
                {
                    var model = data.GetTrackSession(trackSessionId);
                    if (null != model)
                    {
                        var runViews = model.Runs.Select(r => new TrackSessionRunView(r)).ToList();
                        AddRunsToList(runViews);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region open run
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
        protected virtual void LoadTrackSessionRun(Guid trackSessionRunId)
        {
            try
            {
                using (var data = new TrackSessionData())
                {
                    var model = data.GetTrackSessionRun(trackSessionRunId);
                    if (null != model)
                    {
                        Console.WriteLine(model.TrackSessionRunId.ToString());
                        var view = new TrackSessionRunView(model);
                        ClearRunList();
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

        #region manager events
        private void _manager_TrackSessionStarted(object sender, TrackSessionStartedArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                DisplayTrackSession(e.Session); // runs on UI thread
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
                DisplayRun(e.Run); // runs on UI thread
            });
        }

        private void _manager_EngineException(object sender, EngineExceptionArgs e)
        {
            ExceptionHandler(e.Exception);
        }
        
        private void _manager_ManagerStatusChanged(object sender, ManagerStatusChangedArgs e)
        {
            Console.WriteLine("Manager Status Changed: {0}->{1}", e.OldStatus, e.NewStatus);
            Console.WriteLine("Engine Status Changed: {0}->{1}", e.OldStatus, e.NewStatus);
            if (e.NewStatus == ManagerStatus.Idle)
                lblSession.Text = "No Active Session";
            if (e.NewStatus == ManagerStatus.Off)
                lblSession.Text = "No Active Session";
        }
        #endregion

        #region track session
        protected virtual void DisplayTrackSession(TrackSessionView session)
        {
            lblSession.Text = String.Format("{0} {1} {2}", session.SessionTypeName, session.TrackName, session.CarName);
            _currentSession = session;
        }
        #endregion

        #region tire sheet
        protected virtual void DisplayTireSheet(TireSheet tireSheet)
        {
            trackRunResultsView1.tireSheetView1.tireSheetBindingSource.DataSource = tireSheet;
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
        private void openTelemetryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new TelemetryDialog())
            {
                dialog.ShowDialog(this);
            }
        }
        #endregion
    }
}
