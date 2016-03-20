namespace TrackSession.Controls
{
    partial class LogFileView
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
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLogFile
            // 
            this.txtLogFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogFile.Location = new System.Drawing.Point(8, 28);
            this.txtLogFile.Multiline = true;
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogFile.Size = new System.Drawing.Size(534, 361);
            this.txtLogFile.TabIndex = 0;
            // 
            // txtLogFilePath
            // 
            this.txtLogFilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLogFilePath.Location = new System.Drawing.Point(8, 8);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.ReadOnly = true;
            this.txtLogFilePath.Size = new System.Drawing.Size(534, 20);
            this.txtLogFilePath.TabIndex = 1;
            // 
            // LogFileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLogFile);
            this.Controls.Add(this.txtLogFilePath);
            this.Name = "LogFileView";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(550, 397);
            this.Load += new System.EventHandler(this.LogFileView_Load);
            this.Enter += new System.EventHandler(this.LogFileView_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.TextBox txtLogFilePath;
    }
}
