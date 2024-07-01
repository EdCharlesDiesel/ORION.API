using System.Collections.Generic;

namespace ORION.Core.Recursion
{
    public class PermutationsClass
    {
        // Upper Bound: O(n^2*n!) time | O(n*n!) space
        // Roughly: O(n*n!) time | O(n*n!) space
        public static List<List<int>> GetPermutations(List<int> array)
        {
            List<List<int>> permutations = new List<List<int>>();
            GetPermutations(array, new List<int>(), permutations);
            return permutations;
        }
        public static void GetPermutations(List<int> array, List<int> currentPermutation,
        List<List<int>> permutations)
        {
            if (array.Count == 0 && currentPermutation.Count > 0)
            {
                permutations.Add(currentPermutation);
            }
            else
            {
                for (int i = 0; i < array.Count; i++)
                {
                    List<int> newArray = new List<int>(array);
                    newArray.RemoveAt(i);
                    List<int> newPermutation = new List<int>(currentPermutation);
                    newPermutation.Add(array[i]);
                    GetPermutations(newArray, newPermutation, permutations);
                }
            }
        }
    }
}