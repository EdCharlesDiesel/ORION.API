using System.Collections.Generic;

namespace ORION.Core.Recursion
{
    /// <summary>
    /// Write a function that takes an array of unique integers
    /// and returns an array of all permutations of those integers
    /// in no particular order.
    /// 
    /// if the input array is empty , the function should return an
    /// emnpty array.
    /// </summary>
    public class Permutations
    {
        // Time Complexity: O(n*n!) time -  O(n*n!) space - where n is
        // the length if the input array.

        #region SolutionOne
        public static List<List<int>> GetPermutations(List<int> inputArray)
        {
            List<List<int>> permutations = new List<List<int>>();
            GetPermutations(inputArray, new List<int>(), permutations);
            return permutations;
        }

        public static void GetPermutations(List<int> array, List<int> currentPermutations,
            List<List<int>> permutations)
        {
            if (array.Count == 0 && currentPermutations.Count> 0)
            {
                permutations.Add(currentPermutations);
            }
            else
            {
                for (int i = 0; i < array.Count; i++)
                {
                    List<int> newArray = new List<int>(array);
                    newArray.RemoveAt(i);
                    List<int> newPermutation = new List<int>(currentPermutations);
                    newPermutation.Add(array[i]);
                    GetPermutations(newArray,newPermutation, permutations);
                }
            }
        }
        #endregion

        #region SolutionTwo
        public static List<List<int>> GetPermutationsTwo(List<int> array)
        {
            List<List<int>> permutations = new List<List<int>>();
            GetPermutationsTwo(0, array, permutations);
            return permutations;
        }

        private static void GetPermutationsTwo(int v, List<int> array, List<List<int>> permutations)
        {
            if (v==array.Count -1)
            {
                permutations.Add(new List<int>(array));
            }
            else
            {
                for (int i = v; i < array.Count; i++)
                {
                    Swap(array, v, i);
                    GetPermutationsTwo(v+1,array, permutations);
                    Swap(array, v, i);
                }
            }
        }

        private static void Swap(List<int> array, int v, int i)
        {
            int tmp = array[v]; 
            array[v] = array[i];
            array[i] = tmp;    
        }
        #endregion
    }
}