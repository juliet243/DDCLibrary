using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDCLibrary
{
    class WorkerClass
    {
        private Random random = new Random(); //Help with the genration of random nmbrs
        private LinkedList<int> callNumbers = new LinkedList<int>(); //linked list to store random numbers
        // LinkedList<string> letters = new LinkedList<string>();
        private List<Button> lives = new List<Button>(); //List to store lives
        private int failedAttempts = 0; //global variable to keep track of a user's failed attempts in the game
        private DialogResult result; //To store the dialog result selected by user.

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkerClass()
        {
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="booksToOrder"></param>
        /// <param name="panel1"></param>
        /// <param name="lifeIcon1"></param>
        /// <param name="lifeIcon2"></param>
        /// <param name="lifeIcon3"></param>
        public void SortUsingBubbleSort(List<Button> booksToOrder, Panel panel1, Button lifeIcon1, Button lifeIcon2, Button lifeIcon3)
        {
            int panelBottomY = panel1.Bottom;
            try //Try and catch to catch any errors
            {
                bool flag1 = Flag1(booksToOrder);
                bool flag2 = booksToOrder.All(button => button.Location.Y < panel1.Bottom || button.Location.Y < panel1.Top); // This flag is raised to check which shelf the user has placed the books

                if (flag2 == false)
                {
                    panel1.BackColor = Color.Red; //If a user places a book outside the shelf the shelf/panel will turn red to help users see where exactly to place the book
                    MessageBox.Show("Ensure books are shelved within the shelf/red panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (flag1 && flag2)
                    {
                        // If successfully sorted this message appears
                        MessageBox.Show("Books successfully ordered! New Badge earned", "CONGRATULATIONS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        result = MessageBox.Show("Start a new game?", "DDL", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        // This will call the PromptNewUser method where a user will be asked if they want to start a new game or not. It passes the result from the above if statement
                        PromptNewGame(result);
                    }
                    else
                    {
                        failedAttempts++; //Accumulating the failed attempts

                        if (failedAttempts == 1)
                        {
                            // If unsuccessfully sorted on the first attempt
                            MessageBox.Show("You missed a book or two :( Only two lives left!", "oh no...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                            //Calling prompt new game method
                            PromptNewGame(result); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="booksToOrder"></param>
        /// <returns></returns>
        public bool Flag1(List<Button> booksToOrder)
        {
            //Sorting through the book location using data in list
                Boolean flag1 = booksToOrder[0].Location.X < booksToOrder[1].Location.X &&
                               booksToOrder[1].Location.X < booksToOrder[2].Location.X &&
                               booksToOrder[2].Location.X < booksToOrder[3].Location.X &&
                               booksToOrder[3].Location.X < booksToOrder[4].Location.X &&
                               booksToOrder[4].Location.X < booksToOrder[5].Location.X &&
                               booksToOrder[5].Location.X < booksToOrder[6].Location.X &&
                               booksToOrder[6].Location.X < booksToOrder[7].Location.X &&
                               booksToOrder[7].Location.X < booksToOrder[8].Location.X &&
                               booksToOrder[8].Location.X < booksToOrder[9].Location.X;      
            return flag1;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method that will manage what happens after a user is asked to start a new game or exit the application.
        /// </summary>
        /// <param name="result"></param>
        public void PromptNewGame(DialogResult result)
        {
             
                if (result == DialogResult.OK)
                {
                    // Create an instance of Form2
                    StartPrompt form2 = new StartPrompt();
                    // Show Form2 and hide Form1
                    form2.Show();
                    // this.Hide();
                }
                else
                {
                    // Create an instance of Form2
                    Home form2 = new Home();
                    // Show Form2 and hide Form1
                    form2.Show();
                    // this.Hide();
                }       
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
//----------------------------------------------------------------------------------ooo000EndOfFile000ooo--------------------------------------------------------------------------------------------