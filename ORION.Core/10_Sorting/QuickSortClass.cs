
namespace QuickSort
{
    public class QuickSortClass
    {
        // Best: O(nlog(n)) time | O(log(n)) space
        // Average: O(nlog(n)) time | O(log(n)) space
        // Worst: O(n^2) time | O(log(n)) space
        public static int[] QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
            return array;
        }
        public static void QuickSort(int[] array, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
            {
                return;
            }
            int pivotIdx = startIdx;
            int leftIdx = startIdx + 1;
            int rightIdx = endIdx;
            while (rightIdx >= leftIdx)
            {
                if (array[leftIdx] > array[pivotIdx] && array[rightIdx] < array[pivotIdx])
                {
                    swap(leftIdx, rightIdx, array);
                }
                if (array[leftIdx] <= array[pivotIdx])
                {
                    leftIdx += 1;
                }
                if (array[rightIdx] >= array[pivotIdx])
                {
                    rightIdx -= 1;
                }
            }
            swap(pivotIdx, rightIdx, array);
            bool leftSubarrayIsSmaller = rightIdx - 1 - startIdx < endIdx - (rightIdx + 1);
            if (leftSubarrayIsSmaller)
            {
                QuickSort(array, startIdx, rightIdx - 1);
                QuickSort(array, rightIdx + 1, endIdx);
            }
            else
            {
                QuickSort(array, rightIdx + 1, endIdx);
                QuickSort(array, startIdx, rightIdx - 1);
            }
        }
        public static void swap(int i, int j, int[] array)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}