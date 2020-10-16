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
          
            var hangman = new Core.Hangman(GenerateARandomWord(), 6);

            // OO: Instead of this comment, create a property (getter) in hangman that has similair name e.g while(hangman.KeepPlaying) {...}

            //Keep playing while the user hasn't guessed the whole word or user has guesses left
            while (!hangman.IsCorrectCompleteWord() && hangman._livesLeft>0)
            {

                
                // OO: Since you send "hangman" to a lot of methods you might create a field "_hangman" in "Program" instead
                PrintLivesLeft(hangman);
                
                PrintAllCorrectCharacters(hangman);

                PrintGuesses(hangman);                

                Console.Write("Your guess: ");
                string guess = Console.ReadLine();

                // OO: Remove comment
                //Possible values are:  CorrectGuess, IncorrectGuess, InvalidGuess, AlreadyGuessed
                var result = hangman.Guess(guess.ToUpper());

                // OO: Use a "switch" instead
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


            PrintingTheEndOfTheGame(hangman);
            
                

        }

        private static void PrintingTheEndOfTheGame(Core.Hangman hangman)
        {
            Console.WriteLine("Game Ended");

            if (hangman.IsCorrectCompleteWord())
                Console.WriteLine($"Good work, you completed the whole word \"{hangman.SecretWord}\"!");
            else
            {
                Console.WriteLine("Sorry, you didn't get the complete word, good luck next time!");

                Console.WriteLine("  +---+  " + "\n\r" +
                                   "  |   |  " + "\n\r" +
                                   "  O   |  " + "\n\r" +
                                   " /|\\  |  " + "\n\r" +
                                   " / \\  |  " + "\n\r" +
                                   "      |  " + "\n\r" +
                                   "=========");
                Console.WriteLine();
                Console.WriteLine($"The correct word is \"{hangman.SecretWord}\" ");
            }
        }

        private static void PrintLivesLeft(Core.Hangman hangman)
        {

            Console.WriteLine("HANGMAN GAME");

            var hangmanPics = new[]
{
"  +---+  " + "\n\r" +
"  |   |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"=========",
"  +---+  " + "\n\r" +
"  |   |  " + "\n\r" +
"  O   |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"=========",
"  +---+  " + "\n\r" +
"  |   |  " + "\n\r" +
"  O   |  " + "\n\r" +
"  |   |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"=========",
"  +---+  " + "\n\r" +
"  |   |  " + "\n\r" +
"  O   |  " + "\n\r" +
" /|   |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"=========",
"  +---+  " + "\n\r" +
"  |   |  " + "\n\r" +
"  O   |  " + "\n\r" +
" /|\\  |  " + "\n\r" +
"      |  " + "\n\r" +
"      |  " + "\n\r" +
"=========",
"  +---+  " + "\n\r" +
"  |   |  " + "\n\r" +
"  O   |  " + "\n\r" +
" /|\\ |  " + "\n\r" +
" /    |  " + "\n\r" +
"      |  " + "\n\r" +
"========="};

           
            Console.WriteLine();

            Console.WriteLine(hangmanPics[6- hangman._livesLeft]);
            Console.WriteLine();
            Console.Write("Lives left:");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i=0; i < hangman._livesLeft; i++)
                Console.Write("♥");

            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();

            
           
        }

        private static void WaitForUserInput()
        {
           
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");

        }

        private static string GenerateARandomWord()
        {
            string[] secretwords = new[] { "JAVA", "I LIKE C", "HM IS THE BEST COMPANY IN THE WORLD", "BANANA", "BLUE CAR WITH WHEELS", "HELLO WORLD", "bagpipes", "blizzard","PIZZA", "fluffiness", "BORÅS", "HAPPYBITS IS QUITE GOOD AS WELL" };
            Random random = new Random();
            return secretwords[random.Next(secretwords.Length)].ToUpper();
        }


        private static void PrintAllCorrectCharacters(Core.Hangman hangman)
        {

            Console.Write("Secret word: ");
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
