using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackSession.Dialogs
{
    public partial class TrackSessionSettingsDialog : Form
    {
        public TrackSessionSettingsDialog()
        {
            InitializeComponent();
        }

        private void TrackSessionSettingsDialog_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadSettings()
        {
            this.chkAutoSaveSetup.Checked = TrackSessionSettings.AutoSaveSetup;
            this.chkAutoStart.Checked = TrackSessionSettings.AutoStartMonitor;
            this.txtAutoSaveSetupDirectory.Text = TrackSessionSettings.AutoSaveSetupDirectory;
            // iRacingCarPathToken
            this.lblCarPathTokenHint.Text = String.Format("Insert '{0}' token to add a subfolder for each car.", iRacing.Constants.iRacingCarPathToken);
        }

        private void SaveSettings()
        {
            TrackSessionSettings.AutoSaveSetup = this.chkAutoSaveSetup.Checked;
            TrackSessionSettings.AutoStartMonitor = this.chkAutoStart.Checked;
            TrackSessionSettings.AutoSaveSetupDirectory = this.txtAutoSaveSetupDirectory.Text;
        }

        private void chkAutoSaveSetup_CheckedChanged(object sender, EventArgs e)
        {
            txtAutoSaveSetupDirectory.Enabled = chkAutoSaveSetup.Checked;
            lblAutoSaveDirectory.Enabled = chkAutoSaveSetup.Checked;
            btnAutoSaveSetupDirectorySearch.Enabled = chkAutoSaveSetup.Checked;
            lblCarPathTokenHint.Visible = chkAutoSaveSetup.Checked;
        }

        private void btnAutoSaveSetupDirectorySearch_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (String.IsNullOrEmpty(this.txtAutoSaveSetupDirectory.Text))
                {
                    dialog.SelectedPath = iRacing.Constants.iRacingSetupDirectory;
                }
                else if (this.txtAutoSaveSetupDirectory.Text.Contains(""))
                {
                    dialog.SelectedPath = this.txtAutoSaveSetupDirectory.Text.Replace(iRacing.Constants.iRacingCarPathToken , "").TrimEnd('\\');
                }
                else
                {
                    dialog.SelectedPath = this.txtAutoSaveSetupDirectory.Text;
                }                
                if (dialog.ShowDialog(this)== DialogResult.OK)
                {
                    txtAutoSaveSetupDirectory.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
