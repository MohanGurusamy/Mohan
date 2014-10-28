using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class WordCounter
    {
        private char[] seperators;

        public WordCounter(params char[] septors)
        {
            this.seperators = septors;
        }

        public IEnumerable<WordCountItem> GetWordCounts(string sentence)
        {
            var ret = sentence
                .Split(seperators)
                .Where(x=>!string.IsNullOrWhiteSpace(x))
                .GroupBy(x => x.Trim(), StringComparer.CurrentCultureIgnoreCase)
                .Select(x => new WordCountItem(x.Key.ToLower(), x.Count()));
            return ret;
        }
    }
}
