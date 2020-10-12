using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            //WE LIKE C#

            string word = "we like c#";

            char[] wordToCharArray = word.ToCharArray();

            foreach (var character in wordToCharArray)
                Console.Write(character);


         //   Console.WriteLine("__ ____ __");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Guess the sentence:");
            

        }
    }
}
