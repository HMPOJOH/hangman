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

            StartGame hangmanGame = new StartGame();
            hangmanGame.StartGuessing();
            hangmanGame.CheckIfPlayerTwoWon();


        }
      
 

       
    }
}
