using System;
using System.Collections.Generic;

//Jones, James
//06/11/2021
//DEV2300-O 02: Application Program Development
//Synopsis: Gallows class file to display the game and the word for the user to guess.
//No functionality or user interaction should go in this class.
namespace JonesJames_CE08_Refactored
{
    public class Gallows
    {

        //Fields
        private string _definition;

        //Properties
        public static string Word { get; set; }

        //Constructor method to store the values.
        public Gallows(string word, string definition)
        {
            Word = word;

            _definition = definition;
        }

        public void DisplayGallows(List<char> letters)
        {
            Console.Clear();

            //Header for the game
            Console.WriteLine("========================");
            Console.WriteLine("HANGMAN");
            Console.WriteLine("========================");

            //Hint, definition for the user
            Console.WriteLine($"Definition: {_definition}\r\n");

            //Display each letter in the object's word as an underscore.
            foreach (char letter in Word)
            {
                if (!letters.Contains(letter))
                {
                    Console.Write("__ ");
                }
                else
                {
                    Console.Write(letter);
                }
            }
        }

        public static bool GallowsSolved(List<char> letters)
        {
            bool solved = true;
            
            foreach (char letter in Word)
            {
                if (!letters.Contains(letter))
                {
                    solved = false;
                }
            }

            return solved;
        }
    }
}
