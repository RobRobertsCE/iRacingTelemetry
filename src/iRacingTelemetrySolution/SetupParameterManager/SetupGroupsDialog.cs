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
    public partial class SetupGroupsDialog : Form
    {
        public SetupGroup SetupGroup { get; set; }       

        public SetupGroupsDialog()
        {
            InitializeComponent();
        }

        private void SetupGroupsDialog_Load(object sender, EventArgs e)
        {
            DisplayGroups();
        }
        private IList<SetupGroup> GetGroups()
        {
            return SetupParameterHandler.GetGroups();
        }
        private void DisplayGroups()
        {
            try
            {
                cboGroups.DataSource = GetGroups().ToList();
                if (SetupGroup != null)
                {
                    cboGroups.SelectedValue = SetupGroup.SetupGroupId;
                }
                else
                {
                    cboGroups.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGroup();
        }
        void SaveGroup()
        {
            try
            {
               
                SetupGroup.Name = txtName.Text;
                SetupGroup.Key = txtKey.Text;
                SetupGroup.DisplayIndex = (int)numDisplayIndex.Value;
                SetupGroup = SetupParameterHandler.SaveGroup(SetupGroup);
                DisplayGroups();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnSubGroups_Click(object sender, EventArgs e)
        {
            var dialog = new SetupSubGroupsDialog() { SetupGroup = this.SetupGroup };
            dialog.ShowDialog(this);
        }

        private void cboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == cboGroups.SelectedItem)
            {
                ClearDisplay();
                return;
            }
            SetupGroup = (SetupGroup)cboGroups.SelectedItem;
            DisplaySelectedGroup(SetupGroup);
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
        void DisplaySelectedGroup(SetupGroup group)
        {
            if (null == group)
            {
                ClearDisplay();
            }
            else
            {
                txtName.Text = group.Name;
                txtKey.Text = group.Key;
                numDisplayIndex.Value = group.DisplayIndex;
                txtName.Enabled = true;
                txtKey.Enabled = true;
                numDisplayIndex.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetupGroup = new SetupGroup();
            SetupGroup.Name ="<New Group>";
            SetupGroup.Key = "<New Group>";
            SetupGroup.DisplayIndex = cboGroups.Items.Count; 
            DisplaySelectedGroup(SetupGroup);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (null == cboGroups.SelectedItem) return;

            try
            {
                var result = MessageBox.Show(this, "Delete Group?", "Delete Group Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var group = (SetupGroup)cboGroups.SelectedItem;
                    SetupParameterHandler.DeleteGroup(group.SetupGroupId);
                    DisplayGroups();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
