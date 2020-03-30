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

        public void QuickSort()
        {
            int low = 0, high = DataStruct.Count - 1;

            QuickSort(low, high);
        }

        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(low, high);

                QuickSort(low, pi - 1);
                QuickSort(pi + 1, high);
            }
        }

        private int Partition(int low, int high)
        {
            T pivot = DataStruct[high];
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                int comparison = DataStruct[j].CompareTo(pivot);
                if (comparison < 0)
                {
                    i++;
                    T temp = DataStruct[i];
                    DataStruct[i] = DataStruct[j];
                    DataStruct[j] = temp;
                }
            }

            T temp2 = DataStruct[i + 1];
            DataStruct[i + 1] = DataStruct[high];
            DataStruct[high] = temp2;

            return i + 1;
        }
    }
}
