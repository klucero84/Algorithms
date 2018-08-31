using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Sorting Algorithm that uses swaps of adjacent pairs in a loop, until a full scan shows no out of alignment pairs. Best(n), Avg(n^2), Worst(n^2), Memory(1).
    /// </summary>
    /// <typeparam name="T">T implements IComparable aka something we can compare</typeparam>
    public class BubbleSort<T> where T : IComparable
    {
        /// <summary>
        /// Accepts array of T where T implements IComparable returns that array sorted.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <returns>the 'array' parameter, sorted.</returns>
        public static T[] Sort(T[] array) {

            ///do we need to swap one or more items?
            ///first time is a must to verify best case of presorted.
            var repeat = true;

            while (repeat)
            {
                ///if no unsorted pairs found leave loop
                repeat = false;

                ///skip last item
                for (int i = 0; i < array.Length - 1; i++)
                {
                    ///compare adjacent items 
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        ///swap
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        repeat = true;
                    }
                }
            }
            return array;
        }
    }
}
