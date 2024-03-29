namespace Mhrs_Otomasyonu
{
    partial class Form19
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form19));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(512, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Summertime Sadness";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(512, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Forth-Of-July";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RosyBrown;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(512, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Sweater-Weather";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.RosyBrown;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(512, 170);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(198, 40);
            this.button4.TabIndex = 6;
            this.button4.Text = "Another Love";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.RosyBrown;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(512, 134);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(198, 40);
            this.button5.TabIndex = 5;
            this.button5.Text = "Yes To Heaven";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(329, 213);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 288);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form19";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radyo";
//            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form19_FormClosing);
            this.Load += new System.EventHandler(this.Form19_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}