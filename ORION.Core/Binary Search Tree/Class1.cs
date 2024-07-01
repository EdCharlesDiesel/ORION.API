using System.Collections.Generic;

namespace RightSmallerThan
{
    public class Class1
    {
        // O(n^2) time | O(n) space - where n is the length of the array
        public static List<int> RightSmallerThan(List<int> array)
        {
            List<int> rightSmallerCounts = new List<int>();
            for (int i = 0; i < array.Count; i++)
            {
                int rightSmallerCount = 0;
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[j] < array[i])
                    {
                        rightSmallerCount++;
                    }
                }
                rightSmallerCounts.Add(rightSmallerCount);
            }
            return rightSmallerCounts;
        }
    }
}