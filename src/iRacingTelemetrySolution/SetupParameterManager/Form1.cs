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
    public partial class Form1 : Form
    {
        private bool _isEditMode = false;

        public Form1()
        {
            InitializeComponent();
        }

        private IList<SetupGroup> GetGroups()
        {
            return SetupParameterHandler.GetGroups();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cboGroups.DisplayMember = "Name";
                cboSubGroups.DisplayMember = "Name";
                cboParameters.DisplayMember = "Name";
                cboGroups.DataSource = GetGroups();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void cboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == cboGroups.SelectedItem) return;

            var dataitem = (SetupGroup)cboGroups.SelectedItem;
            cboSubGroups.DataSource = null;
            cboParameters.DataSource = null;
            cboSubGroups.DisplayMember = "Name";
            cboSubGroups.DataSource = dataitem.SetupSubGroups;

            DisplayGroup(dataitem);
        }

        private void cboSubGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == cboSubGroups.SelectedItem) return;

            var dataitem = (SetupSubGroup)cboSubGroups.SelectedItem;
            cboParameters.DataSource = null;
            cboParameters.DisplayMember = "Name";
            cboParameters.DataSource = dataitem.SetupParameters;
        }

        private void cboParameters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //var newGroup = new SetupGroup();
                //newGroup.Name = txtName.Text;
                //newGroup.Key = txtKey.Text;
                //newGroup.DisplayIndex = Convert.ToInt32(txtDisplayIndex.Text);
                //SetupParameterHandler.SaveGroup(newGroup);
                //cboGroups.DataSource = GetGroups();
                using (var dialog = new SetupGroupsDialog())
                {
                    dialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void DisplayGroup(SetupGroup group)
        {
            if (null == group)
            {
                txtName.Clear();
                txtKey.Clear();
                txtDisplayIndex.Clear();
            }
            else
            {
                txtName.Text = group.Name;
                txtKey.Text = group.Key;
                txtDisplayIndex.Text = group.DisplayIndex.ToString();
            }
        }
        void SetEditMode(bool EditModeOn)
        {
            _isEditMode = EditModeOn;

            if (_isEditMode)
            {
                grpGroups.Enabled = true;
                btnEditSave.Text = "Save";
                btnCancelClose.Text = "Cancel";
            }
            else
            {
                grpGroups.Enabled = false;
                btnEditSave.Text = "Edit";
                btnCancelClose.Text = "Close";
            }            
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            SetEditMode(!_isEditMode);
        }

        private void btnCancelClose_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                // cancel
                SetEditMode(!_isEditMode);
            }
            else
            {
                // close
                this.Close();
            }
        }

        private void btnAddSubGroup_Click(object sender, EventArgs e)
        {

        }

        private void btnAddParam_Click(object sender, EventArgs e)
        {

        }
    }
}
