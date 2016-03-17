using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TestSessionLibrary.Data;

namespace TrackSession.Dialogs
{
    public partial class OpenTrackSessionRun : Form
    {
        #region fields
        private iRacingDbContext _context;
        #endregion

        #region properties
        public int CarId { get; set; }
        public int TrackId { get; set; }
        public Guid? TrackSessionRunId { get; set; }
        #endregion

        #region ctor / load
        public OpenTrackSessionRun(int carId, int trackId) : this()
        {
            this.CarId = carId;
            this.TrackId = trackId;
        }
        public OpenTrackSessionRun()
        {
            InitializeComponent();
        }
        private void OpenTrackSession_Load(object sender, EventArgs e)
        {
            try
            {
                _context = new iRacingDbContext();
                LoadVehicles(_context, CarId);
                LoadTracks(_context, TrackId);
                LoadSessionRunList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region private 
        private void LoadVehicles(iRacingDbContext context, int selectedValue)
        {
            var vehicles = context.Vehicles.Select(v => new { v.VehicleNumber, v.DisplayName }).ToList();
            vehicles.Insert(0, new { VehicleNumber = 0, DisplayName = "All" });
            cboVehicles.DisplayMember = "DisplayName";
            cboVehicles.ValueMember = "VehicleNumber";
            cboVehicles.DataSource = vehicles;
            cboVehicles.SelectedValue = selectedValue;
            cboVehicles.SelectedValueChanged += cboVehicles_SelectedValueChanged;
        }
        private void cboVehicles_SelectedValueChanged(object sender, EventArgs e)
        {
            CarId = (int)cboVehicles.SelectedValue;
            LoadSessionRunList();
        }

        private void LoadTracks(iRacingDbContext context, int selectedValue)
        {
            var tracks = context.Tracks.Select(v => new { v.TrackNumber, v.Name }).ToList();
            tracks.Insert(0, new { TrackNumber = 0, Name = "All" });
            cboTracks.DisplayMember = "Name";
            cboTracks.ValueMember = "TrackNumber";
            cboTracks.DataSource = tracks;
            cboTracks.SelectedValue = selectedValue;
            cboTracks.SelectedValueChanged += cboTracks_SelectedValueChanged;
        }
        private void cboTracks_SelectedValueChanged(object sender, EventArgs e)
        {
            TrackId = (int)cboTracks.SelectedValue;
            LoadSessionRunList();
        }

        private void LoadSessionRunList()
        {
            try
            {
                lvSessions.Items.Clear();
                var sessions = _context.Sessions.Include("Vehicle").Include("Track").Include("Runs").Where(s => (CarId == 0 || CarId == s.VehicleNumber) && (TrackId == 0 || TrackId == s.TrackNumber)).ToList();

                foreach (var session in sessions)
                {
                    foreach (var run in session.Runs)
                    {
                        //if (run.LapCount > 0)
                        //{
                            var lvi = new ListViewItem(session.Timestamp.ToString("f"));
                            lvi.SubItems.Add(run.LapCount.ToString());
                            lvi.SubItems.Add(session.Vehicle.DisplayName);
                            lvi.SubItems.Add(session.Track.Name);
                            lvi.SubItems.Add(session.TrackTemp);
                            lvi.SubItems.Add(session.AirTemp);
                            lvi.SubItems.Add(session.Skies);
                            lvi.SubItems.Add(run.TrackSessionRunId.ToString());
                            lvSessions.Items.Add(lvi);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void lvSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSessions.SelectedItems.Count > 0)
            {
                TrackSessionRunId = Guid.Parse(lvSessions.SelectedItems[0].SubItems[7].Text);
                btnOK.Enabled = true;
            }
            else
            {
                TrackSessionRunId = null;
                btnOK.Enabled = false;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSessionRunList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
