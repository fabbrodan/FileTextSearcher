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
        /// The IList of <typeparamref name="T"/> this class instance will sort
        /// </summary>
        private IList<T> DataStruct;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The DataList of this instance of DataSorter</returns>
        public IList<T> Get()
        {
            return DataStruct;
        }

        /// <summary>
        /// Creates a new instance of the class with <paramref name="DataIList"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="DataIList">The IList of type <typeparamref name="T"/> to sort</param>
        public DataSorter(IList<T> DataIList)
        {
            DataStruct = DataIList;
        }

        /// <summary>
        /// Sorts the IList of <typeparamref name="T"/> <paramref name="DataStruct"/> in ascending fashion
        /// </summary>
        public void SortAscending()
        {
            DataStruct = DataStruct.OrderBy(s => s).ToList();
        }

        /// <summary>
        /// Sorts the IList of <typeparamref name="T"/> <paramref name="DataStruct"/> in descending fashion
        /// </summary>
        public void SortDescending()
        {
            DataStruct = DataStruct.OrderByDescending(s => s).ToList();
        }

        /// <summary>
        /// Uses Quick Sort algorithm to sort the <paramref name="DataStruct"/> in ascending fashion
        /// </summary>
        public void QuickSortAscending()
        {
            int low = 0, high = DataStruct.Count - 1;

            QuickSortAscending(low, high);
        }

        /// <summary>
        /// Internal method for Quick sorting used for recursion
        /// </summary>
        /// <param name="low">The low boundary index for quick sort algorithm</param>
        /// <param name="high">The high boundary index for quick sort algorithm</param>
        private void QuickSortAscending(int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionAscending(low, high);

                QuickSortAscending(low, pi - 1);
                QuickSortAscending(pi + 1, high);
            }
        }

        /// <summary>
        /// The partitioning method used recursively by quick sort to switch elements and provide new pivot index
        /// </summary>
        /// <param name="low">The low boundary index for the sub list to be partitioned</param>
        /// <param name="high">The high boundary index for the sub list to be partitioned</param>
        /// <returns>Next partition index in full list</returns>
        private int PartitionAscending(int low, int high)
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

        /// <summary>
        /// Uses Quick Sort algorithm to sort the <paramref name="DataStruct"/> in descending fashion
        /// </summary>
        public void QuickSortDescending()
        {
            int low = 0, high = DataStruct.Count - 1;

            QuickSortDescending(low, high);
        }

        /// <summary>
        /// Internal method for Quick sorting used for recursion
        /// </summary>
        /// <param name="low">The low boundary index for quick sort algorithm</param>
        /// <param name="high">The high boundary index for quick sort algorithm</param>
        private void QuickSortDescending(int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionDescending(low, high);

                QuickSortDescending(low, pi - 1);
                QuickSortDescending(pi + 1, high);
            }
        }

        /// <summary>
        /// The partitioning method used recursively by quick sort to switch elements and provide new pivot index
        /// </summary>
        /// <param name="low">The low boundary index for the sub list to be partitioned</param>
        /// <param name="high">The high boundary index for the sub list to be partitioned</param>
        /// <returns>Next partition index in full list</returns>
        private int PartitionDescending(int low, int high)
        {
            T pivot = DataStruct[high];
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                int comparison = DataStruct[j].CompareTo(pivot);
                if (comparison > 0)
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
