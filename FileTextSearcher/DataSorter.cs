using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTextSearcher
{
    public class DataSorter<T>
    {
        /// <summary>
        /// The IEnumerable of <typeparamref name="T"/> this class instance will sort
        /// </summary>
        public IEnumerable<T> DataStruct { get; private set; }

        /// <summary>
        /// Creates a new instance of the class with <paramref name="DataList"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="DataList">The List of type <typeparamref name="T"/> to sort</param>
        public DataSorter(List<T> DataList)
        {
            DataStruct = DataList;
        }

        /// <summary>
        /// Creates a new instance of the class with <paramref name="DataArray"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="DataArray">The Array of type <typeparamref name="T"/> to sort</param>
        public DataSorter(T[] DataArray)
        {
            DataStruct = DataArray;
        }

        /// <summary>
        /// Sorts the IEnumerable of <typeparamref name="T"/> <paramref name="DataStruct"/> in ascending fashion
        /// </summary>
        public void SortAscending()
        {

        }

        /// <summary>
        /// Sorts the IEnumerable of <typeparamref name="T"/> <paramref name="DataStruct"/> in descending fashion
        /// </summary>
        public void SortDescending()
        {

        }

    }
}
