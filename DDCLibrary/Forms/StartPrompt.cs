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
    public partial class StartPrompt : Form
    {
        private LinkedList<PictureBox> pictureBoxes; // Linked list to store picture boxes
        private LinkedListNode<PictureBox> currentPictureBoxNode; // Node pointing to the currently visible picture box
        private Timer timer; // Timer for controlling the picture change interval

        public List<string> checkForScreen;

        public StartPrompt()
        {
            InitializeComponent();
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        public StartPrompt(List<string> checkForScreen)
        {
            InitializeComponent();

            //
            this.checkForScreen = checkForScreen;

            // Enablling buffering to stop image flickering
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Create a linked list of picture boxes
            pictureBoxes = new LinkedList<PictureBox>();
            pictureBoxes.AddLast(picBox1);
            pictureBoxes.AddLast(picBox2);

            // Initialize the timer
            timer = new Timer();
            timer.Interval = 800; // 0.8-second interval
            timer.Tick += tmr2_Tick;
            timer.Start();

            // Start with the first picture box
            currentPictureBoxNode = pictureBoxes.First;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer method to track the sconds in which picture box images will be displayed on the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr2_Tick(object sender, EventArgs e)
        {
            // Ensure pictureBoxes is not null before using it
            if (pictureBoxes != null)
            {
                // Hide all picture boxes
                foreach (var pictureBox in pictureBoxes)
                {
                    pictureBox.Visible = false;
                }

                // Show the picture box pointed to by currentPictureBoxNode
                currentPictureBoxNode.Value.Visible = true;

                // Move to the next picture box node and loop back to the first if necessary
                currentPictureBoxNode = currentPictureBoxNode.Next ?? pictureBoxes.First;
            }
            else
            {
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// button to shut down app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShutDown3_Click(object sender, EventArgs e)
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
        /// button to take user to previous screen after they select retrun button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRtrn_Click(object sender, EventArgs e)
        {
            // Create an instance of Home form
            Home form2 = new Home();
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to take user to game form after user clicks play button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (checkForScreen[0].Equals("IdentifyAreas"))
            {
                // Create an instance of Form2
                IdentifyAreas form2 = new IdentifyAreas();
                // Show Form2 and hide Form1
                this.Hide();
                form2.Show();
                this.Hide();
            }
            else if (checkForScreen[0].Equals("ReplaceBooks"))
            {
                // Create an instance of Form2
                ReplacBooks form2 = new ReplacBooks();
                // Show Form2 and hide Form1
                this.Hide();
                form2.Show();
                this.Hide();
            }
            else if (checkForScreen[0].Equals("FindCallNumbers"))
            {
                // Create an instance of Form2
                FindCallNumbers form2 = new FindCallNumbers();
                // Show Form2 and hide Form1
                this.Hide();
                form2.Show();
                this.Hide();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
//-------------------------------------------------------------------------------------ooo000EndOfFile000ooo-----------------------------------------------------------------------------------------