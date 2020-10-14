using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Core.Test
{
    [TestClass]
    public class Hangman_Guess
    {
        [TestMethod]
        public void should_return_CorrectGuess_when_guessing_A()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("A");
            // Assert
            Assert.AreEqual(GuessResult.CorrectGuess, result);
        }

        [TestMethod]
        public void should_return_AlreadyGuessed_when_guessing_A_twice()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("A");
            result = hangman.Guess("A");
            // Assert
            Assert.AreEqual(GuessResult.AlreadyGuessed, result);
        }


        [TestMethod]
        public void should_return_InvalidGuess_when_guessing_8()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("8");          
            // Assert
            Assert.AreEqual(GuessResult.InvalidGuess, result);
        }

        [TestMethod]
        public void should_return_IncorrectGuess_when_guessing_A()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("Y");
            // Assert
            Assert.AreEqual(GuessResult.IncorrectGuess, result);
        }

    }
}
