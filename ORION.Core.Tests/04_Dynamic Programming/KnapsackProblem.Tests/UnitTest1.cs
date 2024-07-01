namespace KnapsackProblem.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[,] input = { { 1, 2 }, { 4, 3 }, { 5, 6 }, { 6, 7 } };
            Tuple<int, int[]> expected = Tuple.Create(10, new int[] { 1, 3 });
            Assert.True(compare(KnapsackProblemClass.KnapsackProblem(input, 10), expected));
        }

        private static bool compare(List<List<int>> arr1, Tuple<int, int[]> arr2)
        {
            if (arr1[0][0] != arr2.Item1)
            {
                return false;
            }
            if (arr1[1].Count != arr2.Item2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1[1].Count; i++)
            {
                if (arr1[1][i] != arr2.Item2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}