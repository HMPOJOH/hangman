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

        [TestMethod]
        public void should_return_2_attempts_when_guessed_one_time_incorrect()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            hangman.Guess("Y");
            // Assert
            Assert.AreEqual(2, hangman._liveseLeft);
        }

        [TestMethod]
        public void should_return_3_attempts_when_guessed_one_time_correct()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            hangman.Guess("K");
            // Assert
            Assert.AreEqual(3, hangman._liveseLeft);
        }


        [TestMethod]
        public void should_return_True_when_guessed_all_correct_characters()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 5);
            // Act
            hangman.Guess("K");
            hangman.Guess("A");
            hangman.Guess("L");
            hangman.Guess("L");
            hangman.Guess("E");
            // Assert
            Assert.IsTrue(hangman.IsCorrectCompleteWord());
        }

        [TestMethod]
        public void should_return_False_when_not_all_correct_characters()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 5);
            // Act
            hangman.Guess("K");
            hangman.Guess("A");
            hangman.Guess("L");
            hangman.Guess("L");
            hangman.Guess("Y");
            // Assert
            Assert.IsFalse(hangman.IsCorrectCompleteWord());
        }

    }
}
