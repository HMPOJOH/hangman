using System;

namespace Hangman.App
{

    /*
     * In Hangman.APP
     * --------------------
     * - All interaction with user
     * - No logic
     * 
     * In Hangman.Core
     * --------------------
     * - All logic/validation etcetera
     * - No Console.WriteLine
     * 
     * 
     */




   

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman!");

            var hangman = new Core.Hangman(GenerateARandomWord(), 15);


            //Keep playing while the user hasn't guessed the whole word or user has guesses left
            while (!hangman.IsCorrectCompleteWord() && hangman.NoOfGuesses>0)
            {
                Console.WriteLine($"Attempts left: {hangman.NoOfGuesses}");
                PrintAllCorrectCharacters(hangman);

                PrintGuesses(hangman);                

                Console.Write("Your guess: ");
                string guess = Console.ReadLine();

                //Possible values are:  CorrectGuess, IncorrectGuess, InvalidGuess, AlreadyGuessed
                var result = hangman.Guess(guess.ToUpper());


                if (result == Core.GuessResult.InvalidGuess)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid input!");
                }
                else if (result == Core.GuessResult.IncorrectGuess)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect Guess!");
                }
                else if (result == Core.GuessResult.AlreadyGuessed)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine("You've already guessed that letter"); 
                }


                else if (result == Core.GuessResult.CorrectGuess) { 
                    //call method in core that updates

                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct Guess");
                }
                Console.ResetColor();
                WaitForUserInput();
                Console.ReadLine();
                Console.Clear();
                
            }
         
            Console.WriteLine("Game completed");

            if (hangman.IsCorrectCompleteWord())
                Console.WriteLine("Good work, you completed the whole word!");
            else
                Console.WriteLine("Sorry, you didn't get the complete word, good luck next time!");

        }

        private static void WaitForUserInput()
        {
           
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");

        }

        private static string GenerateARandomWord()
        {
            string[] secretwords = new[] { "JAVA", "I LIKE C", "HM IS THE BEST", "BANANA", "BLUE CAR WITH WHEELS", "HELLO WORLD"};

            Random random = new Random();
            return secretwords[random.Next(0, 10)].ToUpper();

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
            if(hangman.guesses != null && hangman.guesses.Count > 0){ 
                Console.Write("Your previous guesses:  ");
                foreach (char c in hangman.guesses)
                {
                    Console.Write(c + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
