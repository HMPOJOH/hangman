using System;
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
        private StringBuilder guesses = new StringBuilder(); //All unique guesses from Player 2
        char guess; //Guess from Player 2

        public Hangman(string word)
        {         
        this.word = word;            
        }        

        public void Run()
        {                    
            SetNumberOfAttempts();         
            
            while (!CheckIfCorrectWord() && attempts > 0)
            {            

                PrintHiddenWord();

                //print guesses
                Console.WriteLine(guesses.ToString());

                //print attempts
                Console.WriteLine($"attempts left: {attempts}");

                //Get Player 2 guess and check if it is valid. Or if its already guessed.
                if (!GetValidPlayer2Guess() || CheckIfAlreadyGussed())                
                    continue;
                          
                Console.Clear();
            }            
            CheckIfPlayerTwoWon();           
        }

        private bool CheckIfAlreadyGussed()
        {
            if (guesses.ToString().Contains(guess))
            {   
                Console.WriteLine("You already guessed the character " + guess);
                Console.ReadLine(); //Press enter    
                Console.Clear();
                return true;
            }//otherwise proceed with guess
            else
            {
                guesses.Append(guess + " "); //Add the guess to the guess string.
                attempts--; //remove attempt
                CheckIfGuessIsCorrect();
                return false;
            }
        }

        private bool GetValidPlayer2Guess()
        {
            Console.WriteLine("Guess a character:");
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
            string invalidCharacters = "\"%£@#0123456789";

            if (input == "" || input.Length > 1 || invalidCharacters.Contains(input.ToCharArray()[0]))
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
                if (guesses.ToString().Contains(character) || (character == ' ' ) )
                    Console.Write(character);
                else
                    Console.Write("-");
            }                
            Console.WriteLine();
        }

        public bool CheckIfCorrectWord()
        {
            foreach (var character in word.ToCharArray())
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
