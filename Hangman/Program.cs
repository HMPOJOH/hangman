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
            string word = GetWordFromPlayerOne();            

            // Play the game
            var h = new Hangman(word); 
            h.Run();         
           
        }

        // GetSecretWordFromPlayerOne
        public static string GetWordFromPlayerOne()
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
            return word.ToUpper(); ;

       }
       
    }
}
