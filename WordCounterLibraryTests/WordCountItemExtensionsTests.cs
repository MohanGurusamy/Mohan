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
    public class WordCountItemExtensionsTests
    {
        [TestMethod]
        public void ToDisplayString_MultipleItems_ItemsAreProperlyFormatted()
        {
            // Arrange
            WordCountItem item1 = new WordCountItem("wrd1", 1);
            WordCountItem item2 = new WordCountItem("wrd2", 2);
            var expected = "wrd1\t- 1\nwrd2\t- 2\n";
            var itemList = new List<WordCountItem> { item1, item2 };

            // Act
            var display = itemList.ToDisplayString();

            // Assert
            Assert.AreEqual(expected, display);
        }
    }
}
