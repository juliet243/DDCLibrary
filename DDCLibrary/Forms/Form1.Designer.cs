namespace DDCLibrary
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.progresBar = new CircularProgressBar.CircularProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblGameNm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnShutDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progresBar
            // 
            this.progresBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progresBar.AnimationSpeed = 500;
            this.progresBar.BackColor = System.Drawing.Color.Transparent;
            this.progresBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progresBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.progresBar.InnerColor = System.Drawing.Color.Transparent;
            this.progresBar.InnerMargin = 2;
            this.progresBar.InnerWidth = -1;
            this.progresBar.Location = new System.Drawing.Point(289, 258);
            this.progresBar.MarqueeAnimationSpeed = 2000;
            this.progresBar.Name = "progresBar";
            this.progresBar.OuterColor = System.Drawing.Color.Gray;
            this.progresBar.OuterMargin = -20;
            this.progresBar.OuterWidth = 20;
            this.progresBar.ProgressColor = System.Drawing.Color.Blue;
            this.progresBar.ProgressWidth = 10;
            this.progresBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.progresBar.Size = new System.Drawing.Size(160, 155);
            this.progresBar.StartAngle = 270;
            this.progresBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progresBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progresBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.progresBar.SubscriptText = "";
            this.progresBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progresBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.progresBar.SuperscriptText = "";
            this.progresBar.TabIndex = 0;
            this.progresBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.progresBar.Value = 68;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 101;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblGameNm
            // 
            this.lblGameNm.AutoSize = true;
            this.lblGameNm.BackColor = System.Drawing.Color.Transparent;
            this.lblGameNm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblGameNm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameNm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGameNm.Location = new System.Drawing.Point(327, 426);
            this.lblGameNm.Name = "lblGameNm";
            this.lblGameNm.Size = new System.Drawing.Size(86, 37);
            this.lblGameNm.TabIndex = 4;
            this.lblGameNm.Text = "DDS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(265, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dewey Decimal System";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWelcome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWelcome.Location = new System.Drawing.Point(300, 561);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 37);
            this.lblWelcome.TabIndex = 6;
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnShutDown
            // 
            this.btnShutDown.BackColor = System.Drawing.Color.Transparent;
            this.btnShutDown.BackgroundImage = global::DDCLibrary.Properties.Resources.shutdown;
            this.btnShutDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShutDown.FlatAppearance.BorderSize = 0;
            this.btnShutDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutDown.Location = new System.Drawing.Point(630, 12);
            this.btnShutDown.Name = "btnShutDown";
            this.btnShutDown.Size = new System.Drawing.Size(75, 69);
            this.btnShutDown.TabIndex = 83;
            this.btnShutDown.UseVisualStyleBackColor = false;
            this.btnShutDown.Click += new System.EventHandler(this.btnShutDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::DDCLibrary.Properties.Resources.chairwall;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(728, 694);
            this.Controls.Add(this.btnShutDown);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGameNm);
            this.Controls.Add(this.progresBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dewey Decimal Library";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar progresBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblGameNm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnShutDown;
    }
}

