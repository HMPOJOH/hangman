using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            //Startup Game - Player one will enter a word
            string word = IntroGame();

            GuessTheWord hangmanGame = new GuessTheWord(word);
            //Guess the word
            //GuessTheWord(word);
           
        }
        /*
         private static void GuessTheWord(string word)
         {
             Console.WriteLine("Player two, now it's your turn to guess the word!");

             //transform the word to a char array 
             char[] wordToCharArray = word.ToCharArray();

             //create another chararray just revealing the lenght for the user.
             char[] hiddenWord = new char[wordToCharArray.Length];


             //Set current status to dashes. Notice, also possible for the user to add a sentence with spaces
             for (int i = 0; i < wordToCharArray.Length; i++)
             {
                 if (wordToCharArray[i] == ' ')
                     hiddenWord[i] = ' ';
                 else
                     hiddenWord[i] = '-';


             }

             //set number of attempts             
             int attempts = word.Replace(" ", "").Length;

             //Creating a string to present all character player two has guessed
             StringBuilder guesses = new StringBuilder();


             //keep looping while having attempts left or the hidden word having dashes
             while (hiddenWord.Contains('-') && attempts > 0)
             {
                 Console.ForegroundColor = ConsoleColor.White;


                 //print current hiddenWord
                 foreach (var character in hiddenWord)
                     Console.Write(character);
                 Console.WriteLine();


                 //print guesses
                 Console.WriteLine(guesses.ToString());

                 //print attempts
                 Console.WriteLine($"attempts left: {attempts}");


                 //Let the Player 2 guess
                 Console.WriteLine("Guess a character:");
                 string input = Console.ReadLine();
                 char guess;

                 //Validate input from user 
                 if (!isInputGuessValid(input))
                     continue; //If not valid continue in order to let the player guess again
                 else
                     guess = input.ToCharArray()[0];


                 //check if Player 2 already guessed the character before




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
                     for (int i = 0; i < wordToCharArray.Length; i++)
                         if (wordToCharArray[i] == guess)
                             hiddenWord[i] = guess;

                     guesses.Append(guess + " "); //Add the guess to the guess string.
                     attempts--; //remove attempt

                     CheckIfGuessIsCorrect(word, guess);
                 }
                 Console.Clear();
             }

             CheckIfPlayerTwoWon(hiddenWord, word);

         }

         private static void CheckIfPlayerTwoWon(char[] hiddenWord, string word)
         {
             if (hiddenWord.Contains('-'))
                 Console.WriteLine($"Bad luck! The correct word is {word}");
             else
                 Console.WriteLine($"Good work! You nailed the word, {word}");
         }

         private static void CheckIfGuessIsCorrect(string word, char guess)
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

         }

         private static bool isInputGuessValid(string input)
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
         */
        public static string IntroGame()
       {
           Console.WriteLine("Hi players. This is the hangman game!");
           string word = "";

           while (true) {
               Console.WriteLine("Player one, type a word and don't let player 2 see");
               word = Console.ReadLine();
               if (word.Length <= 0)
                   Console.WriteLine("You need to enter a valid word");
               else
                   break;

           }
           Console.Clear();
           return word;

       }

       
    }
}
