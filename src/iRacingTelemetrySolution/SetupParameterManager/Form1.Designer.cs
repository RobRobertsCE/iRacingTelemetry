namespace SetupParameterManager
{
    partial class Form1
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
            this.cboGroups = new System.Windows.Forms.ComboBox();
            this.cboSubGroups = new System.Windows.Forms.ComboBox();
            this.cboParameters = new System.Windows.Forms.ComboBox();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.grpGroups = new System.Windows.Forms.GroupBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDisplayIndex = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.btnCancelClose = new System.Windows.Forms.Button();
            this.btnAddSubGroup = new System.Windows.Forms.Button();
            this.btnAddParam = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpGroups.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboGroups
            // 
            this.cboGroups.FormattingEnabled = true;
            this.cboGroups.Location = new System.Drawing.Point(3, 34);
            this.cboGroups.Name = "cboGroups";
            this.cboGroups.Size = new System.Drawing.Size(163, 21);
            this.cboGroups.TabIndex = 0;
            this.cboGroups.SelectedIndexChanged += new System.EventHandler(this.cboGroups_SelectedIndexChanged);
            // 
            // cboSubGroups
            // 
            this.cboSubGroups.FormattingEnabled = true;
            this.cboSubGroups.Location = new System.Drawing.Point(172, 34);
            this.cboSubGroups.Name = "cboSubGroups";
            this.cboSubGroups.Size = new System.Drawing.Size(163, 21);
            this.cboSubGroups.TabIndex = 1;
            this.cboSubGroups.SelectedIndexChanged += new System.EventHandler(this.cboSubGroups_SelectedIndexChanged);
            // 
            // cboParameters
            // 
            this.cboParameters.FormattingEnabled = true;
            this.cboParameters.Location = new System.Drawing.Point(341, 34);
            this.cboParameters.Name = "cboParameters";
            this.cboParameters.Size = new System.Drawing.Size(163, 21);
            this.cboParameters.TabIndex = 2;
            this.cboParameters.SelectedIndexChanged += new System.EventHandler(this.cboParameters_SelectedIndexChanged);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(166, 19);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(86, 31);
            this.btnAddGroup.TabIndex = 3;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // grpGroups
            // 
            this.grpGroups.BackColor = System.Drawing.Color.Silver;
            this.grpGroups.Controls.Add(this.label3);
            this.grpGroups.Controls.Add(this.label2);
            this.grpGroups.Controls.Add(this.label1);
            this.grpGroups.Controls.Add(this.txtDisplayIndex);
            this.grpGroups.Controls.Add(this.txtKey);
            this.grpGroups.Controls.Add(this.txtName);
            this.grpGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGroups.Location = new System.Drawing.Point(0, 72);
            this.grpGroups.Name = "grpGroups";
            this.grpGroups.Size = new System.Drawing.Size(799, 81);
            this.grpGroups.TabIndex = 4;
            this.grpGroups.TabStop = false;
            this.grpGroups.Text = "Group";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(166, 40);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(151, 20);
            this.txtKey.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(9, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtDisplayIndex
            // 
            this.txtDisplayIndex.Location = new System.Drawing.Point(323, 40);
            this.txtDisplayIndex.Name = "txtDisplayIndex";
            this.txtDisplayIndex.Size = new System.Drawing.Size(151, 20);
            this.txtDisplayIndex.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddParam);
            this.panel1.Controls.Add(this.btnAddSubGroup);
            this.panel1.Controls.Add(this.btnCancelClose);
            this.panel1.Controls.Add(this.btnEditSave);
            this.panel1.Controls.Add(this.btnAddGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 478);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 64);
            this.panel1.TabIndex = 5;
            // 
            // btnEditSave
            // 
            this.btnEditSave.Location = new System.Drawing.Point(12, 19);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(86, 31);
            this.btnEditSave.TabIndex = 0;
            this.btnEditSave.Text = "Edit";
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // btnCancelClose
            // 
            this.btnCancelClose.Location = new System.Drawing.Point(701, 19);
            this.btnCancelClose.Name = "btnCancelClose";
            this.btnCancelClose.Size = new System.Drawing.Size(86, 31);
            this.btnCancelClose.TabIndex = 1;
            this.btnCancelClose.Text = "Close";
            this.btnCancelClose.UseVisualStyleBackColor = true;
            this.btnCancelClose.Click += new System.EventHandler(this.btnCancelClose_Click);
            // 
            // btnAddSubGroup
            // 
            this.btnAddSubGroup.Location = new System.Drawing.Point(258, 19);
            this.btnAddSubGroup.Name = "btnAddSubGroup";
            this.btnAddSubGroup.Size = new System.Drawing.Size(86, 31);
            this.btnAddSubGroup.TabIndex = 4;
            this.btnAddSubGroup.Text = "Add SubGroup";
            this.btnAddSubGroup.UseVisualStyleBackColor = true;
            this.btnAddSubGroup.Click += new System.EventHandler(this.btnAddSubGroup_Click);
            // 
            // btnAddParam
            // 
            this.btnAddParam.Location = new System.Drawing.Point(350, 19);
            this.btnAddParam.Name = "btnAddParam";
            this.btnAddParam.Size = new System.Drawing.Size(86, 31);
            this.btnAddParam.TabIndex = 5;
            this.btnAddParam.Text = "Add Param";
            this.btnAddParam.UseVisualStyleBackColor = true;
            this.btnAddParam.Click += new System.EventHandler(this.btnAddParam_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboGroups);
            this.panel2.Controls.Add(this.cboSubGroups);
            this.panel2.Controls.Add(this.cboParameters);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 72);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Display Index";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Parameter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "SubGroup";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Group";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 542);
            this.Controls.Add(this.grpGroups);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpGroups.ResumeLayout(false);
            this.grpGroups.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGroups;
        private System.Windows.Forms.ComboBox cboSubGroups;
        private System.Windows.Forms.ComboBox cboParameters;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.GroupBox grpGroups;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDisplayIndex;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelClose;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.Button btnAddParam;
        private System.Windows.Forms.Button btnAddSubGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

