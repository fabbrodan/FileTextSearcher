using System;
using System.Linq;

namespace SearchClassLibrary
{
    public class SearchClass
    {
        public SearchClass()
        {

        }

        
        /// <summary>
        /// Method to convert string of text to an array of words
        /// </summary>
        /// <param name="file">Text from text document</param>
        /// <returns>String array containing extracted words from <paramref name="file"/></returns>
        public string[] ConvertString(string file)
        {
            string[] text = file.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return text;
        }

        
        /// <summary>
        /// Using Linq to create a query to find the searched word within a text file. Input word can match captial letter and regular
        /// </summary>
        /// <param name="text">String array of extracted words</param>
        /// <param name="searchedWord">Searched word</param>
        /// <returns>Count of matched <paramref name="searchedWord"/> in <paramref name="text"/></returns>
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
