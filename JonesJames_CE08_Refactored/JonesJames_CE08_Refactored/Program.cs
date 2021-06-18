using System;

//Jones, James
//06/11/2021
//DEV2300-O 02: Application Program Development
//Synopsis: Program class file to serve as the game's entry point.

namespace JonesJames_CE08_Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playHangman = true;

            while (playHangman)
            {
                //New Hangman object
                Hangman game = new Hangman();

                game.Play();

                //Play Again?
                playHangman = PlayAgain();
            }

            //Exit message
            Console.WriteLine("\r\nThanks for playing! Have a wonderful day!");
        }

        //Allow the user to play the Hangman game again
        private static bool PlayAgain()
        {
            Console.WriteLine("\r\n\r\n========================");

            Console.Write("Would you like to play again? [Y/N]: ");

            string response = Console.ReadLine().ToUpper();

            //Validate the response
            while (response != "Y" && response != "N")
            {
                //Tell the user the error
                Console.WriteLine("\r\nPlease only type in [Y/N]. ");

                //Re-state the question/instructions
                Console.Write("\r\nWould you like to play again? [Y/N]: ");

                //Re-prompt for the user's input
                response = Console.ReadLine();

            }

            return (response == "Y") ? true : false;
        }
    }
}
