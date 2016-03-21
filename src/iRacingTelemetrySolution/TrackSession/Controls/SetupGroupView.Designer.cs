namespace TrackSession.Controls
{
    partial class SetupGroupView
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
            this.lblGroupName = new System.Windows.Forms.Label();
            this.pnlLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblGroupName
            // 
            this.lblGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.ForeColor = System.Drawing.Color.White;
            this.lblGroupName.Location = new System.Drawing.Point(2, 2);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(275, 22);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "GROUP:";
            this.lblGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLayout
            // 
            this.pnlLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayout.Location = new System.Drawing.Point(2, 24);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.Size = new System.Drawing.Size(275, 265);
            this.pnlLayout.TabIndex = 1;
            // 
            // SetupGroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLayout);
            this.Controls.Add(this.lblGroupName);
            this.Name = "SetupGroupView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(279, 291);
            this.Load += new System.EventHandler(this.SetupGroupView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.FlowLayoutPanel pnlLayout;
    }
}
