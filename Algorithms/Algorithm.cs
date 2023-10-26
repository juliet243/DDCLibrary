using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    //Class Library
    public class Algorithm
    {
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to randomly generate 3 letters 
        /// </summary>
        /// <returns></returns>
        //
        public LinkedList<string> GenerateRandomLetterSets(int numberOfSets, int lettersPerSet)
        {
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            LinkedList<string> letterSets = new LinkedList<string>();

            for (int setIndex = 0; setIndex < numberOfSets; setIndex++)
            {
                string letters = "";

                for (int i = 0; i < lettersPerSet; i++)
                {
                    int index = random.Next(0, alphabet.Length); // Generate a random index
                    char randomLetter = alphabet[index]; // Get the letter at the random index
                    letters += randomLetter.ToString(); // Add it to the result string
                }

                letterSets.AddLast(letters); // Add the set of letters to the list of sets
            }

            return letterSets;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method that will generate random numbers
        /// </summary>
        /// <returns></returns>
        //Method and algorithm that will randomly generate numbers
        public LinkedList<int> GenerateCallNumbers()
        {
            LinkedList<int> callNumbers = new LinkedList<int>(); //linked list to store random numbers
            Random random = new Random(); //Help with the genration of random nmbrs
            while (callNumbers.Count < 10)
            {
                int callNumber = random.Next(100, 1000); // Generate a random number between 100 and 999

                // Check if the generated number is not already in the linked list
                if (!callNumbers.Contains(callNumber))
                {
                    callNumbers.AddLast(callNumber); // Add it to the linked list
                }
            }

            return callNumbers;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
