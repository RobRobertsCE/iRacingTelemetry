using iRacing.TrackSession.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TrackSession.Dialogs
{
    public partial class OpenTrackSession : Form
    {
        #region fields
        private TrackSessionData _data;
        #endregion

        #region properties
        public int CarId { get; set; }
        public int TrackId { get; set; }
        public Guid? TrackSessionId { get; set; }
        #endregion

        #region ctor / load
        public OpenTrackSession(int carId, int trackId) : this()
        {
            this.CarId = carId;
            this.TrackId = trackId;
        }
        public OpenTrackSession()
        {
            InitializeComponent();
        }
        private void OpenTrackSession_Load(object sender, EventArgs e)
        {
            try
            {
                _data = new TrackSessionData();
                LoadVehicles(_data, CarId);
                LoadTracks(_data, TrackId);
                LoadSessionList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region private 
        private void LoadVehicles(TrackSessionData data, int selectedValue)
        {
            var vehicles = data.GetVehicles().Select(v => new { v.VehicleNumber, v.DisplayName }).ToList();
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
            LoadSessionList();
        }

        private void LoadTracks(TrackSessionData data, int selectedValue)
        {
            var tracks = data.GetTracks().Select(v => new { v.TrackNumber, v.Name }).ToList();
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
            LoadSessionList();
        }

        private void LoadSessionList()
        {
            try
            {
                lvSessions.Items.Clear();
                var sessions = _data.GetTrackSessions(CarId, TrackId);
                foreach (var session in sessions)
                {
                    var lvi = new ListViewItem(session.Timestamp.ToString("f"));
                    lvi.SubItems.Add(session.Runs.Count.ToString());
                    lvi.SubItems.Add(session.Vehicle.DisplayName);
                    lvi.SubItems.Add(session.Track.Name);
                    lvi.SubItems.Add(session.TrackTemp);
                    lvi.SubItems.Add(session.AirTemp);
                    lvi.SubItems.Add(session.Skies);
                    lvi.SubItems.Add(session.TrackSessionId.ToString());
                    lvSessions.Items.Add(lvi);
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
                TrackSessionId = Guid.Parse(lvSessions.SelectedItems[0].SubItems[7].Text);
                btnOK.Enabled = true;
            }
            else
            {
                TrackSessionId = null;
                btnOK.Enabled = false;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSessionList();
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
