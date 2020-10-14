using System;
using System.Collections;
using System.Collections.Generic;
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
            string invalidCharacters = "\"%£@#0123456789";
            List<char> invalidList = new List<char>();
            invalidList.AddRange(invalidCharacters);

            //Startup Game - Player one will enter a word
            string word = GetWordFromPlayerOne(invalidList);            

            // Play the game
            var h = new Hangman(word, invalidList); 
            h.Run();         
           
        }

        // GetSecretWordFromPlayerOne
        public static string GetWordFromPlayerOne(List<char> invalidList)
        {
           Console.WriteLine("Hi players. This is the hangman game!");
           string word = "";

           while (true) {
               Console.WriteLine("Player one, type a word and don't let player 2 see");
               word = Console.ReadLine();

               if (word.Length <= 0 || HasInvalidWord(invalidList, word))
                   Console.WriteLine("You need to enter a valid word");
               else
                   break;

           }
           Console.Clear();
           return word.ToUpper(); 
        }

        private static bool HasInvalidWord(List<char> invalidList, string word)
        {
            foreach (var character in word.ToCharArray())
            {
                if (invalidList.Contains(character))
                    return true; 
            }
            return false;
        }
    }
}
