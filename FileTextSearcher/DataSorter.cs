using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTextSearcher
{
    public class DataSorter<T> where T : IComparable
    {
        /// <summary>
        /// The IEnumerable of <typeparamref name="T"/> this class instance will sort
        /// </summary>
        public IList<T> DataStruct { get; private set; }

        /// <summary>
        /// Creates a new instance of the class with <paramref name="DataIList"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="DataIList">The IList of type <typeparamref name="T"/> to sort</param>
        public DataSorter(IList<T> DataIList)
        {
            DataStruct = DataIList;
        }

        /// <summary>
        /// Sorts the IEnumerable of <typeparamref name="T"/> <paramref name="DataStruct"/> in ascending fashion
        /// </summary>
        public void SortAscending()
        {
            DataStruct = DataStruct.OrderBy(s => s).ToList();
        }

        /// <summary>
        /// Sorts the IEnumerable of <typeparamref name="T"/> <paramref name="DataStruct"/> in descending fashion
        /// </summary>
        public void SortDescending()
        {
            DataStruct = DataStruct.OrderByDescending(s => s).ToList();
        }
    }
}
