using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfBinaryTreeTopologies
{
    internal class NumberOfBinaryTreeTopologiesClass2
    {
        // O(n^2) time | O(n) space
        public static int NumberOfBinaryTreeTopologiesClass(int n)
        {
            Dictionary<int, int> cache = new Dictionary<int, int>();
            cache.Add(0, 1);
            return NumberOfBinaryTreeTopologies(n, cache);
        }
        public static int NumberOfBinaryTreeTopologies(int n, Dictionary<int, int> cache)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            int numberOfTrees = 0;
            for (int leftTreeSize = 0; leftTreeSize < n; leftTreeSize++)
            {
                int rightTreeSize = n - 1 - leftTreeSize;
                int numberOfLeftTrees = NumberOfBinaryTreeTopologies(leftTreeSize, cache);
                int numberOfRightTrees = NumberOfBinaryTreeTopologies(rightTreeSize, cache);
                numberOfTrees += numberOfLeftTrees * numberOfRightTrees;
            }
            cache.Add(n, numberOfTrees);
            return numberOfTrees;
        }
    }
}
