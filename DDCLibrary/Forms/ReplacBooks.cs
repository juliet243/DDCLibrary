using System;
using System.Drawing;
using System.Windows.Forms;

namespace DDCLibrary
{
    public partial class ReplacBooks : Form
    {
        private int secondsToStart = 5; 

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public ReplacBooks()
        {
            InitializeComponent();
            // Enabling buffering to stop image flickering
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplacBooks_Load(object sender, EventArgs e)
        {
            // Start the timer when the form loads or at the appropriate trigger point
            timer1.Start();
            lblCountDown.Text = secondsToStart.ToString(); // Initial display

            lblCountDown.Visible = true; // Update the label
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to count down seconds to start
        /// https://www.youtube.com/watch?v=YX3zXHhzg4g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (secondsToStart > 0)
            {
                secondsToStart--; // Decrement the countdown

                lblCountDown.Text = secondsToStart.ToString(); // Update the label
            }


            if (secondsToStart == 0)
            {
                // Countdown has reached 0, so stop the timer or perform your desired action

                timer1.Stop();
                //lblCountDown.Text = "";
                lblCountDown.Visible = false; // Update the label

               // EnableBookMovement(); //Enabling the buttons to be draggable
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}

//------------------------------------------------------------------------------------ooo000EndOfFile000ooo------------------------------------------------------------------------------------------