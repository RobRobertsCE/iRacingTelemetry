using ibtAnalysis.Laps;
using iRacing.SetupLibrary.Parsers;
using iRacing.SetupLibrary.Tires;
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
using TestSessionLibrary;
using TestSessionLibrary.Data.Models;
using TestSessionLibrary.Views;
using TestSessionTestApp.Controls;

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
            _manager.EngineException += _manager_EngineException;
            _manager.SessionRunComplete += _manager_SessionRunComplete;
            _manager.NewTireSheet += _manager_NewTireSheet;
        }

        private void _manager_NewTireSheet(object sender, NewTireSheetArgs e)
        {           
            this.Invoke((MethodInvoker)delegate {
                DisplayTireSheet(e.TireSheet); // runs on UI thread
            });
        }

        private void _manager_SessionRunComplete(object sender, TrackSessionRunCompleteArgs e)
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
              
        private void ShowMessage(string message)
        {
            msg.Text += DateTime.Now.ToString() + ": " +  message + "\r\n";
        }
        
        private void DisplayRun(TrackSessionRunView run)
        {
            var newTab = new TabPage();
            newTab.Text = "Run " + tabRuns.TabPages.Count + 1;
            var newView = new TrackRunResultsView();
            newTab.Controls.Add(newView);
            newView.Dock = DockStyle.Fill;
            tabRuns.TabPages.Add(newTab);
            tabRuns.SelectedTab = newTab;

            var telemetryParser = new ibtParserLibrary.ParserEngine();
            //var session = telemetryParser.ParseTelemetryBytes(run.Telemetry.BinaryData);
            //var lapAnalysis = new LapTimeAnalysis(session.Laps);

            //newView.lapsView1.LapTimes = lapAnalysis.CoreLapTimes;
        }

        private void DisplayTireSheet(TireSheet tireSheet)
        {
            var selectedTab = tabRuns.SelectedTab;
            var view = (TrackRunResultsView)selectedTab.Controls[0];
            view.tireSheetView1.tireSheetBindingSource.DataSource = tireSheet;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                HtmlExportParser htmlParser = new HtmlExportParser();
                var htmlExport = File.ReadAllText(@"C:\Users\rroberts\Source\Repos\iRacingTelemetry\src\iRacingTelemetrySolution\Samples\SetupExports\cupat5flags.htm");
                var tireSheet = htmlParser.GetTireSheet(htmlExport);
                tireSheetView1.tireSheetBindingSource.DataSource = tireSheet;
                Console.WriteLine(tireSheet.ToJson());

                Random rnd = new Random(DateTime.Now.Millisecond);
                var lapTimes = new List<Single>();
                for (int i = 0; i < 30; i++)
                {
                    lapTimes.Add((Single)rnd.Next(15, 18) + (Single)rnd.NextDouble());
                }
                this.lapsView1.LapTimes = lapTimes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
