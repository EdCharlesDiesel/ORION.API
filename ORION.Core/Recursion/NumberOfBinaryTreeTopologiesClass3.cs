using System.Collections.Generic;

namespace ORION.Core.Recursion
{
    internal class NumberOfBinaryTreeTopologiesClass3
    {
        // O(n^2) time | O(n) space
        public static int NumberOfBinaryTreeTopologies(int n)
        {
            List<int> cache = new List<int>();
            cache.Add(1);
            for (int m = 1; m < n + 1; m++)
            {
                int numberOfTrees = 0;
                for (int leftTreeSize = 0; leftTreeSize < m; leftTreeSize++)
                {
                    int rightTreeSize = m - 1 - leftTreeSize;
                    int numberOfLeftTrees = cache[leftTreeSize];
                    int numberOfRightTrees = cache[rightTreeSize];
                    numberOfTrees += numberOfLeftTrees * numberOfRightTrees;
                }
                cache.Add(numberOfTrees);
            }
            return cache[n];
        }
    }
}
