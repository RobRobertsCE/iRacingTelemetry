namespace TestSessionTestApp.Controls
{
    partial class TireView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label coldPressureLabel2;
            System.Windows.Forms.Label lastHotPressureLabel2;
            System.Windows.Forms.Label lastTempsIMOLabel;
            System.Windows.Forms.Label staggerLabel;
            System.Windows.Forms.Label treadRemainingLabel2;
            System.Windows.Forms.Label coldPressureLabel3;
            System.Windows.Forms.Label lastHotPressureLabel3;
            System.Windows.Forms.Label lastTempsIMOLabel1;
            System.Windows.Forms.Label staggerLabel1;
            System.Windows.Forms.Label treadRemainingLabel3;
            this.modifiedSetup_SetupTiresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldPressureTextBox = new System.Windows.Forms.TextBox();
            this.lastHotPressureTextBox = new System.Windows.Forms.TextBox();
            this.lastTempsOMITextBox = new System.Windows.Forms.TextBox();
            this.treadRemainingTextBox = new System.Windows.Forms.TextBox();
            this.coldPressureTextBox1 = new System.Windows.Forms.TextBox();
            this.lastHotPressureTextBox1 = new System.Windows.Forms.TextBox();
            this.lastTempsOMITextBox1 = new System.Windows.Forms.TextBox();
            this.treadRemainingTextBox1 = new System.Windows.Forms.TextBox();
            this.coldPressureTextBox2 = new System.Windows.Forms.TextBox();
            this.lastHotPressureTextBox2 = new System.Windows.Forms.TextBox();
            this.lastTempsIMOTextBox = new System.Windows.Forms.TextBox();
            this.staggerTextBox = new System.Windows.Forms.TextBox();
            this.treadRemainingTextBox2 = new System.Windows.Forms.TextBox();
            this.coldPressureTextBox3 = new System.Windows.Forms.TextBox();
            this.lastHotPressureTextBox3 = new System.Windows.Forms.TextBox();
            this.lastTempsIMOTextBox1 = new System.Windows.Forms.TextBox();
            this.staggerTextBox1 = new System.Windows.Forms.TextBox();
            this.treadRemainingTextBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            coldPressureLabel2 = new System.Windows.Forms.Label();
            lastHotPressureLabel2 = new System.Windows.Forms.Label();
            lastTempsIMOLabel = new System.Windows.Forms.Label();
            staggerLabel = new System.Windows.Forms.Label();
            treadRemainingLabel2 = new System.Windows.Forms.Label();
            coldPressureLabel3 = new System.Windows.Forms.Label();
            lastHotPressureLabel3 = new System.Windows.Forms.Label();
            lastTempsIMOLabel1 = new System.Windows.Forms.Label();
            staggerLabel1 = new System.Windows.Forms.Label();
            treadRemainingLabel3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedSetup_SetupTiresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // modifiedSetup_SetupTiresBindingSource
            // 
            this.modifiedSetup_SetupTiresBindingSource.DataSource = typeof(iRacing.SetupLibrary.ModifiedSetup.SetupTires);
            // 
            // coldPressureTextBox
            // 
            this.coldPressureTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftFront.ColdPressure", true));
            this.coldPressureTextBox.Location = new System.Drawing.Point(23, 29);
            this.coldPressureTextBox.Name = "coldPressureTextBox";
            this.coldPressureTextBox.Size = new System.Drawing.Size(100, 20);
            this.coldPressureTextBox.TabIndex = 2;
            // 
            // lastHotPressureTextBox
            // 
            this.lastHotPressureTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftFront.LastHotPressure", true));
            this.lastHotPressureTextBox.Location = new System.Drawing.Point(23, 55);
            this.lastHotPressureTextBox.Name = "lastHotPressureTextBox";
            this.lastHotPressureTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastHotPressureTextBox.TabIndex = 4;
            // 
            // lastTempsOMITextBox
            // 
            this.lastTempsOMITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftFront.LastTempsOMI", true));
            this.lastTempsOMITextBox.Location = new System.Drawing.Point(23, 81);
            this.lastTempsOMITextBox.Name = "lastTempsOMITextBox";
            this.lastTempsOMITextBox.Size = new System.Drawing.Size(100, 20);
            this.lastTempsOMITextBox.TabIndex = 6;
            // 
            // treadRemainingTextBox
            // 
            this.treadRemainingTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftFront.TreadRemaining", true));
            this.treadRemainingTextBox.Location = new System.Drawing.Point(23, 107);
            this.treadRemainingTextBox.Name = "treadRemainingTextBox";
            this.treadRemainingTextBox.Size = new System.Drawing.Size(100, 20);
            this.treadRemainingTextBox.TabIndex = 8;
            // 
            // coldPressureTextBox1
            // 
            this.coldPressureTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftRear.ColdPressure", true));
            this.coldPressureTextBox1.Location = new System.Drawing.Point(23, 183);
            this.coldPressureTextBox1.Name = "coldPressureTextBox1";
            this.coldPressureTextBox1.Size = new System.Drawing.Size(100, 20);
            this.coldPressureTextBox1.TabIndex = 10;
            // 
            // lastHotPressureTextBox1
            // 
            this.lastHotPressureTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftRear.LastHotPressure", true));
            this.lastHotPressureTextBox1.Location = new System.Drawing.Point(23, 209);
            this.lastHotPressureTextBox1.Name = "lastHotPressureTextBox1";
            this.lastHotPressureTextBox1.Size = new System.Drawing.Size(100, 20);
            this.lastHotPressureTextBox1.TabIndex = 12;
            // 
            // lastTempsOMITextBox1
            // 
            this.lastTempsOMITextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftRear.LastTempsOMI", true));
            this.lastTempsOMITextBox1.Location = new System.Drawing.Point(23, 235);
            this.lastTempsOMITextBox1.Name = "lastTempsOMITextBox1";
            this.lastTempsOMITextBox1.Size = new System.Drawing.Size(100, 20);
            this.lastTempsOMITextBox1.TabIndex = 14;
            // 
            // treadRemainingTextBox1
            // 
            this.treadRemainingTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "LeftRear.TreadRemaining", true));
            this.treadRemainingTextBox1.Location = new System.Drawing.Point(23, 261);
            this.treadRemainingTextBox1.Name = "treadRemainingTextBox1";
            this.treadRemainingTextBox1.Size = new System.Drawing.Size(100, 20);
            this.treadRemainingTextBox1.TabIndex = 16;
            // 
            // coldPressureLabel2
            // 
            coldPressureLabel2.Location = new System.Drawing.Point(130, 33);
            coldPressureLabel2.Name = "coldPressureLabel2";
            coldPressureLabel2.Size = new System.Drawing.Size(94, 13);
            coldPressureLabel2.TabIndex = 17;
            coldPressureLabel2.Text = "Cold Pressure:";
            coldPressureLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coldPressureTextBox2
            // 
            this.coldPressureTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightFront.ColdPressure", true));
            this.coldPressureTextBox2.Location = new System.Drawing.Point(229, 30);
            this.coldPressureTextBox2.Name = "coldPressureTextBox2";
            this.coldPressureTextBox2.Size = new System.Drawing.Size(100, 20);
            this.coldPressureTextBox2.TabIndex = 18;
            // 
            // lastHotPressureLabel2
            // 
            lastHotPressureLabel2.Location = new System.Drawing.Point(130, 59);
            lastHotPressureLabel2.Name = "lastHotPressureLabel2";
            lastHotPressureLabel2.Size = new System.Drawing.Size(94, 13);
            lastHotPressureLabel2.TabIndex = 19;
            lastHotPressureLabel2.Text = "Last Hot Pressure:";
            lastHotPressureLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastHotPressureTextBox2
            // 
            this.lastHotPressureTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightFront.LastHotPressure", true));
            this.lastHotPressureTextBox2.Location = new System.Drawing.Point(229, 56);
            this.lastHotPressureTextBox2.Name = "lastHotPressureTextBox2";
            this.lastHotPressureTextBox2.Size = new System.Drawing.Size(100, 20);
            this.lastHotPressureTextBox2.TabIndex = 20;
            // 
            // lastTempsIMOLabel
            // 
            lastTempsIMOLabel.Location = new System.Drawing.Point(130, 85);
            lastTempsIMOLabel.Name = "lastTempsIMOLabel";
            lastTempsIMOLabel.Size = new System.Drawing.Size(94, 13);
            lastTempsIMOLabel.TabIndex = 21;
            lastTempsIMOLabel.Text = "Last Temps IMO:";
            lastTempsIMOLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastTempsIMOTextBox
            // 
            this.lastTempsIMOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightFront.LastTempsIMO", true));
            this.lastTempsIMOTextBox.Location = new System.Drawing.Point(229, 82);
            this.lastTempsIMOTextBox.Name = "lastTempsIMOTextBox";
            this.lastTempsIMOTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastTempsIMOTextBox.TabIndex = 22;
            // 
            // staggerLabel
            // 
            staggerLabel.Location = new System.Drawing.Point(130, 137);
            staggerLabel.Name = "staggerLabel";
            staggerLabel.Size = new System.Drawing.Size(94, 13);
            staggerLabel.TabIndex = 23;
            staggerLabel.Text = "Stagger:";
            staggerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // staggerTextBox
            // 
            this.staggerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightFront.Stagger", true));
            this.staggerTextBox.Location = new System.Drawing.Point(229, 134);
            this.staggerTextBox.Name = "staggerTextBox";
            this.staggerTextBox.Size = new System.Drawing.Size(100, 20);
            this.staggerTextBox.TabIndex = 24;
            // 
            // treadRemainingLabel2
            // 
            treadRemainingLabel2.Location = new System.Drawing.Point(130, 111);
            treadRemainingLabel2.Name = "treadRemainingLabel2";
            treadRemainingLabel2.Size = new System.Drawing.Size(94, 13);
            treadRemainingLabel2.TabIndex = 25;
            treadRemainingLabel2.Text = "Tread Remaining:";
            treadRemainingLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treadRemainingTextBox2
            // 
            this.treadRemainingTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightFront.TreadRemaining", true));
            this.treadRemainingTextBox2.Location = new System.Drawing.Point(229, 108);
            this.treadRemainingTextBox2.Name = "treadRemainingTextBox2";
            this.treadRemainingTextBox2.Size = new System.Drawing.Size(100, 20);
            this.treadRemainingTextBox2.TabIndex = 26;
            // 
            // coldPressureLabel3
            // 
            coldPressureLabel3.Location = new System.Drawing.Point(130, 187);
            coldPressureLabel3.Name = "coldPressureLabel3";
            coldPressureLabel3.Size = new System.Drawing.Size(94, 13);
            coldPressureLabel3.TabIndex = 27;
            coldPressureLabel3.Text = "Cold Pressure:";
            coldPressureLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coldPressureTextBox3
            // 
            this.coldPressureTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightRear.ColdPressure", true));
            this.coldPressureTextBox3.Location = new System.Drawing.Point(229, 184);
            this.coldPressureTextBox3.Name = "coldPressureTextBox3";
            this.coldPressureTextBox3.Size = new System.Drawing.Size(100, 20);
            this.coldPressureTextBox3.TabIndex = 28;
            // 
            // lastHotPressureLabel3
            // 
            lastHotPressureLabel3.Location = new System.Drawing.Point(130, 213);
            lastHotPressureLabel3.Name = "lastHotPressureLabel3";
            lastHotPressureLabel3.Size = new System.Drawing.Size(94, 13);
            lastHotPressureLabel3.TabIndex = 29;
            lastHotPressureLabel3.Text = "Last Hot Pressure:";
            lastHotPressureLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastHotPressureTextBox3
            // 
            this.lastHotPressureTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightRear.LastHotPressure", true));
            this.lastHotPressureTextBox3.Location = new System.Drawing.Point(229, 210);
            this.lastHotPressureTextBox3.Name = "lastHotPressureTextBox3";
            this.lastHotPressureTextBox3.Size = new System.Drawing.Size(100, 20);
            this.lastHotPressureTextBox3.TabIndex = 30;
            // 
            // lastTempsIMOLabel1
            // 
            lastTempsIMOLabel1.Location = new System.Drawing.Point(130, 239);
            lastTempsIMOLabel1.Name = "lastTempsIMOLabel1";
            lastTempsIMOLabel1.Size = new System.Drawing.Size(94, 13);
            lastTempsIMOLabel1.TabIndex = 31;
            lastTempsIMOLabel1.Text = "Last Temps IMO:";
            lastTempsIMOLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastTempsIMOTextBox1
            // 
            this.lastTempsIMOTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightRear.LastTempsIMO", true));
            this.lastTempsIMOTextBox1.Location = new System.Drawing.Point(229, 236);
            this.lastTempsIMOTextBox1.Name = "lastTempsIMOTextBox1";
            this.lastTempsIMOTextBox1.Size = new System.Drawing.Size(100, 20);
            this.lastTempsIMOTextBox1.TabIndex = 32;
            // 
            // staggerLabel1
            // 
            staggerLabel1.Location = new System.Drawing.Point(130, 291);
            staggerLabel1.Name = "staggerLabel1";
            staggerLabel1.Size = new System.Drawing.Size(94, 13);
            staggerLabel1.TabIndex = 33;
            staggerLabel1.Text = "Stagger:";
            staggerLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // staggerTextBox1
            // 
            this.staggerTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightRear.Stagger", true));
            this.staggerTextBox1.Location = new System.Drawing.Point(229, 288);
            this.staggerTextBox1.Name = "staggerTextBox1";
            this.staggerTextBox1.Size = new System.Drawing.Size(100, 20);
            this.staggerTextBox1.TabIndex = 34;
            // 
            // treadRemainingLabel3
            // 
            treadRemainingLabel3.Location = new System.Drawing.Point(130, 265);
            treadRemainingLabel3.Name = "treadRemainingLabel3";
            treadRemainingLabel3.Size = new System.Drawing.Size(94, 13);
            treadRemainingLabel3.TabIndex = 35;
            treadRemainingLabel3.Text = "Tread Remaining:";
            treadRemainingLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treadRemainingTextBox3
            // 
            this.treadRemainingTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modifiedSetup_SetupTiresBindingSource, "RightRear.TreadRemaining", true));
            this.treadRemainingTextBox3.Location = new System.Drawing.Point(229, 262);
            this.treadRemainingTextBox3.Name = "treadRemainingTextBox3";
            this.treadRemainingTextBox3.Size = new System.Drawing.Size(100, 20);
            this.treadRemainingTextBox3.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tires";
            // 
            // SetuTireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(coldPressureLabel3);
            this.Controls.Add(this.coldPressureTextBox3);
            this.Controls.Add(lastHotPressureLabel3);
            this.Controls.Add(this.lastHotPressureTextBox3);
            this.Controls.Add(lastTempsIMOLabel1);
            this.Controls.Add(this.lastTempsIMOTextBox1);
            this.Controls.Add(staggerLabel1);
            this.Controls.Add(this.staggerTextBox1);
            this.Controls.Add(treadRemainingLabel3);
            this.Controls.Add(this.treadRemainingTextBox3);
            this.Controls.Add(coldPressureLabel2);
            this.Controls.Add(this.coldPressureTextBox2);
            this.Controls.Add(lastHotPressureLabel2);
            this.Controls.Add(this.lastHotPressureTextBox2);
            this.Controls.Add(lastTempsIMOLabel);
            this.Controls.Add(this.lastTempsIMOTextBox);
            this.Controls.Add(staggerLabel);
            this.Controls.Add(this.staggerTextBox);
            this.Controls.Add(treadRemainingLabel2);
            this.Controls.Add(this.treadRemainingTextBox2);
            this.Controls.Add(this.coldPressureTextBox1);
            this.Controls.Add(this.lastHotPressureTextBox1);
            this.Controls.Add(this.lastTempsOMITextBox1);
            this.Controls.Add(this.treadRemainingTextBox1);
            this.Controls.Add(this.coldPressureTextBox);
            this.Controls.Add(this.lastHotPressureTextBox);
            this.Controls.Add(this.lastTempsOMITextBox);
            this.Controls.Add(this.treadRemainingTextBox);
            this.Name = "SetuTireView";
            this.Size = new System.Drawing.Size(351, 322);
            ((System.ComponentModel.ISupportInitialize)(this.modifiedSetup_SetupTiresBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource modifiedSetup_SetupTiresBindingSource;
        private System.Windows.Forms.TextBox coldPressureTextBox;
        private System.Windows.Forms.TextBox lastHotPressureTextBox;
        private System.Windows.Forms.TextBox lastTempsOMITextBox;
        private System.Windows.Forms.TextBox treadRemainingTextBox;
        private System.Windows.Forms.TextBox coldPressureTextBox1;
        private System.Windows.Forms.TextBox lastHotPressureTextBox1;
        private System.Windows.Forms.TextBox lastTempsOMITextBox1;
        private System.Windows.Forms.TextBox treadRemainingTextBox1;
        private System.Windows.Forms.TextBox coldPressureTextBox2;
        private System.Windows.Forms.TextBox lastHotPressureTextBox2;
        private System.Windows.Forms.TextBox lastTempsIMOTextBox;
        private System.Windows.Forms.TextBox staggerTextBox;
        private System.Windows.Forms.TextBox treadRemainingTextBox2;
        private System.Windows.Forms.TextBox coldPressureTextBox3;
        private System.Windows.Forms.TextBox lastHotPressureTextBox3;
        private System.Windows.Forms.TextBox lastTempsIMOTextBox1;
        private System.Windows.Forms.TextBox staggerTextBox1;
        private System.Windows.Forms.TextBox treadRemainingTextBox3;
        private System.Windows.Forms.Label label1;
    }
}
