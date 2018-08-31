using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Sorting Algorithm that inserts each item into a relatively sorted position at the start of the array. Best(n), Avg(n^2), Worst(n^2), Memory(1).
    /// </summary>
    /// <typeparam name="T">T implements IComparable aka something we can compare</typeparam>
    public class InsertionSort<T> where T : IComparable
    {
        /// <summary>
        /// Accepts array of T where T implements IComparable returns that array sorted.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <returns>the 'array' parameter, sorted.</returns>
        public static T[] Sort(T[] array)
        {
            ///start at front, skip last item
            for (int i = 0; i < array.Length - 1; i++)
            {
                ///sort behind us
                for (int j = i + 1; j > 0; j--)
                {
                    ///if item belongs in front of previous one
                    if (array[j].CompareTo(array[j-1]) < 0)
                    {
                        ///swap item backwards
                        var temp = array[j-1];
                        array[j-1] = array[j];
                        array[j] = temp;
                    }
                    ///all items behind us are sorted
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }
    }
}
