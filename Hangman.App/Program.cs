using System;

namespace Hangman.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman!");

            var hangman = new Core.Hangman("I LOVE PROGRAMMING".ToUpper(), 15);

            while (!hangman.IsCorrectCompleteWord() && hangman.NoOfGuesses>0)
            {
                Console.WriteLine($"Attempts left: {hangman.NoOfGuesses}");
                PrintAllCorrectCharacters(hangman);

                Console.Write("Your previous guesses:  ");
                PrintGuesses(hangman);                

                Console.Write("Your guess: ");
                string guess = Console.ReadLine();

                //core.GuessResult.   CorrectGuess, IncorrectGuess, InvalidGuess, AlreadyGuessed
                var result = hangman.Guess(guess.ToUpper());


                if (result == Core.GuessResult.InvalidGuess)
                    Console.WriteLine("Invalid input!");
                else if (result == Core.GuessResult.IncorrectGuess)                
                    Console.WriteLine("Incorrect Guess!");              
                else if (result == Core.GuessResult.AlreadyGuessed)
                    Console.WriteLine("You've already guessed that letter");                
                else if (result == Core.GuessResult.CorrectGuess)
                    //call method in core that updates
                    Console.WriteLine("Correct Guess");

                Console.ReadLine();
                Console.Clear();
            }
         
            Console.WriteLine("Game completed");

            if (hangman.IsCorrectCompleteWord())
                Console.WriteLine("Good work, you completed the whole word!");
            else
                Console.WriteLine("Sorry, you didn't get the complete word, good luck next time!");

        }

        private static void PrintAllCorrectCharacters(Core.Hangman hangman)
        {
            foreach (var character in hangman.SecretWord.ToCharArray())
            {
                if (hangman.guesses.Contains(character) || (character == ' '))
                    Console.Write(character);
                else
                    Console.Write("-");
            }
            Console.WriteLine();
        }


        private static void PrintGuesses(Core.Hangman hangman)
        {
            foreach (char c in hangman.guesses)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
