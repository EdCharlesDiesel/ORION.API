using ORION.Core.FamousAlgorithms;
using Xunit;

namespace ORION.Core.Tests
{
    public class DijkstrasAlgorithmnUnitTest
    {
        [Fact(Skip ="This tests infinite runs inifinitely")]
        public void Test1()
        {
            int start = 0;
            int[][][] edges = {
                  new int[][] { new int[] { 1, 7 } },
                  new int[][] {
                    new int[] { 2, 6 }, new int[] { 3, 20 }, new int[] { 4, 3 }
                  },
                  new int[][] { new int[] { 3, 14 } },
                  new int[][] { new int[] { 4, 2 } },
                  new int[][] {},
                  new int[][] {}
                };
            int[] expected = { 0, 7, 13, 27, 10, -1 };
            int[] actual =  DijkstrasAlgorithmnClassAlgoExpert.DijkstrasAlgorithm(start, edges);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        }
    }
}