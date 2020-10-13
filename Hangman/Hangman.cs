using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    class Hangman
    {
        // todo: recuding the number of fields            
        private string word; //Word from player One
        private char[] wordToCharArray; //Word to charArray  
        private int attempts;
        private StringBuilder guesses = new StringBuilder(); //All unique guesses from Player 2
        char guess; //Guess from Player 2

        public Hangman(string word)
        {         
        this.word = word;            
        }        

        public void Run()
        {
            wordToCharArray = word.ToCharArray();           

            SetNumberOfAttempts();           
            

            while (!CheckIfCorrectWord() && attempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;

                PrintHiddenWord();

                //print guesses
                Console.WriteLine(guesses.ToString());

                //print attempts
                Console.WriteLine($"attempts left: {attempts}");

                //Let Player 2 guess
                Console.WriteLine("Guess a character:");
                string input = Console.ReadLine().ToUpper();

                if (!isInputGuessValid(input))
                    continue; //If not valid continue in order to let the player guess again
                else
                    guess = input.ToCharArray()[0];

                //Check if already
                if (guesses.ToString().Contains(guess))
                {
                    Console.WriteLine("You already guessed the character " + guess);
                    Console.ReadLine(); //Press enter

                    Console.Clear();
                    continue;
                }//otherwise proceed with guess
                else
                {                   

                    guesses.Append(guess + " "); //Add the guess to the guess string.
                    attempts--; //remove attempt
                    CheckIfGuessIsCorrect();

                }
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.White;
            CheckIfPlayerTwoWon();           
        }

        private void CheckIfGuessIsCorrect()
        {            
            if (word.Contains(guess))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CORRECT! Press Enter to continue.");
                Console.ForegroundColor = ConsoleColor.White;
                

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WRONG GUESS! Press Enter to continue.");
            }
            Console.ReadLine(); //Wait for user input           

        }
        private void CheckIfPlayerTwoWon()
        {       
            
            if (!CheckIfCorrectWord())
                Console.WriteLine($"Bad luck! The correct word is {word}");
            else
                Console.WriteLine($"Good work! You nailed the word, {word}");
        }    

        public bool isInputGuessValid(string input) // todo: first letter capital
        {
            string invalidCharacters = "\"%£@#";

            if (input == "" || input.Length > 1 || invalidCharacters.Contains(input.ToCharArray()[0]))
            {
                Console.WriteLine("Invalid character");
                Console.ReadLine();
                Console.Clear();
                return false;

            }
            else
                return true;
        }


        public void PrintHiddenWord()
        {
            foreach (var character in wordToCharArray)
            {
                if (guesses.ToString().Contains(character) || (character == ' ' ) )
                    Console.Write(character);
                else
                    Console.Write("-");
            }                
            Console.WriteLine();
        }

        public bool CheckIfCorrectWord()
        {
            foreach (var character in wordToCharArray)
            {
                if (!guesses.ToString().Contains(character))
                    return false; ;
            }
            return true;
        }

        public void SetNumberOfAttempts()
        { //Set number of Attempts
            attempts = word.Replace(" ", "").Length;
        }        

    }
}
