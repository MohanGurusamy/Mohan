using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.ViewModel;
using WordCounterLibrary;

namespace WordCounter.ViewModelTests
{
    [TestClass]
    public class WordCounterViewModelTests
    {
        private WordCounterViewModel sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new WordCounterViewModel();
        }

        [TestMethod]
        public void CountCommand_SentenceIsEmpty_CountCommandIsDisabled()
        {
            // Arrange
            sut.Sentence = string.Empty;

            // Act
            bool isEnabled = sut.CountCommand.CanExecute();

            // Assert
            Assert.IsFalse(isEnabled);
        }

        [TestMethod]
        public void CountCommand_SentenceIsNull_CountCommandIsDisabled()
        {
            // Arrange
            sut.Sentence = null;

            // Act
            bool isEnabled = sut.CountCommand.CanExecute();

            // Assert
            Assert.IsFalse(isEnabled);
        }

        [TestMethod]
        public void CountCommand_SentenceAndSperatorStringsAreSpecified_CountCommandIsEnabled()
        {
            // Arrange
            sut.SeperatorString = ",";
            sut.Sentence = "Word1, Word2";

            // Act
            bool isEnabled = sut.CountCommand.CanExecute();

            // Assert
            Assert.IsTrue(isEnabled);
        }

        [TestMethod]
        public void CountCommand_SentenceAndSperatorStringsAreSpecified_DisplayIsFormedCorrectly()
        {
            // Arrange
            sut.SeperatorString = ",";
            sut.Sentence = "Word1, Word2, Word1";
            var expectedDisplay = new List<WordCountItem> { new WordCountItem("word1", 2), new WordCountItem("word2", 1) }
                .ToDisplayString();

            // Act
            sut.CountCommand.Execute();

            // Assert
            Assert.AreEqual(expectedDisplay, sut.Display);
        }

        [TestMethod]
        public void CountCommand_SeperatorStringDoesNotHaveASpaceButSentenceHas_SpaceIsStillUsedAsASeperator()
        {
            // Arrange
            sut.SeperatorString = ",";
            sut.Sentence = "Word1 Word2  Word1";
            var expectedDisplay = new List<WordCountItem> { new WordCountItem("word1", 2), new WordCountItem("word2", 1) }
                .ToDisplayString();

            // Act
            sut.CountCommand.Execute();

            // Assert
            Assert.AreEqual(expectedDisplay, sut.Display);
        }

        [TestMethod]
        public void CountCommand_SeperatorStringDoesNotHaveANewLineButSentenceHas_NewLineIsStillUsedAsASeperator()
        {
            // Arrange
            sut.SeperatorString = ",";
            sut.Sentence = "Word1\nWord2\nWord1";
            var expectedDisplay = new List<WordCountItem> { new WordCountItem("word1", 2), new WordCountItem("word2", 1) }
                .ToDisplayString();

            // Act
            sut.CountCommand.Execute();

            // Assert
            Assert.AreEqual(expectedDisplay, sut.Display);
        }

        [TestMethod]
        public void CountCommand_SeperatorStringIsNullButSentenceIsValid_IsEnabled()
        {
            // Arrange
            sut.SeperatorString = null;
            sut.Sentence = "Word1 Word2";

            // Act
            bool isEnabled = sut.CountCommand.CanExecute();

            // Assert
            Assert.IsTrue(isEnabled);
        }

        [TestMethod]
        public void CountCommand_SeperatorStringIsEmptyButSentenceIsValid_IsEnabled()
        {
            // Arrange
            sut.SeperatorString = string.Empty;
            sut.Sentence = "Word1 Word2";

            // Act
            bool isEnabled = sut.CountCommand.CanExecute();

            // Assert
            Assert.IsTrue(isEnabled);
        }

        [TestMethod]
        public void CountCommand_SeperatorStringDoesNotHaveACommaButSentenceHas_CommaIsStillUsedAsASeperator()
        {
            // Arrange
            sut.SeperatorString = " ";
            sut.Sentence = "Word1,Word2,Word1";
            var expectedDisplay = new List<WordCountItem> { new WordCountItem("word1", 2), new WordCountItem("word2", 1) }
                .ToDisplayString();

            // Act
            sut.CountCommand.Execute();

            // Assert
            Assert.AreEqual(expectedDisplay, sut.Display);
        }

        [TestMethod]
        public void CountCommand_SeperatorStringDoesNotHaveAPerioButSentenceHas_CommaIsStillUsedAsASeperator()
        {
            // Arrange
            sut.SeperatorString = " ";
            sut.Sentence = "Word1.Word2.Word1";
            var expectedDisplay = new List<WordCountItem> { new WordCountItem("word1", 2), new WordCountItem("word2", 1) }
                .ToDisplayString();

            // Act
            sut.CountCommand.Execute();

            // Assert
            Assert.AreEqual(expectedDisplay, sut.Display);
        }
       
    }
}
