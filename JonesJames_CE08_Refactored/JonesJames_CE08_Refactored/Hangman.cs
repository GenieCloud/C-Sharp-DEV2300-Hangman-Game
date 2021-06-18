using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Jones, James
//06/11/2021
//DEV2300-O 02: Application Program Development
//Synopsis: Hangman class file to hold the game's functionality that supports the user playing the game.

namespace JonesJames_CE08_Refactored
{
    public class Hangman
    {
        //Fields
        private Random _random = new Random();

        private List<string> _words = new List<string>();

        private Dictionary<string, string> _wordDefs = new Dictionary<string, string>();

        private List<char> _guesses = new List<char>();

        private List<char> _misses = new List<char>();

        private bool _win = false;

        private bool _lose = false;

        public Hangman()
        {
            using (StreamReader sr = new StreamReader("../../../Dictionary.txt"))
            {
                string word;

                while ((word = sr.ReadLine()) != null)
                {
                    //Split the data into two parts: word and definition.
                    string[] wordArray = word.Split(':');

                    //Add word and definition to the Dictionary.
                    _wordDefs.Add(wordArray[0], wordArray[1]);

                    _words.Add(wordArray[0]);
                }
            }
        }

        public void Play()
        {
            //Randomly choose a word from the list of words.
            int index = _random.Next(0, _words.Count);

            //Set the gallows object to store a random word and definition.
            //NOTE: Dictionaries DO NOT use indexes.
            string word = _words[index];

            //Display word and definition from the Dictionary
            Gallows gallows = new Gallows(word, _wordDefs[word]);

            //Display the gallows, passing in the list of guesses.
            gallows.DisplayGallows(_guesses);

            while (!_win && !_lose)
            {
                //Display the gallows, passing in the list of guesses.
                gallows.DisplayGallows(_guesses);

                DisplayMissedLetters();

                char guess = GuessALetter();

                GuessCheck(guess);
            }
            
        }

        //Method to display missed letters.
        private void DisplayMissedLetters()
        {
            Console.WriteLine("\r\n\r\n-----------------");

            Console.Write("Missed Letters: ");

            foreach (char letter in _misses)
            {
                Console.Write($"{letter} ");
            }
        }

        private char GuessALetter()
        {
            Console.WriteLine("\r\n\r\n-----------------");

            Console.Write("Choose a letter: ");

            string userInput = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userInput) || userInput.Length > 1 || _guesses.Contains(userInput[0]))
            {
                Console.WriteLine("\r\nPlease do not leave this blank.\r\nPlease only choose one letter at a time.\r\nPlease do not guess a letter that has been missed.");

                Console.Write("\r\nChoose a letter: ");

                userInput = Console.ReadLine();
            }

            _guesses.Add(userInput[0]);

            return userInput[0];
        }
        //Method to check if the user has guessed a letter correctly
        private void GuessCheck(char letter)
        {   //The word does not contain the guessed letter, add it to 
            if (!Gallows.Word.Contains(letter))
            {
                _misses.Add(letter);

                if (_misses.Count == 6)
                {
                    _lose = true;

                    Console.WriteLine("\r\n\r\n-----------------");

                    Console.WriteLine("Uh oh...Hangman!");
                }
            }
            else
            {
                bool winner = true;

                for (int i = 0; i < Gallows.Word.Length; i++)
                {
                    if (!_guesses.Contains(Gallows.Word[i]))
                    {
                        winner = false;
                    }
                }

                _win = winner;

                Gallows gallows = new Gallows(Gallows.Word, _wordDefs[Gallows.Word]);

                gallows.DisplayGallows(_guesses);

                Console.WriteLine("\r\n\r\n-----------------");

                Console.WriteLine("\r\nCongratulations! You win! You have beat the gallows!");
            }
        }
    }
}
