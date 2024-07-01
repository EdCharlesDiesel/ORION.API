using System;
using System.Collections.Generic;

namespace ORION.Core.Recursion
{
    /// <summary>
    /// Write a function that takes in a non-negative integer n
    /// and returns the number of possible Binary Tree topologies
    /// that can be created with the exactly n nodes. 
    /// 
    /// A Binary Tree  is defined as a Binary Tree configuration, 
    /// irrespetve of the nodes values. For instance, there exit 
    /// only two Binary Tree topologies where n is equal to 2: 
    /// a root node with a left node, and a right node.
    /// 
    /// Node that when n is equal to 0, there's one topology that
    /// can be created:the None/null node.
    /// </summary>
    public class NumberofBinaryTreeTopologiesClass
    {
        /// <summary>
        /// O(n^2) Time |O(n) space - where n is the inout number.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// 

        #region Solution One        
        public static int NumberofBinaryTreeTopologies(int n)
        {
            if (n == 0) return 1;

            int numberOfTrees = 0;
            for (int leftTreeSize = 0; leftTreeSize < n; leftTreeSize++)
            {
                int rightTreeSize = n - 1 - leftTreeSize;
                int numberOfLeftTrees = NumberofBinaryTreeTopologies(leftTreeSize);
                int numberOfRightTrees = NumberofBinaryTreeTopologies(rightTreeSize);
                numberOfTrees += numberOfLeftTrees * numberOfRightTrees;
            }
            return numberOfTrees;
        }
        #endregion

        #region Solution Two
        public static int NumberofBinaryTreeTopologiesSolutionTwo(int n)
        {
            Dictionary<int, int> cache = new Dictionary<int, int>();
            cache.Add(0, 1);
            return NumberofBinaryTreeTopologiesSolutionTwo(n, cache);
        }

        public static int NumberofBinaryTreeTopologiesSolutionTwo(int n, Dictionary<int, int> cache)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            int numberOfTrees = 0;
            for (int leftTreeSize = 0; leftTreeSize < n; leftTreeSize++)
            {
                int rightTreeSize = n - 1 - leftTreeSize;
                int numberOfLeftTrees = NumberofBinaryTreeTopologiesSolutionTwo(leftTreeSize, cache);
                int numberOfRightTrees = NumberofBinaryTreeTopologiesSolutionTwo(rightTreeSize,cache);
                numberOfTrees += numberOfLeftTrees * numberOfRightTrees;
            }
            cache.Add(n,numberOfTrees); 
            return numberOfTrees;   
        }
        #endregion

        #region Solution Three
        public static int NumberOfBinaryTreeTopologiesSolutionThree(int n)
        {
            List <int> cache = new List<int>();
            cache.Add(1);
            for (int m = 1; m < n; m++)
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
        #endregion
    }
}