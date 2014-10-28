using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WordCounterLibrary;

namespace WordCounter.ViewModel
{
    public class WordCounterViewModel : BindableBase
    {
        static readonly char[] defaultSeperators = new char[] { ' ', '\n', ',', '.' };
        private string seperatorString;
        private string sentence;
        private string display;
        private char[] seperators;
        public WordCounterViewModel()
        {
            CountCommand = new DelegateCommand(ExecuteCount, CanExecuteCount);
            this.seperators = defaultSeperators;
        }

        public DelegateCommand CountCommand { get; private set; }

        public string SeperatorString
        {
            get
            {
                return this.seperatorString;
            }

            set
            {
                bool changed = SetProperty(ref this.seperatorString, value);
                if(changed)
                {
                    if(string.IsNullOrWhiteSpace(this.seperatorString))
                    {
                        seperators = defaultSeperators;
                    }
                    else
                    {
                        var newSeperators = this.seperatorString
                            .Where(x=>!char.IsWhiteSpace(x))
                            .Distinct()
                            .ToArray();
                        seperators = new char[defaultSeperators.Length + newSeperators.Length];
                        defaultSeperators.CopyTo(seperators, 0);
                        newSeperators.CopyTo(seperators, defaultSeperators.Length);
                    }
                    
                    CountCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Sentence
        {
            get
            {
                return this.sentence;
            }

            set
            {
                bool changed = SetProperty(ref this.sentence, value);
                if (changed)
                {
                    CountCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Display
        {
            get
            {
                return this.display;
            }
            
            set
            {
                SetProperty(ref this.display, value);
            }
        }

        private void ExecuteCount()
        {
            WordCounterLibrary.WordCounter wc = new WordCounterLibrary.WordCounter(this.seperators);
            var wordCounts = wc.GetWordCounts(this.sentence);
            this.Display = wordCounts.ToDisplayString();
        }

        private bool CanExecuteCount()
        {
            return !string.IsNullOrWhiteSpace(Sentence);
        }
    }
}
