using System.Collections.Generic;

namespace ORION.Core.Recursion
{
    /// <summary>
    /// Write a function that takes in an array of unique integers
    /// and returns its powerset.
    /// 
    /// the powerset P(X) of set X is the set of all subsets of X.
    /// For example, the powerset of [1,2] is [[],[1],[2],[1,2]].
    /// 
    /// note that the sets in the power set do not need to be
    /// in a particular order.
    /// </summary>
    public class PowerSet
    {
        #region SolutionOne
        public static List<List<int>> Powerset(List<int> inputArray)
        {
            return Powerset(inputArray, inputArray.Count - 1);
        }

        private static List<List<int>> Powerset(List<int> inputArray, int index)
        {
            if (index < 0)
            {
                List<List<int>> emptySet = new List<List<int>>();
                emptySet.Add(new List<int>());
                return emptySet;
            }

            int element = inputArray[index];
            List<List<int>> subsets = Powerset(inputArray, index - 1);
            int length = subsets.Count;
            for (int i = 0; i < length; i++)
            {
                List<int> currentSubset = new List<int>(subsets[i]);
                currentSubset.Add(element);
                subsets.Add(currentSubset);
            }
            return subsets;
        }
        #endregion

        #region SolutionTwo
        public static List<List<int>> PowerSetTwo(List<int> inputArray)
        {
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int>());
            foreach (var item in inputArray)
            {
                int length = subsets.Count;
                for (int i = 0; i < length; i++)
                {
                    List<int> currentSubset = new List<int>(subsets[i]);
                    currentSubset.Add(item);
                    subsets.Add(currentSubset);
                }
            }
            return subsets;
        }

        #endregion
    }
}