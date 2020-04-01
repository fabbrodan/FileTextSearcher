using System;
using System.Linq;

namespace SearchClassLibrary
{
    public class SearchClass
    {
        public SearchClass()
        {

        }

        //Method to convert string of text to an array of words
        public string[] ConvertString(string file)
        {
            string[] text = file.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return text;
        }

        //Using Linq to create a query to find the searched word within a text file. Input word can match captial letter and regular.
        public int MatchOnSearchedWord(string[] text, string searchedWord)
        {
            var match = from word in text
                        where (word.ToLowerInvariant() == searchedWord.ToLowerInvariant()) && (word.ToUpperInvariant() == searchedWord.ToUpperInvariant())
                        select word;
            int count = match.Count();
            return count;

        }
    }
}
