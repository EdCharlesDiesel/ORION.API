using ORION.Core.DynamicProgramming;

namespace DiskStacking.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<int[]> input = new List<int[]>();
            input.Add(new int[] { 2, 1, 2 });
            input.Add(new int[] { 3, 2, 3 });
            input.Add(new int[] { 2, 2, 8 });
            input.Add(new int[] { 2, 3, 4 });
            input.Add(new int[] { 2, 2, 1 });
            input.Add(new int[] { 4, 4, 5 });
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] { 2, 1, 2 });
            expected.Add(new int[] { 3, 2, 3 });
            expected.Add(new int[] { 4, 4, 5 });
            Assert.True(compare(DiskStackingClass.DiskStacking(input), expected));
        }

        private static bool compare(List<int[]> arr1, List<int[]> arr2)
        {
            if (arr1.Count != arr2.Count)
            {
                return false;
            }
            for (int i = 0; i < arr1.Count; i++)
            {
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    if (!arr1[i][j].Equals(arr2[i][j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}