﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            
            fileContent = Regex.Replace(fileContent, "[^a-zA-Z0-9._åäöÅÄÖ]", " ");
            Words = fileContent.Split(new[] { "\r\n", "\r", "\n", ".", "?", "!", " ", ";", ":", ",", "(", ")" },StringSplitOptions.RemoveEmptyEntries);
            NumberOfWords = Words.Count();
            FileName = fileName;
        }

    }
}
