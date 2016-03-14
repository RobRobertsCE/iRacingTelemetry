using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSessionTestApp.Controls
{
    public partial class LapsView : UserControl
    {
        private IList<Single> _lapTimes = new List<Single>();
        public IList<Single> LapTimes
        {
            get
            {
                return _lapTimes;
            }
            set
            {
                _lapTimes = value;
                UpdateDisplay(_lapTimes);
            }
        }

        public LapsView()
        {
            InitializeComponent();
        }

        protected virtual void UpdateDisplay(IList<Single> laps)
        {
            txtBestLapAll.Clear();
            txtBestLapAll.Clear();

            lvLaps.Items.Clear();

            int lapNumber = 0;
            Single bestLap = 9999;
            int bestLapIdx = -1;
            foreach (var lap in laps)
            {
                lvLaps.Items.Add(new ListViewItem(new string[] { lapNumber.ToString(), lap.ToString() }));
                if (lap < bestLap)
                {
                    bestLapIdx = lapNumber;
                    bestLap = lap;
                }
                lapNumber++;
            }
            if (bestLapIdx>-1)
            {
                var bestLapItem = lvLaps.Items[bestLapIdx];
                bestLapItem.BackColor = Color.LimeGreen;
                txtBestLapAll.Text = String.Format("{0}: {1}", bestLapIdx+1, bestLap);
                txtAverageLapAll.Text = laps.Average().ToString();
                txtBestLapClean.Text = "";
                txtAverageLapClean.Text = "";
            }
        }
    }
}
