// All about the game logic
using System;
using System.Collections.Generic;

namespace Hangman.Core
{
    public class Hangman
    {
        public string SecretWord { get; }
        public int _livesLeft { set; get; }

        private List<char> invalidList = new List<char>();
        public List<Char> guesses  {get; }

        public bool KeepPlaying { 
            get
            {
                return (!IsCorrectCompleteWord() && _livesLeft > 0);


            }
        
        
        }



        public Hangman(string secretWord, int livesLeft)
        {
            SecretWord = secretWord;
            _livesLeft = livesLeft;
            invalidList.AddRange("\"%£@#0123456789");
            guesses = new List<char>();           
        }

        public GuessResult Guess(string guess)
        {           
            //1. check invalid input
            if (IsInvalidGuess(guess))
                return Core.GuessResult.InvalidGuess;
            //2.Already Guessed
            // OO: No need for "else"
            else if (IsAlreadyGuessed(guess))
                return Core.GuessResult.AlreadyGuessed;
            // OO: No need for "else"
            else
            {
                FeedGuessesList(guess);
                

                //3a. Check if we should return correct or incorrect
                // OO: detail, create a method named "IsCorrectGuess" instead
                if (IsIncorrectGuess(guess))
                {
                    _livesLeft--;
                    return Core.GuessResult.IncorrectGuess;
                }
                    
                else
                    return Core.GuessResult.CorrectGuess;
            }            
        }

        private void FeedGuessesList(string guess)
        {
            guesses.Add(guess.ToCharArray()[0]);
        }

        private bool IsAlreadyGuessed(string guess)
        {
            if (guesses.Contains(guess.ToCharArray()[0]))
                return true;
            else
                return false;
        }

        private bool IsIncorrectGuess(string guess)
        {
            if (SecretWord.Contains(guess))
                return false;
            else
                return true;

        }

        // OO: do a IsValidGuess instead
        private bool IsInvalidGuess(string guess)
        {
            if (guess == "" || guess.Length > 1 || invalidList.Contains(guess.ToCharArray()[0]))
                return true;
            else
                return false;
        }

      



        public bool IsCorrectCompleteWord()
        {
            bool test = true;
            
            foreach (var character in SecretWord.ToCharArray())
            {
                if (!guesses.Contains(character) && character != ' ')
                    test = false; ;
            }
            return test;
        }


    }
}
