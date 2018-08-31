using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{   /// <summary>
    /// Divide and Conquer sorting algorithm that separates the array into half recursively then merges them together by putting them into a new array in order. Best(n log(n)), Avg(n log(n)), Worst(n log(n)), Memory(n).
    /// </summary>
    /// <typeparam name="T">a sortable reference type</typeparam>
    public class MergeSort<T> where T : IComparable
    {
        /// <summary>
        /// Divide and Conquer sorting algorithm that separates the array into half recursively then merges them together by putting them into a new array in order. Best(n log(n)), Avg(n log(n)), Worst(n log(n)), Memory(n).
        /// </summary>
        /// <param name="array">The Array of reference types, that implement IComparable, to be sorted.</param>
        /// <returns>The input array sorted by its comparable impelmentation.</returns>
        public static T[] Sort(T[] array)
        {
            Partition(array, 0, array.Length - 1);
            return array;
        }

        /// <summary>
        /// Recursive 'partions' dividing the array in half each time until at single item (but really with indices). then merges together, in order in a new array.
        /// </summary>
        /// <param name="array">The Array of reference types, that implement IComparable, to be sorted.</param>
        /// <param name="leftIndex">left bounds</param>
        /// <param name="rightIndex">right bounds</param>
        private static void Partition(T[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < 0 || rightIndex < 0 || (rightIndex - leftIndex + 1) < 2)
            {
                return;
            }

            var middle = (leftIndex + rightIndex) / 2;

            Partition(array, leftIndex, middle);
            Partition(array, middle + 1, rightIndex);

            Merge(array, leftIndex, middle, rightIndex);
        }

        /// <summary>
        /// Merge the two sorted arrays to make an even bigger even more sorted array.
        /// </summary>
        /// <param name="array">The Array of reference types, that implement IComparable, to be sorted.</param>
        /// <param name="leftStart">left bounds of current array segment</param>
        /// <param name="middle">middle of current array segment</param>
        /// <param name="rightEnd">left bounds of current array segment</param>
        private static void Merge(T[] array, int leftStart, int middle, int rightEnd)
        {
            var newLength = rightEnd - leftStart + 1;

            var result = new T[newLength];

            int i = leftStart, j = middle + 1, k = 0;
            //iteratively compare and pick min to result
            while (i <= middle && j <= rightEnd)
            {
                if (array[i].CompareTo(array[j]) < 0)
                {
                    result[k] = array[i];
                    i++;
                }
                else
                {
                    result[k] = array[j];
                    j++;
                }
                k++;
            }

            //copy left overs
            if (i <= middle)
            {
                for (var l = i; l <= middle; l++)
                {
                    result[k] = array[l];
                    k++;
                }
            }
            else
            {
                for (var l = j; l <= rightEnd; l++)
                {
                    result[k] = array[l];
                    k++;
                }
            }

            k = 0;
            //now write back result
            for (var g = leftStart; g <= rightEnd; g++)
            {
                array[g] = result[k];
                k++;
            }
        }
    }
}
