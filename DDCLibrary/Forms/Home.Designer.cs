namespace DDCLibrary
{
    partial class Home
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
            this.btnReplacBks = new System.Windows.Forms.Button();
            this.lblGameNm = new System.Windows.Forms.Label();
            this.btnIdnftyArs = new System.Windows.Forms.Button();
            this.btnFndCalNmbrs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrHome = new System.Windows.Forms.Timer(this.components);
            this.btnShutDown = new System.Windows.Forms.Button();
            this.btnRewards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReplacBks
            // 
            this.btnReplacBks.BackgroundImage = global::DDCLibrary.Properties.Resources.personreading;
            this.btnReplacBks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReplacBks.Enabled = false;
            this.btnReplacBks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReplacBks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplacBks.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReplacBks.Location = new System.Drawing.Point(50, 298);
            this.btnReplacBks.Name = "btnReplacBks";
            this.btnReplacBks.Size = new System.Drawing.Size(184, 236);
            this.btnReplacBks.TabIndex = 0;
            this.btnReplacBks.Text = "Level 1 ";
            this.btnReplacBks.UseVisualStyleBackColor = true;
            this.btnReplacBks.Visible = false;
            this.btnReplacBks.Click += new System.EventHandler(this.btnReplacBks_Click);
            // 
            // lblGameNm
            // 
            this.lblGameNm.AutoSize = true;
            this.lblGameNm.BackColor = System.Drawing.Color.Transparent;
            this.lblGameNm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblGameNm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameNm.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblGameNm.Location = new System.Drawing.Point(151, 233);
            this.lblGameNm.Name = "lblGameNm";
            this.lblGameNm.Size = new System.Drawing.Size(438, 37);
            this.lblGameNm.TabIndex = 3;
            this.lblGameNm.Text = "DEWEY DECIMAL LIBRARY";
            // 
            // btnIdnftyArs
            // 
            this.btnIdnftyArs.BackgroundImage = global::DDCLibrary.Properties.Resources.personreading;
            this.btnIdnftyArs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIdnftyArs.Enabled = false;
            this.btnIdnftyArs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIdnftyArs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdnftyArs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIdnftyArs.Location = new System.Drawing.Point(283, 298);
            this.btnIdnftyArs.Name = "btnIdnftyArs";
            this.btnIdnftyArs.Size = new System.Drawing.Size(184, 236);
            this.btnIdnftyArs.TabIndex = 4;
            this.btnIdnftyArs.Text = "Level 2";
            this.btnIdnftyArs.UseVisualStyleBackColor = true;
            this.btnIdnftyArs.Visible = false;
            this.btnIdnftyArs.Click += new System.EventHandler(this.btnIdnftyArs_Click);
            // 
            // btnFndCalNmbrs
            // 
            this.btnFndCalNmbrs.BackgroundImage = global::DDCLibrary.Properties.Resources.personreadingbw1;
            this.btnFndCalNmbrs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFndCalNmbrs.Enabled = false;
            this.btnFndCalNmbrs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFndCalNmbrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFndCalNmbrs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFndCalNmbrs.Location = new System.Drawing.Point(497, 298);
            this.btnFndCalNmbrs.Name = "btnFndCalNmbrs";
            this.btnFndCalNmbrs.Size = new System.Drawing.Size(184, 236);
            this.btnFndCalNmbrs.TabIndex = 5;
            this.btnFndCalNmbrs.Text = "Level 3";
            this.btnFndCalNmbrs.UseVisualStyleBackColor = true;
            this.btnFndCalNmbrs.Visible = false;
            this.btnFndCalNmbrs.Click += new System.EventHandler(this.btnFndCalNmbrs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Replace Books";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Identify Areas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(489, 534);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Find Call Numbers";
            // 
            // tmrHome
            // 
            this.tmrHome.Enabled = true;
            this.tmrHome.Tick += new System.EventHandler(this.tmrHome_Tick);
            // 
            // btnShutDown
            // 
            this.btnShutDown.BackColor = System.Drawing.Color.Transparent;
            this.btnShutDown.BackgroundImage = global::DDCLibrary.Properties.Resources.shutdown;
            this.btnShutDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShutDown.FlatAppearance.BorderSize = 0;
            this.btnShutDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShutDown.Location = new System.Drawing.Point(631, 12);
            this.btnShutDown.Name = "btnShutDown";
            this.btnShutDown.Size = new System.Drawing.Size(75, 69);
            this.btnShutDown.TabIndex = 72;
            this.btnShutDown.UseVisualStyleBackColor = false;
            this.btnShutDown.Click += new System.EventHandler(this.btnShutDown_Click);
            // 
            // btnRewards
            // 
            this.btnRewards.BackColor = System.Drawing.Color.Transparent;
            this.btnRewards.BackgroundImage = global::DDCLibrary.Properties.Resources.badge__1_;
            this.btnRewards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRewards.FlatAppearance.BorderSize = 0;
            this.btnRewards.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRewards.Location = new System.Drawing.Point(533, 12);
            this.btnRewards.Name = "btnRewards";
            this.btnRewards.Size = new System.Drawing.Size(75, 69);
            this.btnRewards.TabIndex = 73;
            this.btnRewards.UseVisualStyleBackColor = false;
            this.btnRewards.Click += new System.EventHandler(this.btnRewards_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DDCLibrary.Properties.Resources.chairwall;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(728, 694);
            this.Controls.Add(this.btnRewards);
            this.Controls.Add(this.btnShutDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFndCalNmbrs);
            this.Controls.Add(this.btnIdnftyArs);
            this.Controls.Add(this.lblGameNm);
            this.Controls.Add(this.btnReplacBks);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dewey Decimal Library";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReplacBks;
        private System.Windows.Forms.Label lblGameNm;
        private System.Windows.Forms.Button btnIdnftyArs;
        private System.Windows.Forms.Button btnFndCalNmbrs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrHome;
        private System.Windows.Forms.Button btnShutDown;
        private System.Windows.Forms.Button btnRewards;
    }
}