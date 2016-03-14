using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSessionTestApp
{
    public partial class SetupViewer : Form
    {
        public SetupViewer()
        {
            InitializeComponent();
        }

        private void SetupViewer_Load(object sender, EventArgs e)
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
                lapsView1.LapTimes = laps;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
