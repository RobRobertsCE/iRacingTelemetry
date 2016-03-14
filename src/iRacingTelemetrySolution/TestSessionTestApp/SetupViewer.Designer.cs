namespace TestSessionTestApp
{
    partial class SetupViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupViewer));
            this.tabRuns = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tireView1 = new TestSessionTestApp.Controls.TireView();
            this.lapsView1 = new TestSessionTestApp.Controls.LapsView();
            this.tabRuns.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabRuns
            // 
            this.tabRuns.Controls.Add(this.tabPage1);
            this.tabRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRuns.Location = new System.Drawing.Point(0, 0);
            this.tabRuns.Name = "tabRuns";
            this.tabRuns.SelectedIndex = 0;
            this.tabRuns.Size = new System.Drawing.Size(810, 534);
            this.tabRuns.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lapsView1);
            this.tabPage1.Controls.Add(this.tireView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tireView1
            // 
            this.tireView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tireView1.Location = new System.Drawing.Point(413, 19);
            this.tireView1.Name = "tireView1";
            this.tireView1.Size = new System.Drawing.Size(351, 353);
            this.tireView1.TabIndex = 0;
            // 
            // lapsView1
            // 
            this.lapsView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lapsView1.LapTimes = ((System.Collections.Generic.IList<float>)(resources.GetObject("lapsView1.LapTimes")));
            this.lapsView1.Location = new System.Drawing.Point(8, 19);
            this.lapsView1.Name = "lapsView1";
            this.lapsView1.Size = new System.Drawing.Size(399, 353);
            this.lapsView1.TabIndex = 1;
            // 
            // SetupViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 534);
            this.Controls.Add(this.tabRuns);
            this.Name = "SetupViewer";
            this.Text = "SetupViewer";
            this.Load += new System.EventHandler(this.SetupViewer_Load);
            this.tabRuns.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRuns;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.LapsView lapsView1;
        private Controls.TireView tireView1;
    }
}