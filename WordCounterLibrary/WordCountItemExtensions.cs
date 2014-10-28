using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public static class WordCountItemExtensions
    {
        public static string ToDisplayString(this IEnumerable<WordCountItem> items)
        {
            var display =items.Aggregate(new StringBuilder(), (builder, x) => builder.AppendFormat("{0}\t- {1}\n", x.Word, x.Count)).ToString();
            return display;
        }
    }
}
