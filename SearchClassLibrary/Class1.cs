using System;
using System.Collections.Generic;
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
        public List<string> ConvertString(List<IList<string>> file)
        {
            //List<string> text = file.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            //List<string> text = file.ToList<string>;
            //return text;
            List<string> result = new List<string>();
            foreach (var value in file)
            {
                //result.Add(value);
            }
            //List<string> result = file.ToList<string>;
            return result;
        }

        
        /// <summary>
        /// Using Linq to create a query to find the searched word within a text file. Input word can match captial letter and regular
        /// </summary>
        /// <param name="text">String array of extracted words</param>
        /// <param name="searchedWord">Searched word</param>
        /// <returns>Count of matched <paramref name="searchedWord"/> in <paramref name="text"/></returns>
        public int MatchOnSearchedWord(IList<string> text, string searchedWord)
        {
            var match = from word in text
                        where (word.ToLowerInvariant() == searchedWord.ToLowerInvariant()) && (word.ToUpperInvariant() == searchedWord.ToUpperInvariant())
                        select word;
            int count = match.Count();
            return count;

        }
    }
}
