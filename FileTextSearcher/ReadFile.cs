using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTextSearcher
{
    public class ReadFile
    {
        public int NumberOfWords { get; private set; }
        public string FileName { get; private set; }
        public string[] Words { get; private set; }

        public ReadFile(string fileName, string fileContent)
        {
            Words = fileContent.Split(new[] { "\r\n", "\r", "\n", " " },StringSplitOptions.None);
            NumberOfWords = Words.Count();
            FileName = fileName;
        }
    }
}
