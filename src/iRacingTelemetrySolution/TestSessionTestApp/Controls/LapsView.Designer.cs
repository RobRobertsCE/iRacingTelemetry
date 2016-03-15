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
            this.txtAverageLapAll = new System.Windows.Forms.TextBox();
            this.txtBestLapAll = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLaps
            // 
            this.lvLaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLaps,
            this.chLapTime});
            this.lvLaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLaps.GridLines = true;
            this.lvLaps.HideSelection = false;
            this.lvLaps.Location = new System.Drawing.Point(0, 75);
            this.lvLaps.MultiSelect = false;
            this.lvLaps.Name = "lvLaps";
            this.lvLaps.Size = new System.Drawing.Size(195, 366);
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
            // txtAverageLapAll
            // 
            this.txtAverageLapAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAverageLapAll.Location = new System.Drawing.Point(113, 20);
            this.txtAverageLapAll.Name = "txtAverageLapAll";
            this.txtAverageLapAll.ReadOnly = true;
            this.txtAverageLapAll.Size = new System.Drawing.Size(76, 20);
            this.txtAverageLapAll.TabIndex = 9;
            // 
            // txtBestLapAll
            // 
            this.txtBestLapAll.Location = new System.Drawing.Point(6, 20);
            this.txtBestLapAll.Name = "txtBestLapAll";
            this.txtBestLapAll.ReadOnly = true;
            this.txtBestLapAll.Size = new System.Drawing.Size(76, 20);
            this.txtBestLapAll.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Average:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Best:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lvLaps);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 443);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laps";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBestLapAll);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtAverageLapAll);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 53);
            this.panel2.TabIndex = 10;
            // 
            // LapsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LapsView";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(205, 451);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLaps;
        private System.Windows.Forms.ColumnHeader chLaps;
        private System.Windows.Forms.ColumnHeader chLapTime;
        private System.Windows.Forms.TextBox txtAverageLapAll;
        private System.Windows.Forms.TextBox txtBestLapAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
