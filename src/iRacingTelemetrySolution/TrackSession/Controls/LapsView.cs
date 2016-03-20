using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrackSession.Views
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
            txtAverageLapAll.Clear();

            lvLaps.Items.Clear();

            int lapNumber = 0;
            Single bestLap = 9999;
            int bestLapIdx = -1;
            foreach (var lap in laps)
            {
                lvLaps.Items.Add(new ListViewItem(new string[] { lapNumber.ToString(), lap.ToString("0.###") }));
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
                txtBestLapAll.Text = String.Format("[{0}] {1:0.###}", bestLapIdx+1, bestLap);
                txtAverageLapAll.Text = laps.Average().ToString("0.###");       
            }
        }
    }
}
