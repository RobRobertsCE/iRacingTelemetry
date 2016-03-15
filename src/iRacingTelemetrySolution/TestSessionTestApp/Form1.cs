using ibtAnalysis.Laps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestSessionLibrary;
using TestSessionLibrary.Data.Models;
using TestSessionLibrary.Views;

namespace TestSessionTestApp
{
    public partial class Form1 : Form
    {
        TrackSessionManager _manager;

        public Form1()
        {
            InitializeComponent();
            _manager = new TrackSessionManager();
            _manager.ManagerStatusChanged += _manager_ManagerStatusChanged;
            _manager.EngineStatusChanged += _manager_EngineStatusChanged;
            _manager.EngineException += _manager_EngineException;
            _manager.SessionRunComplete += _manager_SessionRunComplete;
        }

        private void _manager_SessionRunComplete(object sender, SessionRunCompleteArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                DisplayRun(e.Run); // runs on UI thread
            });
        }

        private void _manager_EngineException(object sender, EngineExceptionArgs e)
        {
            Console.WriteLine(e.Exception.ToString());
        }

        private void _manager_EngineStatusChanged(object sender, EngineStatusChangedArgs e)
        {
            Console.WriteLine("Engine Status Changed: {0}->{1}", e.OldStatus, e.NewStatus);
        }

        private void _manager_ManagerStatusChanged(object sender, ManagerStatusChangedArgs e)
        {
            Console.WriteLine("Manager Status Changed: {0}->{1}", e.OldStatus, e.NewStatus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.EnableLogging = true;
                _manager.StartManager();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.StopManager();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ShowMessage(string message)
        {
            msg.Text += DateTime.Now.ToString() + ": " +  message + "\r\n";
        }

        private void btnViewer_Click(object sender, EventArgs e)
        {
            var v = new SetupViewer();
            v.ShowDialog();
        }
        
        private void DisplayRun(TrackSessionRunView run)
        {
            var telemetryParser = new ibtParserLibrary.ParserEngine();
            var session = telemetryParser.ParseTelemetryBytes(run.Telemetry.BinaryData);
            var lapAnalysis = new LapTimeAnalysis(session.Laps);
            lapsView1.LapTimes = lapAnalysis.CoreLapTimes;
        }        
    }
}
