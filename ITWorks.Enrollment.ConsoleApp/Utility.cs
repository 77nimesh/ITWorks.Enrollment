using System;

namespace ITWorks.Enrollment
{
    /// <summary>
    /// Generic searching and sorting helpers for arrays of comparable items.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Sequential (linear) search. Scans each element and returns the index of the first match; otherwise -1.
        /// </summary>
        /// <typeparam name="T">Any comparable type.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <param name="target">The value to find.</param>
        /// <returns>Index of target if found; otherwise -1.</returns>
        /// <remarks>
        /// Pseudocode:
        ///  i ← 0
        ///  while i < length(array) do
        ///      if array[i] == target then return i
        ///      i ← i + 1
        ///  end while
        ///  return -1
        /// </remarks>
        public static int LinearSearchArray<T>(T[] array, T target) where T : IComparable<T>
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].CompareTo(target) == 0)
                    return i;
            }
            return -1;
        }

        // Optional alias if your brief misspells "Search" as "Seach"
        public static int LinearSeachArray<T>(T[] array, T target) where T : IComparable<T>
            => LinearSearchArray(array, target);

        /// <summary>
        /// Binary search on a sorted (ascending) array. Returns index if found; otherwise -1.
        /// </summary>
        /// <typeparam name="T">Any comparable type.</typeparam>
        /// <param name="array">Array sorted in ascending order.</param>
        /// <param name="target">The value to locate.</param>
        /// <returns>Index of target if found; otherwise -1.</returns>
        /// <remarks>
        /// Pseudocode:
        ///  low ← 0; high ← n-1
        ///  while low ≤ high do
        ///      mid ← (low + high) / 2
        ///      if target == array[mid] then return mid
        ///      else if target < array[mid] then high ← mid - 1
        ///      else low ← mid + 1
        ///  end while
        ///  return -1
        /// </remarks>
        public static int BinarySearchArray<T>(T[] array, T target) where T : IComparable<T>
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int cmp = target.CompareTo(array[mid]);
                if (cmp == 0) return mid;
                if (cmp < 0) high = mid - 1; else low = mid + 1;
            }
            return -1;
        }

        /// <summary>
        /// Selection sort (ascending). Sorts the array in place.
        /// </summary>
        /// <typeparam name="T">Any comparable type.</typeparam>
        /// <param name="array">Array to sort (modified in place).</param>
        /// <remarks>
        /// Pseudocode:
        ///  for i = 0 to n-2
        ///     min = i
        ///     for j = i+1 to n-1
        ///        if array[j] < array[min] then min = j
        ///     end for
        ///     swap array[i], array[min]
        ///  end for
        /// </remarks>
        public static void SortArrayAscending<T>(T[] array) where T : IComparable<T>
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j].CompareTo(array[min]) < 0) min = j;

                if (min != i)
                {
                    T tmp = array[i];
                    array[i] = array[min];
                    array[min] = tmp;
                }
            }
        }

        /// <summary>
        /// Selection sort (descending). Sorts the array in place.
        /// </summary>
        /// <typeparam name="T">Any comparable type.</typeparam>
        /// <param name="array">Array to sort (modified in place).</param>
        /// <remarks>
        /// Pseudocode:
        ///  for i = 0 to n-2
        ///     max = i
        ///     for j = i+1 to n-1
        ///        if array[j] > array[max] then max = j
        ///     end for
        ///     swap array[i], array[max]
        ///  end for
        /// </remarks>
        public static void SortArrayDescending<T>(T[] array) where T : IComparable<T>
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            for (int i = 0; i < array.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j].CompareTo(array[max]) > 0) max = j;

                if (max != i)
                {
                    T tmp = array[i];
                    array[i] = array[max];
                    array[max] = tmp;
                }
            }
        }
    }
}
