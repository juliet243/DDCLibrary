namespace DDCLibrary
{
    partial class StartPrompt
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
            this.tmr2 = new System.Windows.Forms.Timer(this.components);
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.btnRtrn = new System.Windows.Forms.Button();
            this.btnShutDown3 = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmr2
            // 
            this.tmr2.Enabled = true;
            this.tmr2.Interval = 1000;
            this.tmr2.Tick += new System.EventHandler(this.tmr2_Tick);
            // 
            // picBox2
            // 
            this.picBox2.Image = global::DDCLibrary.Properties.Resources.picGirlReadd2;
            this.picBox2.Location = new System.Drawing.Point(0, 0);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(728, 694);
            this.picBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox2.TabIndex = 1;
            this.picBox2.TabStop = false;
            // 
            // picBox1
            // 
            this.picBox1.Image = global::DDCLibrary.Properties.Resources.picGirlReadd;
            this.picBox1.Location = new System.Drawing.Point(0, 0);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(728, 694);
            this.picBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox1.TabIndex = 0;
            this.picBox1.TabStop = false;
            // 
            // btnRtrn
            // 
            this.btnRtrn.BackColor = System.Drawing.Color.Transparent;
            this.btnRtrn.BackgroundImage = global::DDCLibrary.Properties.Resources._786399__1_1;
            this.btnRtrn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRtrn.FlatAppearance.BorderSize = 0;
            this.btnRtrn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRtrn.Location = new System.Drawing.Point(25, 12);
            this.btnRtrn.Name = "btnRtrn";
            this.btnRtrn.Size = new System.Drawing.Size(75, 69);
            this.btnRtrn.TabIndex = 70;
            this.btnRtrn.UseVisualStyleBackColor = false;
            this.btnRtrn.Click += new System.EventHandler(this.btnRtrn_Click);
            // 
            // btnShutDown3
            // 
            this.btnShutDown3.BackColor = System.Drawing.Color.Transparent;
            this.btnShutDown3.BackgroundImage = global::DDCLibrary.Properties.Resources.shutdown;
            this.btnShutDown3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShutDown3.FlatAppearance.BorderSize = 0;
            this.btnShutDown3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutDown3.Location = new System.Drawing.Point(618, 12);
            this.btnShutDown3.Name = "btnShutDown3";
            this.btnShutDown3.Size = new System.Drawing.Size(75, 69);
            this.btnShutDown3.TabIndex = 71;
            this.btnShutDown3.UseVisualStyleBackColor = false;
            this.btnShutDown3.Click += new System.EventHandler(this.btnShutDown3_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.IndianRed;
            this.btnPlay.BackgroundImage = global::DDCLibrary.Properties.Resources.playicon;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.Location = new System.Drawing.Point(288, 293);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(150, 59);
            this.btnPlay.TabIndex = 72;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // StartPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DDCLibrary.Properties.Resources.picGirlReadd;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(728, 694);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnShutDown3);
            this.Controls.Add(this.btnRtrn);
            this.Controls.Add(this.picBox2);
            this.Controls.Add(this.picBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "StartPrompt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dewey Decimal Library";
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmr2;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.Button btnRtrn;
        private System.Windows.Forms.Button btnShutDown3;
        private System.Windows.Forms.Button btnPlay;
    }
}