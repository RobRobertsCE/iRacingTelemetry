namespace TrackSession.Dialogs
{
    partial class TrackSessionSettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkAutoSaveSetup = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.txtAutoSaveSetupDirectory = new System.Windows.Forms.TextBox();
            this.lblAutoSaveDirectory = new System.Windows.Forms.Label();
            this.btnAutoSaveSetupDirectorySearch = new System.Windows.Forms.Button();
            this.lblCarPathTokenHint = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoSaveSetup
            // 
            this.chkAutoSaveSetup.AutoSize = true;
            this.chkAutoSaveSetup.Location = new System.Drawing.Point(16, 50);
            this.chkAutoSaveSetup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAutoSaveSetup.Name = "chkAutoSaveSetup";
            this.chkAutoSaveSetup.Size = new System.Drawing.Size(128, 20);
            this.chkAutoSaveSetup.TabIndex = 0;
            this.chkAutoSaveSetup.Text = "Auto-Save Setup";
            this.chkAutoSaveSetup.UseVisualStyleBackColor = true;
            this.chkAutoSaveSetup.CheckedChanged += new System.EventHandler(this.chkAutoSaveSetup_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 190);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 47);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(393, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 47);
            this.panel2.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(112, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(16, 22);
            this.chkAutoStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(132, 20);
            this.chkAutoStart.TabIndex = 2;
            this.chkAutoStart.Text = "Auto-Start Monitor";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // txtAutoSaveSetupDirectory
            // 
            this.txtAutoSaveSetupDirectory.Enabled = false;
            this.txtAutoSaveSetupDirectory.Location = new System.Drawing.Point(36, 96);
            this.txtAutoSaveSetupDirectory.Name = "txtAutoSaveSetupDirectory";
            this.txtAutoSaveSetupDirectory.Size = new System.Drawing.Size(514, 22);
            this.txtAutoSaveSetupDirectory.TabIndex = 3;
            // 
            // lblAutoSaveDirectory
            // 
            this.lblAutoSaveDirectory.AutoSize = true;
            this.lblAutoSaveDirectory.Enabled = false;
            this.lblAutoSaveDirectory.Location = new System.Drawing.Point(33, 77);
            this.lblAutoSaveDirectory.Name = "lblAutoSaveDirectory";
            this.lblAutoSaveDirectory.Size = new System.Drawing.Size(166, 16);
            this.lblAutoSaveDirectory.TabIndex = 4;
            this.lblAutoSaveDirectory.Text = "Auto-Save Setup Directory";
            // 
            // btnAutoSaveSetupDirectorySearch
            // 
            this.btnAutoSaveSetupDirectorySearch.Enabled = false;
            this.btnAutoSaveSetupDirectorySearch.Location = new System.Drawing.Point(557, 95);
            this.btnAutoSaveSetupDirectorySearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutoSaveSetupDirectorySearch.Name = "btnAutoSaveSetupDirectorySearch";
            this.btnAutoSaveSetupDirectorySearch.Size = new System.Drawing.Size(42, 25);
            this.btnAutoSaveSetupDirectorySearch.TabIndex = 5;
            this.btnAutoSaveSetupDirectorySearch.Text = "...";
            this.btnAutoSaveSetupDirectorySearch.UseVisualStyleBackColor = true;
            this.btnAutoSaveSetupDirectorySearch.Click += new System.EventHandler(this.btnAutoSaveSetupDirectorySearch_Click);
            // 
            // lblCarPathTokenHint
            // 
            this.lblCarPathTokenHint.AutoSize = true;
            this.lblCarPathTokenHint.Location = new System.Drawing.Point(38, 126);
            this.lblCarPathTokenHint.Name = "lblCarPathTokenHint";
            this.lblCarPathTokenHint.Size = new System.Drawing.Size(330, 16);
            this.lblCarPathTokenHint.TabIndex = 6;
            this.lblCarPathTokenHint.Text = "Insert \'{CarPath}\' token to add a subfolder for each car.";
            this.lblCarPathTokenHint.Visible = false;
            // 
            // TrackSessionSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 237);
            this.Controls.Add(this.lblCarPathTokenHint);
            this.Controls.Add(this.btnAutoSaveSetupDirectorySearch);
            this.Controls.Add(this.lblAutoSaveDirectory);
            this.Controls.Add(this.txtAutoSaveSetupDirectory);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkAutoSaveSetup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TrackSessionSettingsDialog";
            this.Text = "TrackSession Settings";
            this.Load += new System.EventHandler(this.TrackSessionSettingsDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoSaveSetup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.TextBox txtAutoSaveSetupDirectory;
        private System.Windows.Forms.Label lblAutoSaveDirectory;
        private System.Windows.Forms.Button btnAutoSaveSetupDirectorySearch;
        private System.Windows.Forms.Label lblCarPathTokenHint;
    }
}