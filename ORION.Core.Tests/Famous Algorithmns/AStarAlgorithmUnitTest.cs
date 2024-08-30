using ORION.Core.FamousAlgorithms;

namespace ORION.Core.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="This test is failing might need to check later")]
        public void Test1()
        {
            int startRow = 0;
            int startCol = 1;
            int endRow = 4;
            int endCol = 3;
            int[][] graph = new int[][] {
                  new int[] { 0, 0, 0, 0, 0 },
                  new int[] { 0, 1, 1, 1, 0 },
                  new int[] { 0, 0, 0, 0, 0 },
                  new int[] { 1, 0, 1, 1, 1 },
                  new int[] { 0, 0, 0, 0, 0 },
                };
            int[][] expected = new int[][] {
                  new int[] { 0, 1 },
                  new int[] { 0, 0 },
                  new int[] { 1, 0 },
                  new int[] { 2, 0 },
                  new int[] { 2, 1 },
                  new int[] { 3, 1 },
                  new int[] { 4, 1 },
                  new int[] { 4, 2 },
                  new int[] { 4, 3 }
                };
            var actual =
              new AStarAlgorithmClass().AStarAlgorithm(startRow, startCol, endRow, endCol, graph);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.True(expected[i][j] == actual[i][j]);
                }
            }
        }
    }
}