using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    class Hangman
    {
        private string word; //Word from player One        
        private int attempts; // No of guesses
        //private StringBuilder guesses = new StringBuilder(); //All unique guesses from Player 2 
        private List<Char> guesses = new List<char>(); 
        // todo: look at some other datatype. List<char>. Hash<char>
        char guess; //Guess from Player 2 // todo: maybe remove the field
        List<char> invalidList = new List<char>();

        public Hangman(string word, List<char> invalidList)
        {
            this.word = word;
            this.invalidList = invalidList;
        }

        public void Run()
        {
            SetNumberOfAttempts();

            while (!CheckIfCorrectWord() && attempts > 0)
            {
                PrintHiddenWord();

                //print guesses
                PrintGuesses();
                //Console.WriteLine(guesses.ToString());

                //print attempts
                Console.WriteLine($"Attempts left: {attempts}");

                //Get Player2 guess. Check if it is valid or if its already guessed.
                if (!GetValidPlayer2Guess() || HasAlreadyGuessedCharacterBefore())
                    continue;

                Console.Clear();
            }
            CheckIfPlayerTwoWon();
        }

        private void PrintGuesses()
        {
            foreach (char c in guesses)
            {
                Console.Write(c+" ");
            }
            Console.WriteLine();
        }

        private bool HasAlreadyGuessedCharacterBefore()
        {
            if (guesses.Contains(guess))
            {
                Console.WriteLine("You already guessed the character " + guess);
                Console.ReadLine(); //Press enter    
                Console.Clear();
                return true;
            }//otherwise proceed with guess
            else
            {
                //Add the guess to the guess string.
                //guesses.Append(guess + " ");
                guesses.Add(guess);
                attempts--; //remove attempt
                CheckIfGuessIsCorrect();
                return false;
            }
        }

        private bool GetValidPlayer2Guess()
        {
            Console.Write("Guess a character : ");
            string input = Console.ReadLine().ToUpper();

            if (!IsInputGuessValid(input))
                return false; //If not valid continue in order to let the player guess again
            else
                guess = input.ToCharArray()[0];

            return true;
        }

        private void CheckIfGuessIsCorrect()
        {
            if (word.Contains(guess))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CORRECT! Press Enter to continue.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WRONG GUESS! Press Enter to continue.");
            }
            Console.ReadLine(); //Wait for user input     
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void CheckIfPlayerTwoWon()
        {
            if (!CheckIfCorrectWord())
                Console.WriteLine($"Bad luck! The correct word is {word}");
            else
                Console.WriteLine($"Good work! You nailed the word, {word}");
        }

        public bool IsInputGuessValid(string input)
        {
           // string invalidCharacters = "\"%£@#0123456789";

            if (input == "" || input.Length > 1 || invalidList.Contains(input.ToCharArray()[0]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid character");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else
                return true;
        }


        public void PrintHiddenWord()
        {
            foreach (var character in word.ToCharArray())
            {
                if (guesses.Contains(character) || (character == ' '))
                    Console.Write(character);
                else
                    Console.Write("-");
            }
            Console.WriteLine();
        }

        // todo: naming 
        // HasOneCharacter
        // ContainsBlaBla
        public bool CheckIfCorrectWord()
        {
            foreach (var character in word.ToCharArray())
            {
                if (!guesses.Contains(character) && character!=' ' )
                    return false; ;
            }
            return true;
        }

        public void SetNumberOfAttempts()
        { //Set number of Attempts
            attempts = word.Replace(" ", "").Length + 2;
        }

    }
}
