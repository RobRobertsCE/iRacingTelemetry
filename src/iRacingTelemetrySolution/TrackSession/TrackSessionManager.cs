using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackSession
{
    public partial class TrackSessionManager : Form
    {
        #region constants 
        private const string MessageLogFile = @"Messages.txt";
        #endregion

        #region fields 
        private Size _messageDisplaySize;
        #endregion

        #region properties 
        
        #endregion

        #region ctor / init / load
        public TrackSessionManager()
        {
            InitializeComponent();

            InitializeTrackSessionManager();
        }
        protected virtual void InitializeTrackSessionManager()
        {
            try
            {
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
                AddTestData();
                PrintMessage("Loaded");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        protected virtual void AddTestData()
        {
            lstRuns.Items.Clear();
            var r1 = new TrackSessionRun();
            r1.RunNumber = 1;
            r1.LapCount = 12;
            r1.Bestlap = 15.345F;
            r1.AverageLap = 16.556F;
            AddRunToList(r1);

            var r2 = new TrackSessionRun();
            r2.RunNumber = 2;
            r2.LapCount = 12;
            r2.Bestlap = 16.221F;
            r2.AverageLap = 17.192F;
            AddRunToList(r2);

            var r3 = new TrackSessionRun()
            {
                RunNumber = 3,
                LapCount = 7,
                Bestlap = 15.399F,
                AverageLap = 16.935F
            };
            AddRunToList(r3);

            AddRunToList(new TrackSessionRun()
            {
                RunNumber = 4,
                LapCount = 23,
                Bestlap = 18.848F,
                AverageLap = 19.125F
            });

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
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(message);
            });
            PrintMessage(message);
        }
        protected virtual void PrintMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate {
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

        private void lstRuns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRuns.SelectedItems.Count < 1)
                return;

            var lastRun = (TrackSessionRun)lstRuns.SelectedItems[lstRuns.SelectedItems.Count - 1];
            DisplayRun(lastRun);
        }

        protected virtual void AddRunToList(TrackSessionRun run)
        {
            lstRuns.Items.Add(run);
            lstRuns.SelectedItems.Add(run);
        }

        protected virtual void DisplayRun(TrackSessionRun run)
        {
            DisplayRunDetails(run);
            foreach (var display in Displays)
            {
                if (display.IsActive)
                    display.DisplayRun(run);
            }
        }

        protected virtual void DisplayRunDetails(TrackSessionRun run)
        {
            this.lblRunNumber.Text = String.Format("Run {0}", run.RunNumber);
            this.lblRunLapCount.Text = String.Format("{0} Laps", run.LapCount);
            this.lblBestLap.Text = run.Bestlap.ToString();
            this.lblAverageLap.Text = run.AverageLap.ToString();
        }
        
        protected IList<ITrackSessionRunDisplay> Displays { get; set; }
    }

    public class TrackSessionRun
    {
        public int RunNumber { get; set; }
        public int LapCount { get; set; }
        public float Bestlap { get; set; }
        public float AverageLap { get; set; }

        public string Caption
        {
            get
            {
                return String.Format("{0} {1} Laps", RunNumber, LapCount);
            }
        }

    }

    public interface ITrackSessionRunDisplay
    {
        bool IsActive { get; set; }
        void DisplayRun(TrackSessionRun run);
    }
}
