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

        public bool KeepPlaying => !IsCorrectCompleteWord() && _livesLeft > 0;



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
            if (!IsValidGuess(guess))
                return Core.GuessResult.InvalidGuess;
            //2.Already Guessed
            if (IsAlreadyGuessed(guess))
                return Core.GuessResult.AlreadyGuessed;
            
            
             FeedGuessesList(guess);
                

           
           
            if (IsCorrectGuess(guess))
            {
                
                return Core.GuessResult.CorrectGuess;
            }
            else
            { 
                _livesLeft--;
                return Core.GuessResult.IncorrectGuess;
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

        private bool IsCorrectGuess(string guess)
        {
            if (SecretWord.Contains(guess))
                return true;
            else
                return false;

        }

        // OO: do a IsValidGuess instead
        private bool IsValidGuess(string guess)
        {
            if (guess == "" || guess.Length > 1 || invalidList.Contains(guess.ToCharArray()[0]))
                return false;
            else
                return true;
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
