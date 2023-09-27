using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDCLibrary
{
    public partial class Form1 : Form
    {

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //Initialising the progressbar
            progresBar.Value = 0;

            // Enablling buffering to stop image flickering
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer ticker method that track time and will display lable welcome after 60 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            progresBar.Value += 1;
            progresBar.Text = progresBar.Value.ToString() + "%";

            if (progresBar.Value.Equals(60))
            {
                lblWelcome.Text = "welcome";
            }

            if (progresBar.Value.Equals(100))
            {
                timer1.Enabled = false;

                // Create an instance of Form2
                Home form2 = new Home();
                // Show Form2 and hide Form1
                form2.Show();
                this.Hide();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Shut down button event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShutDown_Click(object sender, EventArgs e)
        {
            DialogResult promptShutDown = MessageBox.Show("shutting down...", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if (promptShutDown == DialogResult.OK)
            {
                //Environment.Exit(1);
                this.Close();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
//-----------------------------------------------------------------------------------ooo000EndOfFile000ooo-------------------------------------------------------------------------------------------