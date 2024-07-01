using System.Collections.Generic;

namespace SameBSTs
{
    public class SameBSTsClass
    {
        // O(n^2) time | O(n^2) space - where n is the number of
        // nodes in each array, respectively
        public static bool SameBsts(List<int> arrayOne, List<int> arrayTwo)
        {
            if (arrayOne.Count != arrayTwo.Count) return false;
            if (arrayOne.Count == 0 && arrayTwo.Count == 0) return true;
            if (arrayOne[0] != arrayTwo[0]) return false;
            List<int> leftOne = getSmaller(arrayOne);
            List<int> leftTwo = getSmaller(arrayTwo);
            List<int> rightOne = getBiggerOrEqual(arrayOne);
            List<int> rightTwo = getBiggerOrEqual(arrayTwo);
            return SameBsts(leftOne, leftTwo) && SameBsts(rightOne, rightTwo);
        }
        public static List<int> getSmaller(List<int> array)
        {
            List<int> smaller = new List<int>();
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] < array[0]) smaller.Add(array[i]);
            }
            return smaller;
        }
        public static List<int> getBiggerOrEqual(List<int> array)
        {
            List<int> biggerOrEqual = new List<int>();
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] >= array[0]) biggerOrEqual.Add(array[i]);
            }
            return biggerOrEqual;
        }
    }
}