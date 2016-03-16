namespace TestSessionTestApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.TextBox();
            this.tabRuns = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tireSheetView1 = new TestSessionTestApp.Controls.TireSheetView();
            this.lapsView1 = new TestSessionTestApp.Controls.LapsView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabRuns.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 24);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(98, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 24);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // msg
            // 
            this.msg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.msg.Location = new System.Drawing.Point(0, 675);
            this.msg.Multiline = true;
            this.msg.Name = "msg";
            this.msg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.msg.Size = new System.Drawing.Size(1010, 65);
            this.msg.TabIndex = 2;
            // 
            // tabRuns
            // 
            this.tabRuns.Controls.Add(this.tabPage1);
            this.tabRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRuns.Location = new System.Drawing.Point(0, 48);
            this.tabRuns.Name = "tabRuns";
            this.tabRuns.SelectedIndex = 0;
            this.tabRuns.Size = new System.Drawing.Size(1010, 627);
            this.tabRuns.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tireSheetView1);
            this.tabPage1.Controls.Add(this.lapsView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1002, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tireSheetView1
            // 
            this.tireSheetView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tireSheetView1.Location = new System.Drawing.Point(216, 6);
            this.tireSheetView1.Name = "tireSheetView1";
            this.tireSheetView1.Size = new System.Drawing.Size(413, 417);
            this.tireSheetView1.TabIndex = 2;
            // 
            // lapsView1
            // 
            this.lapsView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lapsView1.LapTimes = ((System.Collections.Generic.IList<float>)(resources.GetObject("lapsView1.LapTimes")));
            this.lapsView1.Location = new System.Drawing.Point(8, 6);
            this.lapsView1.Name = "lapsView1";
            this.lapsView1.Padding = new System.Windows.Forms.Padding(4);
            this.lapsView1.Size = new System.Drawing.Size(202, 417);
            this.lapsView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 48);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(918, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 740);
            this.Controls.Add(this.tabRuns);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.msg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabRuns.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox msg;
        private System.Windows.Forms.TabControl tabRuns;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.LapsView lapsView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Controls.TireSheetView tireSheetView1;
    }
}

