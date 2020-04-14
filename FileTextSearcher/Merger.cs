using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileTextSearcher;

namespace FileTextSearcher
{
    public class Merger
    {
        public IList<FileToSave> Files { get; }
        private IList<string> MergedData;

        /// <summary>
        /// Instantiates a new instancen of the Merger class
        /// </summary>
        /// <param name="Files">The array of <see cref="FileToSave"/> to be merged</param>
        public Merger(FileToSave[] Files)
        {
            this.Files = Files;
        }

        /// <summary>
        /// Instantiates a new instancen of the Merger class
        /// </summary>
        /// <param name="Files">The List of <see cref="FileToSave"/> to be merged</param>
        public Merger(List<FileToSave> Files)
        {
            this.Files = Files;
        }

        /// <summary>
        /// Merges the contents of <see cref="Files"/> of this instance
        /// </summary>
        public IList<string> Merge()
        {
            MergedData = new List<string>();

            foreach (var file in Files)
            {
                foreach (var word in file.listOfWords)
                {
                    MergedData.Add(word);
                }
            }

            return MergedData;
        }

    }
}
