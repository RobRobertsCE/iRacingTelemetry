using SetupParameterLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetupParameterManager
{
    public partial class SetupSubGroupsDialog : Form
    {
        public SetupGroup SetupGroup { get; set; }
        public SetupSubGroup SetupSubGroup;

        public SetupSubGroupsDialog()
        {
            InitializeComponent();
        }

        private void SetupSubGroupsDialog_Load(object sender, EventArgs e)
        {
            lblGroup.Text = SetupGroup.Name;
            cboSubGroups.DataSource = SetupGroup.SetupSubGroups;
        }
        void DisplaySubGroups()
        {
            lblGroup.Text = SetupGroup.Name;
            cboSubGroups.DataSource = SetupGroup.SetupSubGroups;
        }

        private IList<SetupSubGroup> GetSubGroups()
        {
            return SetupGroup.SetupSubGroups;
        }

        private void cboSubGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedSubGroup((SetupSubGroup)cboSubGroups.SelectedItem);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetupSubGroup.Name = txtName.Text;
                SetupSubGroup.Key = txtKey.Text;
                SetupSubGroup.DisplayIndex = (int)numDisplayIndex.Value;
                SetupSubGroup = SetupParameterHandler.SaveSubGroup(SetupSubGroup);
                DisplaySubGroups();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        void ClearDisplay()
        {
            txtName.Clear();
            txtKey.Clear();
            numDisplayIndex.Value = -1;
            txtName.Enabled = false;
            txtKey.Enabled = false;
            numDisplayIndex.Enabled = false;
        }
        void DisplaySelectedSubGroup(SetupSubGroup subGroup)
        {
            if (null == subGroup)
            {
                ClearDisplay();
            }
            else
            {
                txtName.Text = subGroup.Name;
                txtKey.Text = subGroup.Key;
                numDisplayIndex.Value = subGroup.DisplayIndex;
                txtName.Enabled = true;
                txtKey.Enabled = true;
                numDisplayIndex.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetupSubGroup = new SetupSubGroup();
            SetupSubGroup.Name = "<New SubGroup>";
            SetupSubGroup.Key = "<New SubGroup>";
            SetupSubGroup.DisplayIndex = cboSubGroups.Items.Count;
            SetupSubGroup.SetupGroupId = SetupGroup.SetupGroupId;
            DisplaySelectedSubGroup(SetupSubGroup);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (null == cboSubGroups.SelectedItem) return;

            try
            {
                var result = MessageBox.Show(this, "Delete SubGroup?", "Delete SubGroup Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var subGroup = (SetupSubGroup)cboSubGroups.SelectedItem;
                    SetupParameterHandler.DeleteSubGroup(subGroup.SetupSubGroupId);
                    DisplaySubGroups();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
