namespace TelemetryViewer.Controls
{
    partial class TelemetryViewControl
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTelemetryViewControl = new System.Windows.Forms.Label();
            this.Canvas = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Silver;
            this.pnlTop.Controls.Add(this.lblTelemetryViewControl);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(447, 28);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // lblTelemetryViewControl
            // 
            this.lblTelemetryViewControl.AutoSize = true;
            this.lblTelemetryViewControl.Location = new System.Drawing.Point(4, 5);
            this.lblTelemetryViewControl.Name = "lblTelemetryViewControl";
            this.lblTelemetryViewControl.Size = new System.Drawing.Size(154, 17);
            this.lblTelemetryViewControl.TabIndex = 0;
            this.lblTelemetryViewControl.Text = "Telemetry View Control";
            this.lblTelemetryViewControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.lblTelemetryViewControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 28);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(447, 209);
            this.Canvas.TabIndex = 1;
            this.Canvas.DoubleClick += new System.EventHandler(this.Canvas_DoubleClick);
            // 
            // TelemetryViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.pnlTop);
            this.Name = "TelemetryViewControl";
            this.Size = new System.Drawing.Size(447, 237);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTelemetryViewControl;
        protected internal System.Windows.Forms.Panel Canvas;
    }
}
