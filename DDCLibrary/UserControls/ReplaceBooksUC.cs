using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms;

namespace DDCLibrary
{
    public partial class ReplaceBooksUC : UserControl
    {
        private WorkerClass worker = new WorkerClass(); //Creating an object of Worker Class
        private LinkedList<int> randomGenNmbrs = new LinkedList<int>(); //Linked list to store random generated numbers from worker class
        private int[] lives = new int[2]; //Array to track how many lives a user has whilst playing the game. Starts with 3 lives
        private LinkedList<string> randonGenLetters = new LinkedList<string>(); //Linked list to store random generated letters
        private LinkedList<string> callNumbers = new LinkedList<string>(); //Linked list to store combined random letters and numbers
        private int secondsToStart = 5; //global variable for seconds to start before game begins to use on timer
        private List<Button> booksToOrder = new List<Button>(); // List to help keep track of buttns when ordering them
        private Stopwatch stopwatch; //creating an object of stopwatch
        private Algorithm al = new Algorithm();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Default Constructor 
        /// </summary>
        //
        public ReplaceBooksUC()
        {
            InitializeComponent();

            // Enabling buffering to stop image flickering
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            //Using class library 'Algorithms' to nitilising the random gen numbers and letters so they load as soon as the form is up
            randomGenNmbrs = al.GenerateCallNumbers();
            randonGenLetters = al.GenerateRandomLetterSets(10, 3);


            //btnBk1.Text = "AB  C 814";
            AssignCallNumbers();

            //Adding button to list so we can check position
            AddButtonToList();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// //What will appear on the form as soon as it is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplaceBooksUC_Load(object sender, EventArgs e)
        {
            // Start the timer when the form loads or at the appropriate trigger point
            timer1.Start();

            stopwatch = new Stopwatch();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// What will appear on the form as soon as it is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShutDown4_Click(object sender, EventArgs e)
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
        /// Method that will take user out of the game to Home form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRtrn2_Click(object sender, EventArgs e)
        {
            DialogResult promptExit = MessageBox.Show("Exit Game", "DDL", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (promptExit == DialogResult.OK)
            {
                // Create an instance of startprompt form
                Home form2 = new Home();
                // Show Form2 and hide Form1
                form2.Show();
                this.Hide();
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
            }
            
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to assign call numers
        /// 
        /// 
        /// </summary>
        public void AssignCallNumbers()
        {
            int buttonIndex = 1;
            var numberEnumerator = randomGenNmbrs.GetEnumerator();
            var letterEnumerator = randonGenLetters.GetEnumerator();

            while (buttonIndex <= 10 && numberEnumerator.MoveNext() && letterEnumerator.MoveNext())
            {
                // Finding the button by its name (btnBk1, btnBk2, etc.)
                Button button = Controls.Find($"btnBk{buttonIndex}", true).FirstOrDefault() as Button;

                if (button != null)
                {
                    // Assign the integer value and letter from the linked lists to the button's Text
                    button.Text = letterEnumerator.Current + "." + numberEnumerator.Current.ToString();
                }

                buttonIndex++;
            }

            // Dispose of the enumerators to release resources
            numberEnumerator.Dispose();
            letterEnumerator.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Mehtod that will use bublle sort algorithm to order the books
        /// https://www.youtube.com/watch?v=Jdtq5uKz-w4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            DisableBookMovement();
            GrabBookCallNumber();

            // Bubblesort algorithm to check if the buttons have been sorted in ascending order
            Button temp;

            for (int i = 0; i <= booksToOrder.Count - 2; i++)
            {
                for (int j = 0; j <= booksToOrder.Count - 2; j++)
                {
                    CompareAndSwapButtons(j);
                }
            }

            // Call the sorting algorithm inside the worker class
            worker.SortUsingBubbleSort(booksToOrder, panel1, lifeIcon3, lifeIcon2, lifeIcon1);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Comparing and swapping buttons action
        /// </summary>
        /// <param name="j"></param>
        private void CompareAndSwapButtons(int j)
        {
            String t1 = booksToOrder[j].Text;
            String t2 = booksToOrder[j + 1].Text;

            int temp1 = Int32.Parse(t1.Substring(0, 3));
            int temp2 = Int32.Parse(t2.Substring(0, 3));

            if (temp1 > temp2)
            {
                SwapButtons(j);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Swap buttons action
        /// </summary>
        /// <param name="j"></param>
        private void SwapButtons(int j)
        {
            Button temp = booksToOrder[j + 1];
            booksToOrder[j + 1] = booksToOrder[j];
            booksToOrder[j] = temp;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to rmeove the letters from the button texts before the sorting algorithm checks if they have been ordered correctly
        /// </summary>
        public void GrabBookCallNumber()
        {
            for (int i = 1; i <= 10; i++)
            {
                Button button = Controls.Find($"btnBk{i}", true).FirstOrDefault() as Button;

                if (button != null)
                {
                    // Remove letters from the button's text
                    string buttonText = button.Text;
                    string numericText = new string(buttonText.Where(char.IsDigit).ToArray());
                    button.Text = numericText;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method that will countdown timer till 0 seconds to initialise button movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (secondsToStart > 0)
            {
                secondsToStart--; // Decrement the countdown

            }

            //This iwll activicatea user being able to move the books to the upper shelf
            if (secondsToStart == 0)
            {

                EnableBookMovement(); //Enabling the buttons to be draggable
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// //Method to call the Control.Draggable class to enable the dragging of buttons
        /// https://youtu.be/Rytt-a2cTJA?si=cCST1nLwFm8TwZoM
        /// </summary>
        public void EnableBookMovement()
        {
            ControlExtension.Draggable(btnBk1, true);
            ControlExtension.Draggable(btnBk2, true);
            ControlExtension.Draggable(btnBk3, true);
            ControlExtension.Draggable(btnBk4, true);
            ControlExtension.Draggable(btnBk5, true);
            ControlExtension.Draggable(btnBk6, true);
            ControlExtension.Draggable(btnBk7, true);
            ControlExtension.Draggable(btnBk8, true);
            ControlExtension.Draggable(btnBk9, true);
            ControlExtension.Draggable(btnBk10, true);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// //Method to call the Control.Draggable class to disable the dragging of buttons
        /// https://youtu.be/Rytt-a2cTJA?si=cCST1nLwFm8TwZoM
        /// </summary>
        public void DisableBookMovement()
        {

            ControlExtension.Draggable(btnBk1, false);
            ControlExtension.Draggable(btnBk2, false);
            ControlExtension.Draggable(btnBk3, false);
            ControlExtension.Draggable(btnBk4, false);
            ControlExtension.Draggable(btnBk5, false);
            ControlExtension.Draggable(btnBk6, false);
            ControlExtension.Draggable(btnBk7, false);
            ControlExtension.Draggable(btnBk8, false);
            ControlExtension.Draggable(btnBk9, false);
            ControlExtension.Draggable(btnBk10, false);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// //Method to add buttons to a custom button list so we can iterate through it to find each button's position relative to another
        /// </summary>
        private void AddButtonToList()
        {
            // Add button text to the list
            booksToOrder.Add(btnBk1);
            booksToOrder.Add(btnBk2);
            booksToOrder.Add(btnBk3);
            booksToOrder.Add(btnBk4);
            booksToOrder.Add(btnBk5);
            booksToOrder.Add(btnBk6);
            booksToOrder.Add(btnBk7);
            booksToOrder.Add(btnBk8);
            booksToOrder.Add(btnBk9);
            booksToOrder.Add(btnBk10);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Mehtod to generate new call numbers if user selects refersh game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            // Create an instance of Form2
            ReplacBooks form2 = new ReplacBooks();
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Button that will display info on how to play the game should a user press the help button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Dewey Decimal Library!" +
                            "\n" +
                            "\nThe Dewey Decimal System is a method for organizing books Our mission is to help you become familiar with this system." +
                            "\n" +
                            "\nHere's the challenge: There are ten unique books shelved on the bottom half of a shelf,each with its own call number." +
                            "\n" +
                            "\nYour task is to arrange these books in ascending order based on their call numbers." +
                            "\n" +
                            "\nImportant: Press the stop button once books have been ordered to save data. Ensure that the books are properly organized and placed on the top shelf." +
                            "\n" +
                            "\nGood Luck!", "Help", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
//----------------------------------------------------------------------------------ooo000EndOfFile000ooo--------------------------------------------------------------------------------------------