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
        public IList<ReadFile> Files { get; }
        public IList<string> MergedData { get; }

        /// <summary>
        /// Instantiates a new instancen of the Merger class
        /// </summary>
        /// <param name="Files">The array of <see cref="ReadFile"/> to be merged</param>
        public Merger(ReadFile[] Files)
        {
            this.Files = Files;
        }

        /// <summary>
        /// Instantiates a new instancen of the Merger class
        /// </summary>
        /// <param name="Files">The List of <see cref="ReadFile"/> to be merged</param>
        public Merger(List<ReadFile> Files)
        {
            this.Files = Files;
        }

        /// <summary>
        /// Merges the contents of <see cref="Files"/> of this instance
        /// </summary>
        public void Merge()
        {
            foreach (var file in Files)
            {
                foreach (var word in file.Words)
                {
                    MergedData.Add(word);
                }
            }
        }

    }
}
