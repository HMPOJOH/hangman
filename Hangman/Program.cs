using System;
using System.Collections;
using System.Linq;
using System.Text;

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
                    currentStatus[i] = '-';


            }


            int attempts = word.Replace(" ","").Length;

            StringBuilder guesses = new StringBuilder();

          

            while (currentStatus.Contains('-') && attempts > 0){
                Console.ForegroundColor = ConsoleColor.White;
                //print current status
                foreach (var character in currentStatus)  
                    Console.Write(character);
                Console.WriteLine();


                //print guesses
                Console.WriteLine(guesses.ToString());
                    

                            Console.WriteLine($"attempts left: {attempts}");
                
         
               
                Console.WriteLine("Guess a character:");
                string guess = Console.ReadLine();

                if (guess == "")
                {
                    Console.Clear();
                    continue;
                    
                }
                    


                //change _ into character if a match

                bool isCorrectGuess = false;
                for (int i=0;i< wordToCharArray.Length; i++) { 
                    if (wordToCharArray[i] == guess.ToCharArray()[0]) { 
                        currentStatus[i] = guess.ToCharArray()[0];
                        isCorrectGuess = true;
       
                    }
                   
                }


                if (guesses.ToString().Contains(guess.ToCharArray()[0])) { 
                    Console.WriteLine("You already guessed the character " + guess.Substring(0, 1));
                    Console.ReadLine(); //Press enter


                    Console.Clear();
                    continue;
                }
                else
                {
                    guesses.Append(guess.Substring(0, 1) + " ");
                    attempts--;

                    if (isCorrectGuess)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CORRECT!");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("WRONG GUESS!");
                    }



                }
                Console.ReadLine(); //Press enter
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();


            }

            if(currentStatus.Contains('-'))
                Console.WriteLine("Bad luck! The correct word is "+ word);
            else
                Console.WriteLine("Good work! You nailed the word," + word);


        }
    }
}
