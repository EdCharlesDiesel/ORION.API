using ORION.Core.Sorting;

namespace SelectionSort.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] expected = { 2, 3, 5, 5, 6, 8, 9 };
            int[] input = { 8, 5, 2, 9, 5, 6, 3 };
            Assert.True(compare(SelectionSortClass.SelectionSort(input), expected));
        }

        public bool compare(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}