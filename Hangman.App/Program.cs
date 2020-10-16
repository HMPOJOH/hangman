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

        public static Core.Hangman _hangman;


        static void Main(string[] args)
        {

            _hangman = new Core.Hangman(GenerateARandomWord(), 6);

            
            while (_hangman.KeepPlaying)
            {

                
              
                PrintLivesLeft();
                
                PrintAllCorrectCharacters();

                PrintGuesses();                

                Console.Write("Your guess: ");
                string guess = Console.ReadLine();

               
                var result = _hangman.Guess(guess.ToUpper());

                switch (result)
                {
                    case Core.GuessResult.InvalidGuess:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                    case Core.GuessResult.IncorrectGuess:
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect Guess!");
                        break;

                    }

                    case Core.GuessResult.AlreadyGuessed:
                    {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You've already guessed that letter");
                            break;

                        }

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Correct Guess");
                            break;
                        }


                }
                
                Console.ResetColor();
                WaitForUserInput();
                Console.ReadLine();
                Console.Clear();
                
            }


            PrintingTheEndOfTheGame();
            
                

        }

        private static void PrintingTheEndOfTheGame()
        {
           
            
            
            Console.WriteLine("Game Ended");

            if (_hangman.IsCorrectCompleteWord())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Good work, you completed the whole word \"{_hangman.SecretWord}\"!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, you didn't get the complete word, good luck next time!");

                Console.WriteLine("  +---+  " + "\n\r" +
                                   "  |   |  " + "\n\r" +
                                   "  O   |  " + "\n\r" +
                                   " /|\\  |  " + "\n\r" +
                                   " / \\  |  " + "\n\r" +
                                   "      |  " + "\n\r" +
                                   "=========");
                Console.WriteLine();
                Console.WriteLine($"The correct word is \"{_hangman.SecretWord}\" ");
                Console.ResetColor();
            }
        }

        private static void PrintLivesLeft()
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
" /|\\  |  " + "\n\r" +
" /    |  " + "\n\r" +
"      |  " + "\n\r" +
"========="};

           
            Console.WriteLine();

            Console.WriteLine(hangmanPics[6- _hangman._livesLeft]);
            Console.WriteLine();
            Console.Write("Lives left:");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i=0; i < _hangman._livesLeft; i++)
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


        private static void PrintAllCorrectCharacters()
        {

            Console.Write("Secret word: ");
            foreach (var character in _hangman.SecretWord.ToCharArray())
            {
                if (_hangman.guesses.Contains(character) || (character == ' '))
                    Console.Write(character);
                else
                    Console.Write("-");
            }
            Console.WriteLine();
        }


        private static void PrintGuesses()
        {
            if(_hangman.guesses != null && _hangman.guesses.Count > 0){ 
                Console.Write("Your previous guesses:  ");
                foreach (char c in _hangman.guesses)
                {
                    Console.Write(c + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
