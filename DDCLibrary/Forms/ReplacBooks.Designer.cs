namespace DDCLibrary
{
    partial class ReplacBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplacBooks));
            this.replaceBooksUC1 = new DDCLibrary.ReplaceBooksUC();
            this.lblCountDown = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // replaceBooksUC1
            // 
            this.replaceBooksUC1.BackColor = System.Drawing.Color.Transparent;
            this.replaceBooksUC1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("replaceBooksUC1.BackgroundImage")));
            this.replaceBooksUC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.replaceBooksUC1.Location = new System.Drawing.Point(0, 0);
            this.replaceBooksUC1.Name = "replaceBooksUC1";
            this.replaceBooksUC1.Size = new System.Drawing.Size(728, 694);
            this.replaceBooksUC1.TabIndex = 0;
            // 
            // lblCountDown
            // 
            this.lblCountDown.BackColor = System.Drawing.Color.Transparent;
            this.lblCountDown.BackgroundImage = global::DDCLibrary.Properties.Resources.chairwall;
            this.lblCountDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblCountDown.Font = new System.Drawing.Font("Goudy Old Style", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(0, 0);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(728, 694);
            this.lblCountDown.TabIndex = 1;
            this.lblCountDown.Text = "button1";
            this.lblCountDown.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ReplacBooks
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(728, 694);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.replaceBooksUC1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ReplacBooks";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace Books";
            this.Load += new System.EventHandler(this.ReplacBooks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ReplaceBooksUC replaceBooksUC1;
        private System.Windows.Forms.Button lblCountDown;
        private System.Windows.Forms.Timer timer1;
    }
}