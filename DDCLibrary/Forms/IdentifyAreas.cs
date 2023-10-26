using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms; //using algorith class library to generate call numbers

namespace DDCLibrary
{
    public partial class IdentifyAreas : Form
    {

        private Dictionary<string, string> deweyData; //creating a dictionary to store data
        private int failedAttempts = 0; //global variable to keep track of a user's failed attempts in the game
        private Button prevClickedButton; //instance of Butttons class that will keep track of clicked buttons
       

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifyAreas()
        {
            InitializeComponent();
            // Enabling buffering to stop image flickering
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            PopulateDictionary(); //populating the dictionary 
            InitializeButtonsFormat1(); //inititalising the data in the buttons
            AttachButtonClickHandlers(); //attaching click event listeners to the buttons

            
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Methos that populates dictionary but data will be displayed randomly on screen
        /// </summary>
        public void PopulateDictionary()
        {
            deweyData = new Dictionary<string, string>();
            deweyData.Add("000.27 HFG", "General Knowledge");
            deweyData.Add("100.37 GSD", "Philosophy+psychology");
            deweyData.Add("200.88 SAY", "religion");
            deweyData.Add("300.34 WEF", "social sciences");
            deweyData.Add("400.23 ERF", "languages");
            deweyData.Add("500.45 RGE", "science");
            deweyData.Add("600.32 RFG", "technology");

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method that populated buttons values
        /// </summary>
        private void InitializeButtonsFormat1()
        {
            lblReset.Visible = true;
        
        //making sure feature is set back to zero should method be called again
            failedAttempts = 0; 
            lifeIcon1.Visible = true;
            lifeIcon2.Visible = true;
            lifeIcon3.Visible = true;

            //setting the lcolumn lables
            lblCol1.Text = "CALL NUMBERS";
            lblCol2.Text = "IDENTIFICATIONS";

            //adding dewey data to string lists to make it easier to manipulate
            List<string> callNumbers = deweyData.Keys.ToList();
            List<string> identifications = deweyData.Values.ToList();
            Random random = new Random();

            // Making these buttons invisible as they will only be used when identifications are compared to call numbers
            btnCol2.Visible = false;
            btnCol3.Visible = false;
            btnCol8.Visible = false;
            btnCol9.Visible = false;
            btnCol10.Visible = false;
            btnCol22.Visible = false; //column 2
            btnCol100.Visible = false;//column 2

            //adding buttons to buttons list
            List<Button> buttons = new List<Button> { btnCol4, btnCol5, btnCol6, btnCol7 }; 
            List<Button> buttons1 = new List<Button> { btnCol33, btnCol44, btnCol55, btnCol66, btnCol77, btnCol88, btnCol99 };

            // Revert the original button colors
            foreach (Button button in buttons)
            {
                button.BackColor = SystemColors.Control; // Set the background color to the default control color
            }

            foreach (Button button in buttons1)
            {
                button.BackColor = SystemColors.Control; // Set the background color to the default control color
            }

            foreach (Button button in buttons)
            {
                if (callNumbers.Count > 0)
                {
                    int randomIndex = random.Next(callNumbers.Count);
                    string randomCallNumber = callNumbers[randomIndex];
                    button.Text = randomCallNumber;
                    callNumbers.RemoveAt(randomIndex); // Avoid duplicate call numbers
                }
                else
                {
                    // Handle the case where there are not enough call numbers
                    button.Text = "No Data";
                }
            }

            // Populate buttons1 with identifications
            foreach (Button button in buttons1)
            {
                if (identifications.Count > 0)
                {
                    int randomIndex = random.Next(identifications.Count);
                    string randomIdentification = identifications[randomIndex];
                    button.Text = randomIdentification;
                    identifications.RemoveAt(randomIndex); // Avoid duplicate identifications
                }
                else
                {
                    // Handle the case where there are not enough identifications
                    button.Text = "No Data";
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// If user clicks to return
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRtrn2_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Home form2 = new Home();
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Attaching event handlers to buttons
        /// </summary>
        private void AttachButtonClickHandlers()
        {
            // Attach a common event handler to all buttons for processing clicks
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Click += Button_Click;

                    // Add a debugging statement to check if the event handler is attached
                    Debug.WriteLine($"Button with text '{button.Text}' has the event handler attached.");
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Blue; //change colour of clicked button to show its clicked
            if (prevClickedButton == null) //checking if prev selected button is null
            {
                // First button in the sequence
                prevClickedButton = clickedButton;
            }
            else
            {
                if (IsFormat2Active()) //checks if user if user selected to switch formats -they will be askedd to match identifications to call numbers
                {
                    string callNumber1 = clickedButton.Text;
                    string identification2 = prevClickedButton.Text;

                    if (deweyData.ContainsKey(callNumber1) && deweyData[callNumber1] == identification2)
                    {
                        MessageBox.Show("Correct Match");
                        prevClickedButton.BackColor = Color.Green;
                        clickedButton.BackColor = Color.Green;
                    }
                    else
                    {
                        prevClickedButton.BackColor = Color.White;
                        clickedButton.BackColor = Color.White;
                        FailedAttempts();

                    }
                    prevClickedButton = null; //setting bbuttons to null values
                }
                else //regulary format of checking call numbers to identifications
                {
                    string callNumber = prevClickedButton.Text;
                    string identification = clickedButton.Text;

                    if (deweyData.ContainsKey(callNumber) && deweyData[callNumber] == identification)
                    {
                        MessageBox.Show("Correct Match");
                        prevClickedButton.BackColor = Color.Green;
                        clickedButton.BackColor = Color.Green;
                    }
                    else
                    {
                        prevClickedButton.BackColor = Color.White;
                        clickedButton.BackColor = Color.White;
                        FailedAttempts();
                    }

                    prevClickedButton = null; // Reset the previous clicked button
                    
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Setting up second format of checking identifications to call numbers
        /// </summary>
        public void SecondFormat()
        {
            //Setting gamification feature to ensure all setting are reverted to original
            failedAttempts = 0;
            lifeIcon1.Visible = true;
            lifeIcon2.Visible = true;
            lifeIcon3.Visible = true;

            lblCol1.Text = "IDENTIFICATIONS"; //changing the lable from call number
            lblCol2.Text = "CALL NUMBERS"; //changing the lable from identifications

            List<string> callNumbers = deweyData.Keys.ToList(); //adding dewey data to string list
            List<string> identifications = deweyData.Values.ToList(); //adding dewey data to string list
            Random random = new Random(); //Random class that will help with randomly displaying data

            //Buttons lists of type buttons to store possible clicked buttons
            List<Button> buttons = new List<Button> { btnCol4, btnCol5, btnCol6, btnCol7};
            List<Button> buttons1 = new List<Button> { btnCol33, btnCol44, btnCol55, btnCol66, btnCol77, btnCol88, btnCol99 };

            // Revert the original button colors
            foreach (Button button in buttons)
            {
                button.BackColor = SystemColors.Control; // Set the background color to the default control color
            }

            foreach (Button button in buttons1)
            {
                button.BackColor = SystemColors.Control; // Set the background color to the default control color
            }


           //randomly assigning data in dictionary to button texts
            foreach (Button button in buttons1)
            {
                if (callNumbers.Count > 0)
                {
                    int randomIndex = random.Next(callNumbers.Count);
                    string randomCallNumber = callNumbers[randomIndex];
                    button.Text = randomCallNumber;
                    callNumbers.RemoveAt(randomIndex); // Avoid duplicate call numbers
                }
                else
                {
                    // Handle the case where there are not enough call numbers
                    button.Text = "No Data";
                }
            }

            // Populate buttons1 with identifications
            foreach (Button button in buttons)
            {
                if (identifications.Count > 0)
                {
                    int randomIndex = random.Next(identifications.Count);
                    string randomIdentification = identifications[randomIndex];
                    button.Text = randomIdentification;
                    identifications.RemoveAt(randomIndex); // Avoid duplicate identifications
                }
                else
                {
                    // Handle the case where there are not enough identifications
                    button.Text = "No Data";
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Checking to see if form 2 is active
        /// </summary>
        /// <returns></returns>
        private bool IsFormat2Active()
        {
            // Define the condition for Format2 to be active (e.g., based on button visibility, etc.)
            return btnCol3.Visible;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// refersh button will start a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbRefresh_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Home form2 = new Home();
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// shut down the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbShutDon_Click(object sender, EventArgs e)
        {
            DialogResult promptShutDown = MessageBox.Show("shutting down...", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if (promptShutDown == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// reset button will switch formats from comparing call numbers to identifications vice versa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblReset_Click(object sender, EventArgs e)
        {
            SecondFormat();
            lblReset.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// initilising buttons for new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNewGame_Click(object sender, EventArgs e)
        {
            
            InitializeButtonsFormat1();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// if user selets help button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblHelp_Click(object sender, EventArgs e)
        {
            HelpData();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// method to store help data
        /// </summary>

        public void HelpData()
        {
            pbHelp.Visible = true;
            DialogResult getHelp = MessageBox.Show("Follow the call numbers on the image to determine which call number and decription are a match " +
                "\n NB! The first three numbers in the call numbers are important!", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (getHelp == DialogResult.OK)
            {
                pbHelp.Visible = false;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gamification feature where users have 3 lives/opportunities to get the answer right otherwise they 'die' and are forced to start a new game
        /// </summary>
        public void FailedAttempts()
        {
            failedAttempts++; //Accumulating the failed attempts

            if (failedAttempts == 1)
            {
                // If unsuccessfully sorted on the first attempt
                MessageBox.Show("wrong match :( Only two lives left!", "oh no...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lifeIcon1.Visible = false;
            }
            else if (failedAttempts == 2)
            {
                // If unsuccessfully sorted on the second attempt, hide lifeIcon2
                MessageBox.Show("You missed again! Only one life left!", "oh no...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lifeIcon2.Visible = false;
            }
            else if (failedAttempts >= 3)
            {
                // If unsuccessfully sorted on the third or more attempts, hide lifeIcon3 and handle game over logic
                MessageBox.Show("Game Over!", "oh no...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lifeIcon3.Visible = false;

                DialogResult result = MessageBox.Show("Start a new game?", "DDL", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    InitializeButtonsFormat1();
                }

                else
                {
                    // Create an instance of Form2
                    Home form2 = new Home();
                    // Show Form2 and hide Form1
                    form2.Show();
                    this.Hide();
                }
                
            }

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
//----------------------------------------------------------------------------------ooo000EndOfFile000ooo--------------------------------------------------------------------------------------------



/*
 * STUFF
 * // private Algorithm al = new Algorithm();
       // private LinkedList<int> randomGenNmbrs = new LinkedList<int>(); //Linked list to store random generated numbers from worker class
       // private LinkedList<string> randonGenLetters = new LinkedList<string>(); //Linked list to store random generated letters
       // private LinkedList<string> identificatorForCallNmbrs = new LinkedList<string>(); //Linked list to store random generated letters

//Using class library 'Algorithms' to nitilising the random gen numbers and letters so they load as soon as the form is up
            // randomGenNmbrs = al.GenerateCallNumbers(7);
            // randonGenLetters = al.GenerateRandomLetterSets(7, 3); 
 * //public void PopulateDictionary()
        //{
        //    deweyData = new Dictionary<string, string>();

        //    if (randomGenNmbrs.Count == randonGenLetters.Count)
        //    {
        //        LinkedListNode<int> numberNode = randomGenNmbrs.First;
        //        LinkedListNode<string> letterNode = randonGenLetters.First;

        //        while (numberNode != null && letterNode != null)
        //        {
        //            string key = numberNode.Value.ToString() +"."+ letterNode.Value;
        //            string value = "Value" + key; // Set the corresponding value as needed

        //            deweyData.Add(key, value);

        //            numberNode = numberNode.Next;
        //            letterNode = letterNode.Next;
        //        }
        //    }
        //    else
        //    {
        //        // Handle the case where the two linked lists have different counts
        //    }
        //}
*/