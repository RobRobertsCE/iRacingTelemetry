namespace TelemetryViewer
{
    partial class MainViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainViewer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOpenFile = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbOpenTelemetry = new System.Windows.Forms.ToolStripButton();
            this.openTelemetryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeTelemetryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCloseTelemetry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbAddControl = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAddSessionView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAddGraphView = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlViews = new System.Windows.Forms.Panel();
            this.saveWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpenFile,
            this.tsbClose,
            this.tsbExit,
            this.toolStripSeparator1,
            this.tsbOpenTelemetry,
            this.tsbCloseTelemetry,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWorkspaceToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveWorkspaceToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem3,
            this.openTelemetryToolStripMenuItem,
            this.closeTelemetryToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openToolStripMenuItem.Text = "&Open Workspace";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.closeToolStripMenuItem.Text = "C&lose Workspace";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // tsbOpenFile
            // 
            this.tsbOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenFile.Image")));
            this.tsbOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFile.Name = "tsbOpenFile";
            this.tsbOpenFile.Size = new System.Drawing.Size(101, 22);
            this.tsbOpenFile.Text = "Open Workspace";
            this.tsbOpenFile.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(101, 22);
            this.tsbClose.Text = "Close Workspace";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(29, 22);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbOpenTelemetry
            // 
            this.tsbOpenTelemetry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOpenTelemetry.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenTelemetry.Image")));
            this.tsbOpenTelemetry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenTelemetry.Name = "tsbOpenTelemetry";
            this.tsbOpenTelemetry.Size = new System.Drawing.Size(96, 22);
            this.tsbOpenTelemetry.Text = "Open Telemetry";
            this.tsbOpenTelemetry.Click += new System.EventHandler(this.tsbOpenTelemetry_Click);
            // 
            // openTelemetryToolStripMenuItem
            // 
            this.openTelemetryToolStripMenuItem.Name = "openTelemetryToolStripMenuItem";
            this.openTelemetryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openTelemetryToolStripMenuItem.Text = "Open &Telemetry";
            this.openTelemetryToolStripMenuItem.Click += new System.EventHandler(this.openTelemetryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // closeTelemetryToolStripMenuItem
            // 
            this.closeTelemetryToolStripMenuItem.Name = "closeTelemetryToolStripMenuItem";
            this.closeTelemetryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.closeTelemetryToolStripMenuItem.Text = "Close Telemetry";
            this.closeTelemetryToolStripMenuItem.Click += new System.EventHandler(this.closeTelemetryToolStripMenuItem_Click);
            // 
            // tsbCloseTelemetry
            // 
            this.tsbCloseTelemetry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCloseTelemetry.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseTelemetry.Image")));
            this.tsbCloseTelemetry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseTelemetry.Name = "tsbCloseTelemetry";
            this.tsbCloseTelemetry.Size = new System.Drawing.Size(96, 22);
            this.tsbCloseTelemetry.Text = "Close Telemetry";
            this.tsbCloseTelemetry.Click += new System.EventHandler(this.tsbCloseTelemetry_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLogToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewLogToolStripMenuItem.Text = "View Log";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddControl});
            this.toolStrip2.Location = new System.Drawing.Point(0, 49);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(834, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbAddControl
            // 
            this.tsbAddControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddSessionView,
            this.tsbAddGraphView});
            this.tsbAddControl.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddControl.Image")));
            this.tsbAddControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddControl.Name = "tsbAddControl";
            this.tsbAddControl.Size = new System.Drawing.Size(70, 22);
            this.tsbAddControl.Text = "Add View";
            // 
            // tsbAddSessionView
            // 
            this.tsbAddSessionView.Name = "tsbAddSessionView";
            this.tsbAddSessionView.Size = new System.Drawing.Size(152, 22);
            this.tsbAddSessionView.Text = "Session View";
            this.tsbAddSessionView.Click += new System.EventHandler(this.tsbAddSessionView_Click);
            // 
            // tsbAddGraphView
            // 
            this.tsbAddGraphView.Name = "tsbAddGraphView";
            this.tsbAddGraphView.Size = new System.Drawing.Size(152, 22);
            this.tsbAddGraphView.Text = "Graph View";
            this.tsbAddGraphView.Click += new System.EventHandler(this.tsbAddGraphView_Click);
            // 
            // pnlViews
            // 
            this.pnlViews.BackColor = System.Drawing.Color.White;
            this.pnlViews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViews.Location = new System.Drawing.Point(0, 74);
            this.pnlViews.Name = "pnlViews";
            this.pnlViews.Size = new System.Drawing.Size(834, 288);
            this.pnlViews.TabIndex = 4;
            // 
            // saveWorkspaceToolStripMenuItem
            // 
            this.saveWorkspaceToolStripMenuItem.Name = "saveWorkspaceToolStripMenuItem";
            this.saveWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveWorkspaceToolStripMenuItem.Text = "&Save Workspace";
            this.saveWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.saveWorkspaceToolStripMenuItem_Click);
            // 
            // newWorkspaceToolStripMenuItem
            // 
            this.newWorkspaceToolStripMenuItem.Name = "newWorkspaceToolStripMenuItem";
            this.newWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newWorkspaceToolStripMenuItem.Text = "&New Workspace";
            this.newWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.newWorkspaceToolStripMenuItem_Click);
            // 
            // MainViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(834, 384);
            this.Controls.Add(this.pnlViews);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainViewer";
            this.Text = "MainViewer";
            this.Load += new System.EventHandler(this.MainViewer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpenFile;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem openTelemetryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTelemetryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbOpenTelemetry;
        private System.Windows.Forms.ToolStripButton tsbCloseTelemetry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton tsbAddControl;
        private System.Windows.Forms.ToolStripMenuItem tsbAddSessionView;
        private System.Windows.Forms.ToolStripMenuItem tsbAddGraphView;
        private System.Windows.Forms.Panel pnlViews;
        private System.Windows.Forms.ToolStripMenuItem saveWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWorkspaceToolStripMenuItem;
    }
}