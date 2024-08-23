namespace ORION.Core.Searching
{
    internal class SearchForRangeClass2
    {
        // O(log(n)) time | O(1) space
        public static int[] SearchForRange(int[] array, int target)
        {
            int[] finalRange = { -1, -1 };
            alteredBinarySearch(array, target, 0, array.Length - 1, finalRange, true);
            alteredBinarySearch(array, target, 0, array.Length - 1, finalRange, false);
            return finalRange;
        }
        public static void alteredBinarySearch(int[] array, int target, int left, int right,
        int[] finalRange, bool goLeft)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else if (array[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    if (goLeft)
                    {
                        if (mid == 0 || array[mid - 1] != target)
                        {
                            finalRange[0] = mid;
                            return;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    else
                    {
                        if (mid == array.Length - 1 || array[mid + 1] != target)
                        {
                            finalRange[1] = mid;
                            return;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                }
            }
        }
    }
}
