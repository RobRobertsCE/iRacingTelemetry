namespace TrackSession.Views
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lvLaps.Location = new System.Drawing.Point(0, 84);
            this.lvLaps.Margin = new System.Windows.Forms.Padding(4);
            this.lvLaps.MultiSelect = false;
            this.lvLaps.Name = "lvLaps";
            this.lvLaps.Size = new System.Drawing.Size(189, 459);
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
            this.txtAverageLapAll.Location = new System.Drawing.Point(103, 25);
            this.txtAverageLapAll.Margin = new System.Windows.Forms.Padding(4);
            this.txtAverageLapAll.Name = "txtAverageLapAll";
            this.txtAverageLapAll.ReadOnly = true;
            this.txtAverageLapAll.Size = new System.Drawing.Size(75, 22);
            this.txtAverageLapAll.TabIndex = 9;
            // 
            // txtBestLapAll
            // 
            this.txtBestLapAll.Location = new System.Drawing.Point(8, 25);
            this.txtBestLapAll.Margin = new System.Windows.Forms.Padding(4);
            this.txtBestLapAll.Name = "txtBestLapAll";
            this.txtBestLapAll.ReadOnly = true;
            this.txtBestLapAll.Size = new System.Drawing.Size(75, 22);
            this.txtBestLapAll.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Average:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
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
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 545);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.txtBestLapAll);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtAverageLapAll);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 57);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laps";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LapsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LapsView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(201, 555);
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
