using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTextSearcher
{
    public class FileToSave
    {
        public string path;
        public string name;
        public IList<string> listOfWords;

        public FileToSave(string pathOfFile, string nameOfFile, IList<string> listOfWordsInFile)
        {
            path = pathOfFile;
            name = nameOfFile;
            listOfWords = listOfWordsInFile;
        }
    }
}
