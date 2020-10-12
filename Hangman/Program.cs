using System;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            //WE LIKE C#

            string word = "we like c#";
            

            char[] wordToCharArray = word.ToCharArray();
            char[] currentStatus = new char[wordToCharArray.Length];

            for (int i = 0; i < wordToCharArray.Length; i++)
            {
                if (wordToCharArray[i] == ' ')
                    currentStatus[i] = ' ';
                else
                    currentStatus[i] = '_';


            }


            int attempts = 10;

         
            while (currentStatus.Contains('_') && attempts > 0){
                //print current status

                // foreach (var character in wordToCharArray)
                //    Console.Write(character);

                Console.WriteLine($"attempts left: {attempts}");
                foreach (var character in currentStatus)
                Console.Write(character);
         
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Guess a character:");
                string guess = Console.ReadLine();

                for (int i=0;i< wordToCharArray.Length;i++)
                    if (wordToCharArray[i] == guess.ToCharArray()[0])
                        currentStatus[i] = guess.ToCharArray()[0];

                attempts--;

            }

            if(currentStatus.Contains('_'))
                Console.WriteLine("Bad luck!");
            else
                Console.WriteLine("Good work!");


        }
    }
}
