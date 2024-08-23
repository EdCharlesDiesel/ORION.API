

using System;
using System.Collections.Generic;

namespace ORION.Core.Arrays
{
    /// <summary>
    /// Write a function that takes in a non-empty array of distinct integers and an integer
    /// representing a target sum. the function should find all triplets in the array that sum
    /// up to the target  sum and returns a two-dimentional array of all these triplets. The 
    /// numbers in each triplet should be ordered in ascending order, and the troplets themselves
    /// should be ordered in ascending order with respect to the number the hold.
    /// 
    /// If nonthree numbers sum up to the target sum, the function should return an empty array.
    /// </summary>
    public static class ThreeNumberSumClass
    {
        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            List<int[]> triplets = new List<int[]>();
            for (int i = 0; i < array.Length -2; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;
                while (left < right) {
                 int currentSum = array[i] + array[left] + array[right]; 
                    if (currentSum == targetSum)
                    {
                        int[] newTriplet = { array[i], array[left], array[right] };
                        triplets.Add(newTriplet);
                        left++;
                        right--;
                    }
                    else if (currentSum < targetSum) 
                    {
                        left++;
                    }
                    else if(currentSum > targetSum)
                    {
                        right--;
                    }
                }
            }

            return triplets;
        }
    }
}



