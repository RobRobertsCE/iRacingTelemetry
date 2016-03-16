namespace TestSessionTestApp.Controls
{
    partial class TrackRunResultsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackRunResultsView));
            this.lapsView1 = new TestSessionTestApp.Controls.LapsView();
            this.tireSheetView1 = new TestSessionTestApp.Controls.TireSheetView();
            this.SuspendLayout();
            // 
            // lapsView1
            // 
            this.lapsView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lapsView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lapsView1.LapTimes = ((System.Collections.Generic.IList<float>)(resources.GetObject("lapsView1.LapTimes")));
            this.lapsView1.Location = new System.Drawing.Point(0, 0);
            this.lapsView1.Margin = new System.Windows.Forms.Padding(4);
            this.lapsView1.Name = "lapsView1";
            this.lapsView1.Padding = new System.Windows.Forms.Padding(5);
            this.lapsView1.Size = new System.Drawing.Size(273, 598);
            this.lapsView1.TabIndex = 0;
            // 
            // tireSheetView1
            // 
            this.tireSheetView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tireSheetView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tireSheetView1.Location = new System.Drawing.Point(273, 0);
            this.tireSheetView1.Margin = new System.Windows.Forms.Padding(4);
            this.tireSheetView1.Name = "tireSheetView1";
            this.tireSheetView1.Size = new System.Drawing.Size(535, 598);
            this.tireSheetView1.TabIndex = 1;
            // 
            // TrackRunResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tireSheetView1);
            this.Controls.Add(this.lapsView1);
            this.Name = "TrackRunResultsView";
            this.Size = new System.Drawing.Size(808, 598);
            this.ResumeLayout(false);

        }

        #endregion

        public TireSheetView tireSheetView1;
        public LapsView lapsView1;
    }
}
