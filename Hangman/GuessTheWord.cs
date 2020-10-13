using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class GuessTheWord
    {
        private char[] wordToCharArray; //Word to charArray
        private char[] hiddenWord; //Word displaying on the screen
        private string word; //Word from player One
        private int attempts;
        private StringBuilder guesses = new StringBuilder(); //All unique guesses from Player 2

        char guess; //Guess from Player 2

        public GuessTheWord(string word)
        {
            this.word = word;
            wordToCharArray = word.ToCharArray();
            hiddenWord = new char[wordToCharArray.Length];

            SetNumberOfAttempts();
            SetHiddenWord();

           

            while (hiddenWord.Contains('-') && attempts > 0)
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

                //Check if alreadyu
                if (guesses.ToString().Contains(guess))
                {
                    Console.WriteLine("You already guessed the character " + guess);
                    Console.ReadLine(); //Press enter

                    Console.Clear();
                    continue;
                }//otherwise proceed with guess
                else
                {
                    //update hidden word if guess is correct
                   

                    guesses.Append(guess + " "); //Add the guess to the guess string.
                    attempts--; //remove attempt

                    if(CheckIfGuessIsCorrect())
                        UpdateHiddenWord();
                }
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.White;
            CheckIfPlayerTwoWon();
        }
        private bool CheckIfGuessIsCorrect()
        {

            bool correctGuess = false;
            if (word.Contains(guess))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CORRECT! Press Enter to continue.");
                 Console.ForegroundColor = ConsoleColor.White;
                correctGuess = true;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WRONG GUESS! Press Enter to continue.");
            }
            Console.ReadLine(); //Wait for user input
            return correctGuess;

        }
        private void CheckIfPlayerTwoWon()
        {
            if (hiddenWord.Contains('-'))
                Console.WriteLine($"Bad luck! The correct word is {word}");
            else
                Console.WriteLine($"Good work! You nailed the word, {word}");
        }

        private void UpdateHiddenWord()
        {
            for (int i = 0; i < wordToCharArray.Length; i++)
                if (wordToCharArray[i] == guess)
                    hiddenWord[i] = guess;
        }

        public bool isInputGuessValid(string input)
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
            foreach (var character in hiddenWord)
                Console.Write(character);
            Console.WriteLine();
        }

        public void SetNumberOfAttempts()
        { //Set number of Attempts
            attempts = word.Replace(" ", "").Length;
        }

        public void SetHiddenWord()
        {
            for (int i = 0; i < wordToCharArray.Length; i++)
            {
                if (wordToCharArray[i] == ' ')
                    hiddenWord[i] = ' ';
                else
                    hiddenWord[i] = '-';


            }
        }




    }
}
