namespace TrackSession
{
    partial class TrackSessionManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackSessionManagerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTireSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openTelemetryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMessageLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpenSession = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenRun = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenTireSheet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenTelemetry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveSetup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbStartEngine = new System.Windows.Forms.ToolStripButton();
            this.tsbStopEngine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLogView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLapView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSession = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProcessStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.ctxMessages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.splMessages = new System.Windows.Forms.Splitter();
            this.splContMain = new System.Windows.Forms.SplitContainer();
            this.pnlRunMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstRuns = new System.Windows.Forms.ListBox();
            this.lblRuns = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.splLaps = new System.Windows.Forms.SplitContainer();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabTireSheet = new System.Windows.Forms.TabPage();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.tabTelemetry = new System.Windows.Forms.TabPage();
            this.compareSetupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lapsView1 = new TrackSession.Views.LapsView();
            this.tireSheetView = new TrackSession.Views.TireSheetView2();
            this.setupView1 = new TrackSession.Controls.SetupView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.ctxMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContMain)).BeginInit();
            this.splContMain.Panel1.SuspendLayout();
            this.splContMain.Panel2.SuspendLayout();
            this.splContMain.SuspendLayout();
            this.pnlRunMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splLaps)).BeginInit();
            this.splLaps.Panel1.SuspendLayout();
            this.splLaps.Panel2.SuspendLayout();
            this.splLaps.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabTireSheet.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSessionToolStripMenuItem,
            this.openRunToolStripMenuItem,
            this.openTireSheetToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openTelemetryToolStripMenuItem,
            this.toolStripMenuItem4,
            this.saveSetupToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // openSessionToolStripMenuItem
            // 
            this.openSessionToolStripMenuItem.Image = global::TrackSession.Properties.Resources.Open_6529_24;
            this.openSessionToolStripMenuItem.Name = "openSessionToolStripMenuItem";
            this.openSessionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openSessionToolStripMenuItem.Text = "Open Session";
            this.openSessionToolStripMenuItem.ToolTipText = "Open Session";
            this.openSessionToolStripMenuItem.Click += new System.EventHandler(this.openSessionToolStripMenuItem_Click);
            // 
            // openRunToolStripMenuItem
            // 
            this.openRunToolStripMenuItem.Image = global::TrackSession.Properties.Resources.OpenFileDialog_692_24;
            this.openRunToolStripMenuItem.Name = "openRunToolStripMenuItem";
            this.openRunToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openRunToolStripMenuItem.Text = "Open Run";
            this.openRunToolStripMenuItem.ToolTipText = "Open Run";
            this.openRunToolStripMenuItem.Click += new System.EventHandler(this.openRunToolStripMenuItem_Click);
            // 
            // openTireSheetToolStripMenuItem
            // 
            this.openTireSheetToolStripMenuItem.Image = global::TrackSession.Properties.Resources.Pump_tire_512;
            this.openTireSheetToolStripMenuItem.Name = "openTireSheetToolStripMenuItem";
            this.openTireSheetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openTireSheetToolStripMenuItem.Text = "Open Tire Sheet";
            this.openTireSheetToolStripMenuItem.Click += new System.EventHandler(this.openTireSheetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 6);
            // 
            // openTelemetryToolStripMenuItem
            // 
            this.openTelemetryToolStripMenuItem.Image = global::TrackSession.Properties.Resources.OpenComparisonResult_9697_24;
            this.openTelemetryToolStripMenuItem.Name = "openTelemetryToolStripMenuItem";
            this.openTelemetryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openTelemetryToolStripMenuItem.Text = "Open Telemetry";
            this.openTelemetryToolStripMenuItem.ToolTipText = "Open Telemetry";
            this.openTelemetryToolStripMenuItem.Click += new System.EventHandler(this.openTelemetryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(156, 6);
            // 
            // saveSetupToolStripMenuItem
            // 
            this.saveSetupToolStripMenuItem.Image = global::TrackSession.Properties.Resources.Save;
            this.saveSetupToolStripMenuItem.Name = "saveSetupToolStripMenuItem";
            this.saveSetupToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveSetupToolStripMenuItem.Text = "Save Setup";
            this.saveSetupToolStripMenuItem.Click += new System.EventHandler(this.saveSetupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
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
            this.messagesToolStripMenuItem,
            this.testToolStripMenuItem,
            this.toolStripMenuItem6});
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
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.messagesToolStripMenuItem.Text = "Messages";
            this.messagesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.messagesToolStripMenuItem_CheckedChanged);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(122, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMessageLogToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.compareSetupsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // openMessageLogToolStripMenuItem
            // 
            this.openMessageLogToolStripMenuItem.Image = global::TrackSession.Properties.Resources.RSReport_32xMD;
            this.openMessageLogToolStripMenuItem.Name = "openMessageLogToolStripMenuItem";
            this.openMessageLogToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openMessageLogToolStripMenuItem.Text = "Open Log File";
            this.openMessageLogToolStripMenuItem.Click += new System.EventHandler(this.openMessageLogToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::TrackSession.Properties.Resources.gear_32xLG;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpenSession,
            this.tsbOpenRun,
            this.tsbOpenTireSheet,
            this.toolStripSeparator1,
            this.tsbOpenTelemetry,
            this.toolStripSeparator2,
            this.tsbSaveSetup,
            this.toolStripSeparator3,
            this.tsbStartEngine,
            this.tsbStopEngine,
            this.toolStripSeparator4,
            this.tsbSettings,
            this.toolStripSeparator5,
            this.tsbLogView,
            this.toolStripSeparator6,
            this.tsbLapView,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(992, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpenSession
            // 
            this.tsbOpenSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenSession.Image = global::TrackSession.Properties.Resources.Open_6529_24;
            this.tsbOpenSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenSession.Name = "tsbOpenSession";
            this.tsbOpenSession.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenSession.Text = "toolStripButton1";
            this.tsbOpenSession.ToolTipText = "Open Session";
            this.tsbOpenSession.Click += new System.EventHandler(this.tsbOpenSession_Click);
            // 
            // tsbOpenRun
            // 
            this.tsbOpenRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenRun.Image = global::TrackSession.Properties.Resources.OpenFileDialog_692_24;
            this.tsbOpenRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenRun.Name = "tsbOpenRun";
            this.tsbOpenRun.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenRun.Text = "toolStripButton1";
            this.tsbOpenRun.ToolTipText = "Open Run";
            this.tsbOpenRun.Click += new System.EventHandler(this.tsbOpenRun_Click);
            // 
            // tsbOpenTireSheet
            // 
            this.tsbOpenTireSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenTireSheet.Image = global::TrackSession.Properties.Resources.Pump_tire_512;
            this.tsbOpenTireSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenTireSheet.Name = "tsbOpenTireSheet";
            this.tsbOpenTireSheet.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenTireSheet.Text = "toolStripButton1";
            this.tsbOpenTireSheet.ToolTipText = "Open Tire Sheet (Setup Export)";
            this.tsbOpenTireSheet.Click += new System.EventHandler(this.tsbOpenTireSheet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOpenTelemetry
            // 
            this.tsbOpenTelemetry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenTelemetry.Image = global::TrackSession.Properties.Resources.OpenComparisonResult_9697_24;
            this.tsbOpenTelemetry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenTelemetry.Name = "tsbOpenTelemetry";
            this.tsbOpenTelemetry.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenTelemetry.Text = "toolStripButton1";
            this.tsbOpenTelemetry.ToolTipText = "Open Telemetry";
            this.tsbOpenTelemetry.Click += new System.EventHandler(this.tsbOpenTelemetry_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSaveSetup
            // 
            this.tsbSaveSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveSetup.Image = global::TrackSession.Properties.Resources.Save;
            this.tsbSaveSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveSetup.Name = "tsbSaveSetup";
            this.tsbSaveSetup.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveSetup.Text = "toolStripButton1";
            this.tsbSaveSetup.ToolTipText = "Save Setup";
            this.tsbSaveSetup.Click += new System.EventHandler(this.tsbSaveSetup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbStartEngine
            // 
            this.tsbStartEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStartEngine.Image = global::TrackSession.Properties.Resources.startwithoutdebugging_6556_24;
            this.tsbStartEngine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStartEngine.Name = "tsbStartEngine";
            this.tsbStartEngine.Size = new System.Drawing.Size(23, 22);
            this.tsbStartEngine.Text = "toolStripButton1";
            this.tsbStartEngine.ToolTipText = "Start Monitor Engine";
            this.tsbStartEngine.Click += new System.EventHandler(this.tsbStartEngine_Click);
            // 
            // tsbStopEngine
            // 
            this.tsbStopEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStopEngine.Enabled = false;
            this.tsbStopEngine.Image = global::TrackSession.Properties.Resources.BreakpointEnabled_6584_16x;
            this.tsbStopEngine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStopEngine.Name = "tsbStopEngine";
            this.tsbStopEngine.Size = new System.Drawing.Size(23, 22);
            this.tsbStopEngine.Text = "toolStripButton1";
            this.tsbStopEngine.ToolTipText = "Stop Monitor Engine";
            this.tsbStopEngine.Click += new System.EventHandler(this.tsbStopEngine_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSettings.Image = global::TrackSession.Properties.Resources.gear_32xLG;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(23, 22);
            this.tsbSettings.Text = "toolStripButton1";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLogView
            // 
            this.tsbLogView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLogView.Image = global::TrackSession.Properties.Resources.RSReport_32xMD;
            this.tsbLogView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogView.Name = "tsbLogView";
            this.tsbLogView.Size = new System.Drawing.Size(23, 22);
            this.tsbLogView.Text = "toolStripButton1";
            this.tsbLogView.ToolTipText = "Log File";
            this.tsbLogView.Click += new System.EventHandler(this.tsbLogView_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLapView
            // 
            this.tsbLapView.CheckOnClick = true;
            this.tsbLapView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLapView.Image = global::TrackSession.Properties.Resources.stopwatch_hi;
            this.tsbLapView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLapView.Name = "tsbLapView";
            this.tsbLapView.Size = new System.Drawing.Size(23, 22);
            this.tsbLapView.Text = "toolStripButton2";
            this.tsbLapView.ToolTipText = "Laps";
            this.tsbLapView.CheckedChanged += new System.EventHandler(this.tsbLapView_CheckedChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSession,
            this.toolStripStatusLabel1,
            this.lblProcessStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "No Active Session";
            // 
            // lblSession
            // 
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(101, 17);
            this.lblSession.Text = "No Active Session";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(826, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblProcessStatus
            // 
            this.lblProcessStatus.AutoSize = false;
            this.lblProcessStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblProcessStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblProcessStatus.Name = "lblProcessStatus";
            this.lblProcessStatus.Size = new System.Drawing.Size(50, 17);
            // 
            // pnlMessages
            // 
            this.pnlMessages.BackColor = System.Drawing.Color.Black;
            this.pnlMessages.Controls.Add(this.txtMessages);
            this.pnlMessages.Controls.Add(this.label1);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessages.Location = new System.Drawing.Point(0, 389);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Padding = new System.Windows.Forms.Padding(2);
            this.pnlMessages.Size = new System.Drawing.Size(992, 97);
            this.pnlMessages.TabIndex = 3;
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
            this.txtMessages.Size = new System.Drawing.Size(988, 73);
            this.txtMessages.TabIndex = 0;
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
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(988, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splMessages
            // 
            this.splMessages.BackColor = System.Drawing.Color.Silver;
            this.splMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splMessages.Location = new System.Drawing.Point(0, 386);
            this.splMessages.Name = "splMessages";
            this.splMessages.Size = new System.Drawing.Size(992, 3);
            this.splMessages.TabIndex = 0;
            this.splMessages.TabStop = false;
            // 
            // splContMain
            // 
            this.splContMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContMain.IsSplitterFixed = true;
            this.splContMain.Location = new System.Drawing.Point(0, 49);
            this.splContMain.Name = "splContMain";
            // 
            // splContMain.Panel1
            // 
            this.splContMain.Panel1.Controls.Add(this.pnlRunMenu);
            this.splContMain.Panel1.Padding = new System.Windows.Forms.Padding(2);
            this.splContMain.Panel1MinSize = 147;
            // 
            // splContMain.Panel2
            // 
            this.splContMain.Panel2.Controls.Add(this.MainPanel);
            this.splContMain.Size = new System.Drawing.Size(992, 337);
            this.splContMain.SplitterDistance = 147;
            this.splContMain.TabIndex = 5;
            // 
            // pnlRunMenu
            // 
            this.pnlRunMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlRunMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRunMenu.Controls.Add(this.panel1);
            this.pnlRunMenu.Controls.Add(this.lblRuns);
            this.pnlRunMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRunMenu.ForeColor = System.Drawing.Color.Black;
            this.pnlRunMenu.Location = new System.Drawing.Point(2, 2);
            this.pnlRunMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRunMenu.Name = "pnlRunMenu";
            this.pnlRunMenu.Padding = new System.Windows.Forms.Padding(4);
            this.pnlRunMenu.Size = new System.Drawing.Size(143, 333);
            this.pnlRunMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lstRuns);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 296);
            this.panel1.TabIndex = 4;
            // 
            // lstRuns
            // 
            this.lstRuns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRuns.DisplayMember = "Caption";
            this.lstRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRuns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRuns.FormattingEnabled = true;
            this.lstRuns.ItemHeight = 16;
            this.lstRuns.Location = new System.Drawing.Point(0, 0);
            this.lstRuns.Name = "lstRuns";
            this.lstRuns.Size = new System.Drawing.Size(133, 296);
            this.lstRuns.TabIndex = 3;
            this.lstRuns.SelectedIndexChanged += new System.EventHandler(this.lstRuns_SelectedIndexChanged);
            // 
            // lblRuns
            // 
            this.lblRuns.BackColor = System.Drawing.Color.Gray;
            this.lblRuns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRuns.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRuns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuns.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRuns.Location = new System.Drawing.Point(4, 4);
            this.lblRuns.Margin = new System.Windows.Forms.Padding(0);
            this.lblRuns.Name = "lblRuns";
            this.lblRuns.Size = new System.Drawing.Size(133, 27);
            this.lblRuns.TabIndex = 2;
            this.lblRuns.Text = "Runs";
            this.lblRuns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainPanel.Controls.Add(this.splLaps);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(841, 337);
            this.MainPanel.TabIndex = 1;
            // 
            // splLaps
            // 
            this.splLaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splLaps.IsSplitterFixed = true;
            this.splLaps.Location = new System.Drawing.Point(0, 0);
            this.splLaps.Name = "splLaps";
            // 
            // splLaps.Panel1
            // 
            this.splLaps.Panel1.Controls.Add(this.lapsView1);
            this.splLaps.Panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.splLaps.Panel1MinSize = 205;
            // 
            // splLaps.Panel2
            // 
            this.splLaps.Panel2.Controls.Add(this.tcMain);
            this.splLaps.Size = new System.Drawing.Size(841, 337);
            this.splLaps.SplitterDistance = 205;
            this.splLaps.TabIndex = 1;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabTireSheet);
            this.tcMain.Controls.Add(this.tabSetup);
            this.tcMain.Controls.Add(this.tabTelemetry);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(632, 337);
            this.tcMain.TabIndex = 1;
            // 
            // tabTireSheet
            // 
            this.tabTireSheet.Controls.Add(this.tireSheetView);
            this.tabTireSheet.Location = new System.Drawing.Point(4, 22);
            this.tabTireSheet.Name = "tabTireSheet";
            this.tabTireSheet.Padding = new System.Windows.Forms.Padding(3);
            this.tabTireSheet.Size = new System.Drawing.Size(624, 311);
            this.tabTireSheet.TabIndex = 0;
            this.tabTireSheet.Text = "Tire Sheet";
            this.tabTireSheet.UseVisualStyleBackColor = true;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.setupView1);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(624, 311);
            this.tabSetup.TabIndex = 1;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // tabTelemetry
            // 
            this.tabTelemetry.Location = new System.Drawing.Point(4, 22);
            this.tabTelemetry.Name = "tabTelemetry";
            this.tabTelemetry.Size = new System.Drawing.Size(624, 311);
            this.tabTelemetry.TabIndex = 2;
            this.tabTelemetry.Text = "Telemetry";
            this.tabTelemetry.UseVisualStyleBackColor = true;
            // 
            // compareSetupsToolStripMenuItem
            // 
            this.compareSetupsToolStripMenuItem.Name = "compareSetupsToolStripMenuItem";
            this.compareSetupsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.compareSetupsToolStripMenuItem.Text = "Compare Setups";
            this.compareSetupsToolStripMenuItem.Click += new System.EventHandler(this.compareSetupsToolStripMenuItem_Click);
            // 
            // lapsView1
            // 
            this.lapsView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lapsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lapsView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lapsView1.LapTimes = ((System.Collections.Generic.IList<float>)(resources.GetObject("lapsView1.LapTimes")));
            this.lapsView1.Location = new System.Drawing.Point(0, 2);
            this.lapsView1.Margin = new System.Windows.Forms.Padding(4);
            this.lapsView1.Name = "lapsView1";
            this.lapsView1.Padding = new System.Windows.Forms.Padding(5);
            this.lapsView1.Size = new System.Drawing.Size(205, 335);
            this.lapsView1.TabIndex = 0;
            // 
            // tireSheetView
            // 
            this.tireSheetView.BackColor = System.Drawing.Color.LightGray;
            this.tireSheetView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tireSheetView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tireSheetView.Location = new System.Drawing.Point(3, 3);
            this.tireSheetView.Margin = new System.Windows.Forms.Padding(4);
            this.tireSheetView.Name = "tireSheetView";
            this.tireSheetView.Size = new System.Drawing.Size(618, 305);
            this.tireSheetView.TabIndex = 0;
            // 
            // setupView1
            // 
            this.setupView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupView1.Location = new System.Drawing.Point(3, 3);
            this.setupView1.Name = "setupView1";
            this.setupView1.Size = new System.Drawing.Size(618, 305);
            this.setupView1.TabIndex = 0;
            // 
            // TrackSessionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(992, 508);
            this.Controls.Add(this.splContMain);
            this.Controls.Add(this.splMessages);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrackSessionManagerForm";
            this.Text = "Track Session Manager";
            this.Load += new System.EventHandler(this.TrackSessionManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlMessages.ResumeLayout(false);
            this.pnlMessages.PerformLayout();
            this.ctxMessages.ResumeLayout(false);
            this.splContMain.Panel1.ResumeLayout(false);
            this.splContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContMain)).EndInit();
            this.splContMain.ResumeLayout(false);
            this.pnlRunMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.splLaps.Panel1.ResumeLayout(false);
            this.splLaps.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splLaps)).EndInit();
            this.splLaps.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabTireSheet.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlRunMenu;
        private System.Windows.Forms.Label lblRuns;
        private System.Windows.Forms.ListBox lstRuns;
        private System.Windows.Forms.ToolStripMenuItem openSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTelemetryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripStatusLabel lblSession;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripButton tsbOpenSession;
        private System.Windows.Forms.ToolStripButton tsbOpenRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbOpenTelemetry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSaveSetup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbStartEngine;
        private System.Windows.Forms.ToolStripButton tsbStopEngine;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMessageLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbLogView;
        private System.Windows.Forms.ToolStripButton tsbLapView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.SplitContainer splLaps;
        private Views.LapsView lapsView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem openTireSheetToolStripMenuItem;
        private Views.TireSheetView2 tireSheetView;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabTireSheet;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabTelemetry;
        private System.Windows.Forms.ToolStripButton tsbOpenTireSheet;
        private Controls.SetupView setupView1;
        private System.Windows.Forms.ToolStripMenuItem compareSetupsToolStripMenuItem;
    }
}

