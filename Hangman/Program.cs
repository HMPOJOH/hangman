using System;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hi players. This is the hangman game!");
            Console.WriteLine("Player one, type a word and don't let player 2 see");
            string word = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Player two, now it's your turn to guess the word!");



            //string word = "we like c#";


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
                Console.Clear();
            }

            if(currentStatus.Contains('_'))
                Console.WriteLine("Bad luck! The correct word is "+ word);
            else
                Console.WriteLine("Good work! You nailed the word," + word);


        }
    }
}
