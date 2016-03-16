﻿namespace TrackSession
{
    partial class TrackSessionManager
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.splMessages = new System.Windows.Forms.Splitter();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMessages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.splContMain = new System.Windows.Forms.SplitContainer();
            this.pnlRunMenu = new System.Windows.Forms.Panel();
            this.lblRuns = new System.Windows.Forms.Label();
            this.pnlRunDetails = new System.Windows.Forms.Panel();
            this.lblRunDetails = new System.Windows.Forms.Label();
            this.pnlRunPanelSpacer = new System.Windows.Forms.Panel();
            this.lblRunNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBestLap = new System.Windows.Forms.Label();
            this.lblAverageLap = new System.Windows.Forms.Label();
            this.lblRunLapCount = new System.Windows.Forms.Label();
            this.lstRuns = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.ctxMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContMain)).BeginInit();
            this.splContMain.Panel1.SuspendLayout();
            this.splContMain.SuspendLayout();
            this.pnlRunMenu.SuspendLayout();
            this.pnlRunDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1006, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1006, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pnlMessages
            // 
            this.pnlMessages.BackColor = System.Drawing.Color.Black;
            this.pnlMessages.Controls.Add(this.txtMessages);
            this.pnlMessages.Controls.Add(this.label1);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessages.Location = new System.Drawing.Point(0, 440);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Padding = new System.Windows.Forms.Padding(2);
            this.pnlMessages.Size = new System.Drawing.Size(1006, 97);
            this.pnlMessages.TabIndex = 3;
            // 
            // splMessages
            // 
            this.splMessages.BackColor = System.Drawing.Color.Silver;
            this.splMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splMessages.Location = new System.Drawing.Point(0, 437);
            this.splMessages.Name = "splMessages";
            this.splMessages.Size = new System.Drawing.Size(1006, 3);
            this.splMessages.TabIndex = 0;
            this.splMessages.TabStop = false;
            // 
            // txtMessages
            // 
            this.txtMessages.BackColor = System.Drawing.Color.White;
            this.txtMessages.ContextMenuStrip = this.ctxMessages;
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(2, 22);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessages.Size = new System.Drawing.Size(1002, 73);
            this.txtMessages.TabIndex = 0;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messagesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.Checked = true;
            this.messagesToolStripMenuItem.CheckOnClick = true;
            this.messagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.messagesToolStripMenuItem.Text = "Messages";
            this.messagesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.messagesToolStripMenuItem_CheckedChanged);
            // 
            // ctxMessages
            // 
            this.ctxMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem3,
            this.hideToolStripMenuItem});
            this.ctxMessages.Name = "ctxMessages";
            this.ctxMessages.Size = new System.Drawing.Size(103, 98);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(99, 6);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1002, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splContMain
            // 
            this.splContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContMain.Location = new System.Drawing.Point(0, 49);
            this.splContMain.Name = "splContMain";
            // 
            // splContMain.Panel1
            // 
            this.splContMain.Panel1.Controls.Add(this.pnlRunMenu);
            this.splContMain.Panel1.Controls.Add(this.pnlRunPanelSpacer);
            this.splContMain.Panel1.Controls.Add(this.pnlRunDetails);
            this.splContMain.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splContMain.Panel2
            // 
            this.splContMain.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splContMain.Size = new System.Drawing.Size(1006, 388);
            this.splContMain.SplitterDistance = 200;
            this.splContMain.TabIndex = 5;
            // 
            // pnlRunMenu
            // 
            this.pnlRunMenu.BackColor = System.Drawing.Color.White;
            this.pnlRunMenu.Controls.Add(this.lstRuns);
            this.pnlRunMenu.Controls.Add(this.lblRuns);
            this.pnlRunMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRunMenu.ForeColor = System.Drawing.Color.Black;
            this.pnlRunMenu.Location = new System.Drawing.Point(2, 2);
            this.pnlRunMenu.Name = "pnlRunMenu";
            this.pnlRunMenu.Size = new System.Drawing.Size(196, 286);
            this.pnlRunMenu.TabIndex = 0;
            // 
            // lblRuns
            // 
            this.lblRuns.BackColor = System.Drawing.Color.DimGray;
            this.lblRuns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRuns.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRuns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuns.ForeColor = System.Drawing.Color.White;
            this.lblRuns.Location = new System.Drawing.Point(0, 0);
            this.lblRuns.Name = "lblRuns";
            this.lblRuns.Size = new System.Drawing.Size(196, 20);
            this.lblRuns.TabIndex = 2;
            this.lblRuns.Text = "Runs";
            this.lblRuns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRunDetails
            // 
            this.pnlRunDetails.BackColor = System.Drawing.Color.White;
            this.pnlRunDetails.Controls.Add(this.lblRunLapCount);
            this.pnlRunDetails.Controls.Add(this.lblAverageLap);
            this.pnlRunDetails.Controls.Add(this.lblBestLap);
            this.pnlRunDetails.Controls.Add(this.label5);
            this.pnlRunDetails.Controls.Add(this.label4);
            this.pnlRunDetails.Controls.Add(this.lblRunNumber);
            this.pnlRunDetails.Controls.Add(this.lblRunDetails);
            this.pnlRunDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRunDetails.Location = new System.Drawing.Point(2, 290);
            this.pnlRunDetails.Name = "pnlRunDetails";
            this.pnlRunDetails.Size = new System.Drawing.Size(196, 96);
            this.pnlRunDetails.TabIndex = 1;
            // 
            // lblRunDetails
            // 
            this.lblRunDetails.BackColor = System.Drawing.Color.DimGray;
            this.lblRunDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRunDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRunDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunDetails.ForeColor = System.Drawing.Color.White;
            this.lblRunDetails.Location = new System.Drawing.Point(0, 0);
            this.lblRunDetails.Margin = new System.Windows.Forms.Padding(3);
            this.lblRunDetails.Name = "lblRunDetails";
            this.lblRunDetails.Padding = new System.Windows.Forms.Padding(2);
            this.lblRunDetails.Size = new System.Drawing.Size(196, 20);
            this.lblRunDetails.TabIndex = 2;
            this.lblRunDetails.Text = "Run Details";
            this.lblRunDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRunPanelSpacer
            // 
            this.pnlRunPanelSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRunPanelSpacer.Location = new System.Drawing.Point(2, 288);
            this.pnlRunPanelSpacer.Name = "pnlRunPanelSpacer";
            this.pnlRunPanelSpacer.Size = new System.Drawing.Size(196, 2);
            this.pnlRunPanelSpacer.TabIndex = 2;
            // 
            // lblRunNumber
            // 
            this.lblRunNumber.AutoSize = true;
            this.lblRunNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunNumber.Location = new System.Drawing.Point(10, 23);
            this.lblRunNumber.Name = "lblRunNumber";
            this.lblRunNumber.Size = new System.Drawing.Size(47, 16);
            this.lblRunNumber.TabIndex = 3;
            this.lblRunNumber.Text = "Run #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Best:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Avg:";
            // 
            // lblBestLap
            // 
            this.lblBestLap.AutoSize = true;
            this.lblBestLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestLap.Location = new System.Drawing.Point(63, 47);
            this.lblBestLap.Name = "lblBestLap";
            this.lblBestLap.Size = new System.Drawing.Size(49, 16);
            this.lblBestLap.TabIndex = 7;
            this.lblBestLap.Text = "0.00:00";
            // 
            // lblAverageLap
            // 
            this.lblAverageLap.AutoSize = true;
            this.lblAverageLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageLap.Location = new System.Drawing.Point(63, 70);
            this.lblAverageLap.Name = "lblAverageLap";
            this.lblAverageLap.Size = new System.Drawing.Size(49, 16);
            this.lblAverageLap.TabIndex = 8;
            this.lblAverageLap.Text = "0.00:00";
            // 
            // lblRunLapCount
            // 
            this.lblRunLapCount.AutoSize = true;
            this.lblRunLapCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunLapCount.Location = new System.Drawing.Point(63, 23);
            this.lblRunLapCount.Name = "lblRunLapCount";
            this.lblRunLapCount.Size = new System.Drawing.Size(62, 16);
            this.lblRunLapCount.TabIndex = 9;
            this.lblRunLapCount.Text = "### Laps";
            // 
            // lstRuns
            // 
            this.lstRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRuns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRuns.FormattingEnabled = true;
            this.lstRuns.ItemHeight = 16;
            this.lstRuns.Items.AddRange(new object[] {
            "1   - 10 Laps",
            "2   -  5 Laps",
            "3   - 12 Laps"});
            this.lstRuns.Location = new System.Drawing.Point(0, 20);
            this.lstRuns.Name = "lstRuns";
            this.lstRuns.Size = new System.Drawing.Size(196, 266);
            this.lstRuns.TabIndex = 3;
            this.lstRuns.SelectedIndexChanged += new System.EventHandler(this.lstRuns_SelectedIndexChanged);
            // 
            // TrackSessionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1006, 559);
            this.Controls.Add(this.splContMain);
            this.Controls.Add(this.splMessages);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrackSessionManager";
            this.Text = "Track Session Manager";
            this.Load += new System.EventHandler(this.TrackSessionManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMessages.ResumeLayout(false);
            this.pnlMessages.PerformLayout();
            this.ctxMessages.ResumeLayout(false);
            this.splContMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContMain)).EndInit();
            this.splContMain.ResumeLayout(false);
            this.pnlRunMenu.ResumeLayout(false);
            this.pnlRunDetails.ResumeLayout(false);
            this.pnlRunDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.Splitter splMessages;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxMessages;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splContMain;
        private System.Windows.Forms.Panel pnlRunDetails;
        private System.Windows.Forms.Label lblRunDetails;
        private System.Windows.Forms.Panel pnlRunMenu;
        private System.Windows.Forms.Label lblRuns;
        private System.Windows.Forms.Panel pnlRunPanelSpacer;
        private System.Windows.Forms.Label lblRunLapCount;
        private System.Windows.Forms.Label lblAverageLap;
        private System.Windows.Forms.Label lblBestLap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRunNumber;
        private System.Windows.Forms.ListBox lstRuns;
    }
}
