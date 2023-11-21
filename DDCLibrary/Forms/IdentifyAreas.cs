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
                    var randomIndex = random.Next(callNumbers.Count);
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
                    var randomIndex = random.Next(identifications.Count);
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
            clickedButton.BackColor = Color.Blue;

            if (prevClickedButton == null)
            {
                // First button in the sequence
                prevClickedButton = clickedButton;
                return;
            }

            if (IsFormat2Active())
            {
                HandleFormat2Click(clickedButton);
            }
            else
            {
                HandleRegularClick(clickedButton);
            }

            prevClickedButton = null; // Reset the previous clicked button
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clickedButton"></param>
        private void HandleFormat2Click(Button clickedButton)
        {
            string callNumber1 = clickedButton.Text;
            string identification2 = prevClickedButton.Text;

            bool matchFound = deweyData.Any(pair => pair.Value == identification2 && pair.Key == callNumber1);

            if (matchFound)
            {
                MessageBox.Show("Correct Match");
                SetButtonColors(prevClickedButton, clickedButton, Color.Green);
            }
            else
            {
                SetButtonColors(prevClickedButton, clickedButton, Color.White);
                FailedAttempts();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clickedButton"></param>
        private void HandleRegularClick(Button clickedButton)
        {
            string callNumber = prevClickedButton.Text;
            string identification = clickedButton.Text;

            bool matchFound = deweyData.ContainsKey(callNumber) && deweyData[callNumber] == identification;

            if (matchFound)
            {
                MessageBox.Show("Correct Match");
                SetButtonColors(prevClickedButton, clickedButton, Color.Green);
            }
            else
            {
                SetButtonColors(prevClickedButton, clickedButton, Color.White);
                FailedAttempts();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="button1"></param>
        /// <param name="button2"></param>
        /// <param name="color"></param>
        private void SetButtonColors(Button button1, Button button2, Color color)
        {
            button1.BackColor = color;
            button2.BackColor = color;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Setting up second format of checking identifications to call numbers
        /// </summary>
        public void SecondFormat()
        {
            //btnCol3.Visible = true;
            //Setting gamification feature to ensure all settings are reverted to the original
            ResetGameSettings();

            lblCol1.Text = "IDENTIFICATIONS"; //changing the label from call number
            lblCol2.Text = "CALL NUMBERS"; //changing the label from identifications

            List<string> callNumbers = deweyData.Keys.ToList();
            List<string> identifications = deweyData.Values.ToList();
            Random random = new Random();

            List<Button> buttons = new List<Button> { btnCol4, btnCol5, btnCol6, btnCol7 };
            List<Button> buttons1 = new List<Button> { btnCol33, btnCol44, btnCol55, btnCol66, btnCol77, btnCol88, btnCol99 };

            ResetButtonColors(buttons);
            ResetButtonColors(buttons1);

            AssignRandomDataToButtons(buttons1, callNumbers, random, "No Data");
            AssignRandomDataToButtons(buttons, identifications, random, "No Data");
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Life Icon data
        /// </summary>
        private void ResetGameSettings()
        {
            failedAttempts = 0;
            lifeIcon1.Visible = true;
            lifeIcon2.Visible = true;
            lifeIcon3.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Resetting the button colors
        /// </summary>
        /// <param name="buttons"></param>
        private void ResetButtonColors(List<Button> buttons)
        {
            buttons.ForEach(button => button.BackColor = SystemColors.Control);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Assigning data to buttons
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="data"></param>
        /// <param name="random"></param>
        /// <param name="noDataValue"></param>
        private void AssignRandomDataToButtons(List<Button> buttons, List<string> data, Random random, string noDataValue)
        {
            buttons.ForEach(button =>
            {
                if (data.Count > 0)
                {
                    int randomIndex = random.Next(data.Count);
                    string randomValue = data[randomIndex];
                    button.Text = randomValue;
                    data.RemoveAt(randomIndex);
                }
                else
                {
                    button.Text = noDataValue;
                }
            });
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Checking to see if form 2 is active
        /// </summary>
        /// <returns></returns>
        private bool IsFormat2Active()
        {
          //  btnCol3.Visible = false;
            // Define the condition for Format2 to be active (e.g., based on button visibility, etc.)
            return lblCol1.Text =="IDENTIFICATIONS";
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
           // btnCol3.Visible = true;
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