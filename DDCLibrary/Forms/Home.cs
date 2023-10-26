using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DDCLibrary
{
    public partial class Home : Form
    {

        private int myVal = 0; //initialising global variable to be used to track ticker timer
        //setting enabled books to false
        private bool btnReplacBksEnabled = false; 
        private bool btnIdnftyArsEnabled = false;
        private bool btnFndCalNmbrsEnabled = false;

        public List<string> checkForScreen = new List<string>();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        public Home()
        {
            InitializeComponent();

            // Enabling buffering to stop image flickering
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Initialize the timer and start it
            tmrHome.Interval = 1000; // 1 second interval
            tmrHome.Tick += tmrHome_Tick;
            tmrHome.Start();

            // Disable the buttons initially
            btnReplacBks.Visible = false;
            btnIdnftyArs.Visible = false;
            btnFndCalNmbrs.Visible = false;

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Button that takes users to Identify books section of the application. Now set to active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIdnftyArs_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Level Locked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Create an instance of Form2
            //  int checkForScreen = 1;
            checkForScreen.Add("IdentifyAreas");
              StartPrompt form2 = new StartPrompt(checkForScreen);
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();



        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Button to take users to find call numbers section of the app. currently inactive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFndCalNmbrs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Level Locked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///  Button to take users to replace books section of the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplacBks_Click(object sender, EventArgs e)
        {
            checkForScreen.Add("ReplaceBooks");
            // Create an instance of Form2
            StartPrompt form2 = new StartPrompt(checkForScreen);
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer method that handles the displaying of the the button texts to make them appear slowly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrHome_Tick(object sender, EventArgs e)
        {
            myVal += 1;

            //If timer is 2 seconds buttin 1 will be visible on the form
            if (myVal == 2 && !btnReplacBksEnabled)
            {
                btnReplacBks.Visible = true;
            }

            //If timer is 4 seconds buttin 2 will be visible on the form
            if (myVal == 4 && !btnIdnftyArsEnabled)
            {
                btnIdnftyArs.Visible = true;
            }

            //If timer is 6 seconds buttin 3 will be visible on the form
            if (myVal == 6 && !btnFndCalNmbrsEnabled)
            {
                btnFndCalNmbrs.Visible = true;
            }

            //If timer is 8 seconds buttin 1 will be enabled on the form
            if (myVal == 8 && !btnReplacBksEnabled)
            {
                btnReplacBks.Enabled = true;
                btnReplacBksEnabled = true; // Set the flag to prevent enabling again
            }

            //If timer is 10 seconds buttin 2 will be enabled on the form
            if (myVal == 10 && !btnIdnftyArsEnabled)
            {
                btnIdnftyArs.Enabled = true;
                btnIdnftyArsEnabled = true; // Set the flag to prevent enabling again
            }

            //If timer is 12 seconds buttin 3 will be enabled on the form
            if (myVal == 12 && !btnFndCalNmbrsEnabled)
            {
                btnFndCalNmbrs.Enabled = true;
                btnFndCalNmbrsEnabled = true; // Set the flag to prevent enabling again

                // Stopping the timer
                tmrHome.Stop();
            }

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Methos to shut down the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShutDown_Click(object sender, EventArgs e)
        {
            DialogResult promptShutDown = MessageBox.Show("shutting down...", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if (promptShutDown == DialogResult.OK)
            {
                //Environment.Exit(0);
                this.Close();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to go to badges form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRewards_Click(object sender, EventArgs e)
        {
            // Create an instance of Badges
            Badges form2 = new Badges();
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
//-----------------------------------------------------------------------------------ooo000EndOfFile000ooo-------------------------------------------------------------------------------------------