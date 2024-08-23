using ORION.Core.Arrays;

namespace MergeOverlappingIntervals.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[][] intervals = new int[][] {
              new int[] { 1, 2 },
              new int[] { 3, 5 },
              new int[] { 4, 7 },
              new int[] { 6, 8 },
              new int[] { 9, 10 },
            };


            int[][] expected = new int[][] {
              new int[] { 1, 2 },
              new int[] { 3, 8 },
              new int[] { 9, 10 },
            };

            int[][] actual = new MergeOverlappingIntervalsClass().MergeOverlappingIntervals(intervals);
            for (int i = 0; i < actual.Length; i++)
            {
                for (int j = 0; j < actual[i].Length; j++)
                {
                    Assert.True(expected[i][j] == actual[i][j]);
                }
            }
        }
    }
}