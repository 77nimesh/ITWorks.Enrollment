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
            try
            {
                if (array == null) throw new ArgumentNullException(nameof(array));
                int i = 0;
                bool found = false;
                while (!found && i < array.Length)
                {
                    if (array[i] != null && target.CompareTo(array[i]) == 0)
                        found = true;
                    else
                    {
                        i++;
                    }

                }
                if (i < array.Length)
                    return i;
                else
                    return -1;
            }
            catch (ArgumentNullException)
            {
                // Provide a clearer message for null array parameter while preserving exception type
                throw new ArgumentNullException(nameof(array), "Utility.LinearSearchArray: 'array' must not be null.");
            }
            catch (Exception ex)
            {
                // Wrap other exceptions to add context while preserving the original exception as inner
                throw new InvalidOperationException("Utility.LinearSearchArray failed. See inner exception for details.", ex);
            }
        }

       

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
            try
            {
                //Array.Sort(array);
                if (array == null) throw new ArgumentNullException(nameof(array));
                int min = 0;
                int max = array.Length - 1;
                int mid;
                do
                {
                    mid = (min + max) / 2;
                    if (array[mid].CompareTo(target) == 0)
                        return mid;
                    if (array[mid].CompareTo(target) < 0)

                        min = mid + 1;

                    else
                        max = mid - 1; 


                } while (min <= max);
                return -1;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(array), "Utility.BinarySearchArray: 'array' must not be null.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Utility.BinarySearchArray failed. See inner exception for details.", ex);
            }
        }


        /// <summary>
        /// Bubble Sort (ascending). Repeatedly steps through the array,
        /// compares adjacent elements and swaps them if they are in the wrong order.
        /// The pass through the array is repeated until the array is sorted.
        /// </summary>
        /// <typeparam name="T">Any comparable type.</typeparam>
        /// <param name="array">Array to be sorted in ascending order (modified in place).</param>
        /// <remarks>
        /// Pseudocode:
        ///  for pass = 0 to n - 2 do
        ///     for i = 0 to n - 2 do
        ///        if array[i] > array[i + 1] then
        ///            swap array[i] and array[i + 1]
        ///        end if
        ///     end for
        ///  end for
        /// </remarks>

        public static void SortArrayAscending<T>(T[] array) where T : IComparable<T>
        {
            try
            {
                if (array == null) throw new ArgumentNullException(nameof(array));
                T temp;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i].CompareTo(array[i + 1]) > 0)
                        {
                            temp = array[i + 1];
                            array[i + 1] = array[i];
                            array[i] = temp;
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(array), "Utility.SortArrayAscending: 'array' must not be null.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Utility.SortArrayAscending failed. See inner exception for details.", ex);
            }
        }



        /// <summary>
        /// Bubble Sort (descending). Repeatedly steps through the array,
        /// compares adjacent elements and swaps them if they are in the wrong order (larger first).
        /// The process continues until no more swaps are needed, resulting in a descending order.
        /// </summary>
        /// <typeparam name="T">Any comparable type.</typeparam>
        /// <param name="array">Array to be sorted in descending order (modified in place).</param>
        /// <remarks>
        /// Pseudocode:
        ///  for pass = 0 to n - 2 do
        ///     for i = 0 to n - 2 do
        ///        if array[i] < array[i + 1] then
        ///            swap array[i] and array[i + 1]
        ///        end if
        ///     end for
        ///  end for
        /// </remarks>

        public static void SortArrayDescending<T>(T[] array) where T : IComparable<T>
        {
            try
            {
                if (array == null) throw new ArgumentNullException(nameof(array));
                T temp;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i].CompareTo(array[i + 1]) < 0)
                        {
                            temp = array[i + 1];
                            array[i + 1] = array[i];
                            array[i] = temp;
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(array), "Utility.SortArrayDescending: 'array' must not be null.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Utility.SortArrayDescending failed. See inner exception for details.", ex);
            }
        }

    }
}
