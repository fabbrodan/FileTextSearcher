using System;
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
        public void WriteToFile()
        {

        }

        /// <summary>
        /// Takes filepath and filename as parameters and saves a sorted file as a .txt file
        /// </summary>
        /// <param name="filePath">Desired path</param>
        /// <param name="newFileName">Desired filename</param>
        public void SaveFile(string filePath, string newFileName)
        {
            Regex rx = new Regex("[<>\\?:*/\" |]");
            if (filePath == null || newFileName == null)
            {
                throw new ArgumentNullException("File path and file name cannot be null");
            }
            else if (!Directory.Exists(filePath))
            {
                throw new ArgumentException("Invalid filepath");
            }
            else if (rx.IsMatch(newFileName))
            {
                throw new ArgumentException("Invalid character in file name");
            }
            else if (newFileName == "") {
                throw new ArgumentException("File name cannot be empty");

            }
            else
            {
                string newFilePath = Path.Combine(filePath, newFileName + ".txt");
                using (FileStream fs = File.Create(newFilePath))
                {
                    //write to file implementation
                    //write to file implementation
                }
            }

        }

    }
}
