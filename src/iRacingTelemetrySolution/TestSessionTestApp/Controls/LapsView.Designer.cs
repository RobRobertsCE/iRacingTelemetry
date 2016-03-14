namespace TestSessionTestApp.Controls
{
    partial class LapsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvLaps = new System.Windows.Forms.ListView();
            this.chLaps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLapTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblBest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBestLapClean = new System.Windows.Forms.TextBox();
            this.txtAverageLapClean = new System.Windows.Forms.TextBox();
            this.grpRaw = new System.Windows.Forms.GroupBox();
            this.grpCleanLaps = new System.Windows.Forms.GroupBox();
            this.txtAverageLapAll = new System.Windows.Forms.TextBox();
            this.txtBestLapAll = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpRaw.SuspendLayout();
            this.grpCleanLaps.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLaps
            // 
            this.lvLaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLaps,
            this.chLapTime});
            this.lvLaps.GridLines = true;
            this.lvLaps.HideSelection = false;
            this.lvLaps.Location = new System.Drawing.Point(3, 19);
            this.lvLaps.MultiSelect = false;
            this.lvLaps.Name = "lvLaps";
            this.lvLaps.Size = new System.Drawing.Size(188, 322);
            this.lvLaps.TabIndex = 0;
            this.lvLaps.UseCompatibleStateImageBehavior = false;
            this.lvLaps.View = System.Windows.Forms.View.Details;
            // 
            // chLaps
            // 
            this.chLaps.Text = "Lap #";
            // 
            // chLapTime
            // 
            this.chLapTime.Text = "Lap Time";
            this.chLapTime.Width = 125;
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.Location = new System.Drawing.Point(18, 22);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(49, 13);
            this.lblBest.TabIndex = 1;
            this.lblBest.Text = "Best Lap";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Average Lap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Laps";
            // 
            // txtBestLapClean
            // 
            this.txtBestLapClean.Location = new System.Drawing.Point(18, 38);
            this.txtBestLapClean.Name = "txtBestLapClean";
            this.txtBestLapClean.ReadOnly = true;
            this.txtBestLapClean.Size = new System.Drawing.Size(161, 20);
            this.txtBestLapClean.TabIndex = 4;
            // 
            // txtAverageLapClean
            // 
            this.txtAverageLapClean.Location = new System.Drawing.Point(21, 89);
            this.txtAverageLapClean.Name = "txtAverageLapClean";
            this.txtAverageLapClean.ReadOnly = true;
            this.txtAverageLapClean.Size = new System.Drawing.Size(161, 20);
            this.txtAverageLapClean.TabIndex = 5;
            // 
            // grpRaw
            // 
            this.grpRaw.Controls.Add(this.txtAverageLapAll);
            this.grpRaw.Controls.Add(this.txtBestLapAll);
            this.grpRaw.Controls.Add(this.label3);
            this.grpRaw.Controls.Add(this.label4);
            this.grpRaw.Location = new System.Drawing.Point(197, 19);
            this.grpRaw.Name = "grpRaw";
            this.grpRaw.Size = new System.Drawing.Size(196, 158);
            this.grpRaw.TabIndex = 6;
            this.grpRaw.TabStop = false;
            this.grpRaw.Text = "All Laps";
            // 
            // grpCleanLaps
            // 
            this.grpCleanLaps.Controls.Add(this.txtBestLapClean);
            this.grpCleanLaps.Controls.Add(this.lblBest);
            this.grpCleanLaps.Controls.Add(this.txtAverageLapClean);
            this.grpCleanLaps.Controls.Add(this.label1);
            this.grpCleanLaps.Location = new System.Drawing.Point(197, 183);
            this.grpCleanLaps.Name = "grpCleanLaps";
            this.grpCleanLaps.Size = new System.Drawing.Size(196, 158);
            this.grpCleanLaps.TabIndex = 7;
            this.grpCleanLaps.TabStop = false;
            this.grpCleanLaps.Text = "Clean Laps";
            // 
            // txtAverageLapAll
            // 
            this.txtAverageLapAll.Location = new System.Drawing.Point(18, 88);
            this.txtAverageLapAll.Name = "txtAverageLapAll";
            this.txtAverageLapAll.ReadOnly = true;
            this.txtAverageLapAll.Size = new System.Drawing.Size(161, 20);
            this.txtAverageLapAll.TabIndex = 9;
            // 
            // txtBestLapAll
            // 
            this.txtBestLapAll.Location = new System.Drawing.Point(15, 37);
            this.txtBestLapAll.Name = "txtBestLapAll";
            this.txtBestLapAll.ReadOnly = true;
            this.txtBestLapAll.Size = new System.Drawing.Size(161, 20);
            this.txtBestLapAll.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Average Lap";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Best Lap";
            // 
            // LapsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCleanLaps);
            this.Controls.Add(this.grpRaw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvLaps);
            this.Name = "LapsView";
            this.Size = new System.Drawing.Size(399, 353);
            this.grpRaw.ResumeLayout(false);
            this.grpRaw.PerformLayout();
            this.grpCleanLaps.ResumeLayout(false);
            this.grpCleanLaps.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLaps;
        private System.Windows.Forms.ColumnHeader chLaps;
        private System.Windows.Forms.ColumnHeader chLapTime;
        private System.Windows.Forms.Label lblBest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBestLapClean;
        private System.Windows.Forms.TextBox txtAverageLapClean;
        private System.Windows.Forms.GroupBox grpRaw;
        private System.Windows.Forms.TextBox txtAverageLapAll;
        private System.Windows.Forms.TextBox txtBestLapAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpCleanLaps;
    }
}
