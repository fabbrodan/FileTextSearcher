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
        /// <param name="filePath">Desired file path</param>
        /// <param name="fileName">Desired file name</param>
        /// <param name="sortedListOfWords">Data strucutre to write to file</param>
        public void SaveFile(string filePath, string fileName, IList<string> sortedListOfWords)
        {
            try
            {
                if (filePath != null && fileName!=null && sortedListOfWords != null )
                {
                    if (fileName != "")
                    {
                        string newFilePath = Path.Combine(filePath, fileName + "_sorted.txt");
                        if (!File.Exists(newFilePath))
                        {
                            using (StreamWriter sw = new StreamWriter(newFilePath))
                            {
                                WriteToFile(sw, sortedListOfWords);
                            }
                        }
                        else
                        {
                            throw new ArgumentException();

                        }
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }
            catch (IOException e)
            {
                throw e;
            }

        }

    }
}
