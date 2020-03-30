using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileTextSearcher
{
    public class FileWriter
    {
        /// <summary>
        /// Writes every value from the sorted list into a given file
        /// </summary>
        /// <param name="file">The file created in the SaveFile method to be written in</param>
        /// <param name="sortedListOfWords">IList of sorted words to write to a file</param>
        private void WriteToFile(StreamWriter file, IList<string> sortedListOfWords)
        {
            for (int i = 0; i < sortedListOfWords.Count(); i++)
            {
                if (sortedListOfWords[i] != null)
                {
                    file.WriteLine(sortedListOfWords[i]);
                }
            }
        }

        /// <summary>
        /// Takes filepath and filename as parameters and saves a sorted file as a .txt file
        /// </summary>
        /// <param name="filePath">Path to save in</param>
        /// <param name="newFileName">Name of file to save</param>
        /// <param name="sortedListOfWords">Data strucutre to write to file</param>

        public void SaveFile(string filePath, string newFileName, IList<string> sortedListOfWords)
        {
            Regex rx = new Regex("[<>\\?:*/\" |]");
            if (filePath == null || newFileName == null)
            {
                throw new ArgumentNullException("File path and file name cannot be null");
            }
            else if (!Directory.Exists(filePath))
            {
                throw new ArgumentException("Invalid file path");
            }
            else if (rx.IsMatch(newFileName))
            {
                throw new ArgumentException("Invalid character in file name");
            }
            else if (newFileName == "")
            {
                throw new ArgumentException("File name cannot be empty");
            }
            else if (sortedListOfWords == null || sortedListOfWords.Count() < 1)
            {
                throw new ArgumentException("Sorted list cannot be null or empty");
            }
            else
            {
                string newFilePath = Path.Combine(filePath, newFileName + ".txt");
                using (StreamWriter sw = new StreamWriter(newFilePath))
                {
                    WriteToFile(sw, sortedListOfWords);
                }
            }

        }

    }
}
