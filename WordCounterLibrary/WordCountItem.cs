
namespace WordCounterLibrary
{
    public class WordCountItem
    {
        public WordCountItem(string word, int count)
        {
            Word = word;
            Count = count;
        }

        public string Word { get; private set; }

        public int Count { get; private set; }
    }
}
