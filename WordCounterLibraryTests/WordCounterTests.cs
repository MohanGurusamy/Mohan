using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounterLibrary;

namespace WordCounterLibraryTests
{
    [TestClass]
    public class WordCounterTests
    {
        [TestMethod]
        public void GetWordCounts_SingleSeperator_CorrectNumberOfDistinctWordsReturned()
        {
            // Arrange
            char[] sep = { ',' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "wrd1,wrd2 wrd3,wrd1";

            // Act
            IEnumerable<WordCountItem> words = counter.GetWordCounts(sentence);

            // Assert
            Assert.AreEqual(2, words.Count());
        }

        [TestMethod]
        public void GetWordCounts_MultipleSeperators_CorrectNumberOfDistinctWordsReturned()
        {
            // Arrange
            char[] sep = { ',', ' ' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "wrd1,wrd2 wrd3,wrd1";

            // Act
            IEnumerable<WordCountItem> words = counter.GetWordCounts(sentence);

            // Assert
            Assert.AreEqual(3, words.Count());
        }

        [TestMethod]
        public void GetWordCounts_SingleSeperator_WordCountsReturnedInOrderOfFirstOccurence()
        {
            // Arrange
            char[] sep = { ',' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "wrd1,wrd2 wrd3,wrd2 wrd3,wrd1";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words[0].Word=="wrd1" && words[1].Word=="wrd2 wrd3");
        }

        [TestMethod]
        public void GetWordCounts_MultipleSeperators_WordCountsReturnedInOrderOfFirstOccurence()
        {
            // Arrange
            char[] sep = { ',', ' ' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "wrd1,wrd2 wrd3,wrd2 wrd3,wrd1";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words[0].Word == "wrd1" && words[1].Word == "wrd2" && words[2].Word=="wrd3");
        }

        [TestMethod]
        public void GetWordCounts_SingleSeperator_WordCountsReturnedCorrectly()
        {
            // Arrange
            char[] sep = { ',' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "wrd1,wrd2 wrd3,wrd2 wrd3";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words[0].Count == 1 && words[1].Count == 2);
        }

        [TestMethod]
        public void GetWordCounts_MultipleSeperators_WordCountsReturnedCorrectly()
        {
            // Arrange
            char[] sep = { ',', ' ' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "wrd1,wrd2 wrd3,wrd2 wrd3";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words[0].Count == 1 && words[1].Count == 2 && words[2].Count==2);
        }

        [TestMethod]
        public void GetWordCounts_WordsDifferOnlyByCase_TheyAreTreatedEqual()
        {
            // Arrange
            char[] sep = {' ' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "WRD1 wrd2 wrD1 wRd2";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words[0].Word=="wrd1" && words[0].Count == 2 && words[1].Word=="wrd2" && words[1].Count == 2);
        }

        [TestMethod]
        public void GetWordCounts_SpaceBetweenSeperators_Ignored()
        {
            // Arrange
            char[] sep = { ',' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "wrd1, ,";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words.Count == 1 && words[0].Word == "wrd1" && words[0].Count == 1);
        }

        [TestMethod]
        public void GetWordCounts_ItemsHaveLeadingSpaces_Trimmed()
        {
            // Arrange
            char[] sep = { ',' };
            WordCounter counter = new WordCounter(sep);
            string sentence = " Word1";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words.Single().Word == "word1");
        }

        [TestMethod]
        public void GetWordCounts_ItemsHaveTrailingSpaces_Trimmed()
        {
            // Arrange
            char[] sep = { ',' };
            WordCounter counter = new WordCounter(sep);
            string sentence = "Word1 ";

            // Act
            List<WordCountItem> words = counter.GetWordCounts(sentence).ToList();

            // Assert
            Assert.IsTrue(words.Single().Word == "word1");
        }

    }
}
