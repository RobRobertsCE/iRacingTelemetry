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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var laps = new List<Single>();
                var r = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < 20; i++)
                {
                    var lap = (Single)(r.Next(20, 22) + r.NextDouble());
                    laps.Add(lap);
                }

                // raw laps
                Console.WriteLine();
                Console.WriteLine("Laps");
                foreach (var lap in laps.OrderBy(l => l))
                {
                    Console.WriteLine(lap.ToString());
                }

                // core laps
                var core = laps.CoreLaps();
                Console.WriteLine();
                Console.WriteLine("CoreLaps");
                foreach (var lap in core)
                {
                    Console.WriteLine(lap.ToString());
                }

                // stats
                Console.WriteLine("Core Laps Average: {0}",core.Average());
                Console.WriteLine("Core Laps Median: {0}", core.Median());
                Console.WriteLine("Core Laps StdDev: {0}", core.StdDev());
                Console.WriteLine("Core Laps Range: {0}", core.Range());

                Console.WriteLine("Core Laps Frequency Distribution:");
                var fd = core.FrequencyDistribution();
                foreach (var item in fd.OrderBy(v=> v.Key))
                {
                    Console.WriteLine("{0,-6}: {1} {2}%", item.Key, item.Value, (((Single)item.Value / fd.Count) * 100));
                }

                Console.WriteLine("Core Laps Dropoff:");
                var drop = core.Dropoff();
                foreach (var item in drop)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
