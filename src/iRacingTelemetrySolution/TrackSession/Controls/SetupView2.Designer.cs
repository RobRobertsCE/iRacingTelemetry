namespace TrackSession.Controls
{
    partial class SetupView2
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
            this.sgvChassisRear = new TrackSession.Controls.SetupGroupView();
            this.sgvChassisRightRear = new TrackSession.Controls.SetupGroupView();
            this.sgvChassisLeftRear = new TrackSession.Controls.SetupGroupView();
            this.sgvChassisRightFront = new TrackSession.Controls.SetupGroupView();
            this.sgvChassisLeftFront = new TrackSession.Controls.SetupGroupView();
            this.sgvChassisFront = new TrackSession.Controls.SetupGroupView();
            this.SuspendLayout();
            // 
            // sgvChassisRear
            // 
            this.sgvChassisRear.GroupName = "REAR";
            this.sgvChassisRear.GroupValues = null;
            this.sgvChassisRear.Location = new System.Drawing.Point(155, 683);
            this.sgvChassisRear.Name = "sgvChassisRear";
            this.sgvChassisRear.Padding = new System.Windows.Forms.Padding(2);
            this.sgvChassisRear.Size = new System.Drawing.Size(295, 90);
            this.sgvChassisRear.TabIndex = 5;
            // 
            // sgvChassisRightRear
            // 
            this.sgvChassisRightRear.GroupName = "RIGHT REAR";
            this.sgvChassisRightRear.GroupValues = null;
            this.sgvChassisRightRear.Location = new System.Drawing.Point(304, 475);
            this.sgvChassisRightRear.Name = "sgvChassisRightRear";
            this.sgvChassisRightRear.Padding = new System.Windows.Forms.Padding(2);
            this.sgvChassisRightRear.Size = new System.Drawing.Size(295, 202);
            this.sgvChassisRightRear.TabIndex = 4;
            // 
            // sgvChassisLeftRear
            // 
            this.sgvChassisLeftRear.GroupName = "LEFT REAR";
            this.sgvChassisLeftRear.GroupValues = null;
            this.sgvChassisLeftRear.Location = new System.Drawing.Point(3, 475);
            this.sgvChassisLeftRear.Name = "sgvChassisLeftRear";
            this.sgvChassisLeftRear.Padding = new System.Windows.Forms.Padding(2);
            this.sgvChassisLeftRear.Size = new System.Drawing.Size(295, 202);
            this.sgvChassisLeftRear.TabIndex = 3;
            // 
            // sgvChassisRightFront
            // 
            this.sgvChassisRightFront.GroupName = "RIGHT FRONT";
            this.sgvChassisRightFront.GroupValues = null;
            this.sgvChassisRightFront.Location = new System.Drawing.Point(304, 267);
            this.sgvChassisRightFront.Name = "sgvChassisRightFront";
            this.sgvChassisRightFront.Padding = new System.Windows.Forms.Padding(2);
            this.sgvChassisRightFront.Size = new System.Drawing.Size(295, 202);
            this.sgvChassisRightFront.TabIndex = 2;
            // 
            // sgvChassisLeftFront
            // 
            this.sgvChassisLeftFront.GroupName = "LEFT FRONT";
            this.sgvChassisLeftFront.GroupValues = null;
            this.sgvChassisLeftFront.Location = new System.Drawing.Point(3, 267);
            this.sgvChassisLeftFront.Name = "sgvChassisLeftFront";
            this.sgvChassisLeftFront.Padding = new System.Windows.Forms.Padding(2);
            this.sgvChassisLeftFront.Size = new System.Drawing.Size(295, 202);
            this.sgvChassisLeftFront.TabIndex = 1;
            // 
            // sgvChassisFront
            // 
            this.sgvChassisFront.GroupName = "FRONT";
            this.sgvChassisFront.GroupValues = null;
            this.sgvChassisFront.Location = new System.Drawing.Point(155, 3);
            this.sgvChassisFront.Name = "sgvChassisFront";
            this.sgvChassisFront.Padding = new System.Windows.Forms.Padding(2);
            this.sgvChassisFront.Size = new System.Drawing.Size(295, 258);
            this.sgvChassisFront.TabIndex = 0;
            // 
            // SetupView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.sgvChassisRear);
            this.Controls.Add(this.sgvChassisRightRear);
            this.Controls.Add(this.sgvChassisLeftRear);
            this.Controls.Add(this.sgvChassisRightFront);
            this.Controls.Add(this.sgvChassisLeftFront);
            this.Controls.Add(this.sgvChassisFront);
            this.Name = "SetupView2";
            this.Size = new System.Drawing.Size(606, 867);
            this.ResumeLayout(false);

        }

        #endregion

        private SetupGroupView sgvChassisFront;
        private SetupGroupView sgvChassisLeftFront;
        private SetupGroupView sgvChassisRightFront;
        private SetupGroupView sgvChassisRightRear;
        private SetupGroupView sgvChassisLeftRear;
        private SetupGroupView sgvChassisRear;
    }
}
