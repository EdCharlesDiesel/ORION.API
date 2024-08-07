
using ORION.Core.Recursion;

namespace RevealMinesweeper.Tests
{
    public class RevealMinesweeperUnitTests
    {
        [Fact]
        public void Test1()
        {
            string[][] board = new string[][] {
            new string[] {"H", "H", "H", "H", "M"},
            new string[] {"H", "H", "M", "H", "H"},
            new string[] {"H", "H", "H", "H", "H"},
            new string[] {"H", "H", "H", "H", "H"}
        };
            int row = 3;
            int column = 4;
            string[][] expected = new string[][] {
            new string[] {"0", "1", "H", "H", "M"},
            new string[] {"0", "1", "M", "2", "1"},
            new string[] {"0", "1", "1", "1", "0"},
            new string[] {"0", "0", "0", "0", "0"}
        };
            string[][] actual = new RevealMineSweeper().RevealMineSweeperMethod(board, row, column);

            Assert.True(expected.Length == actual.Length);
            Assert.True(expected[0].Length == actual[0].Length);

            for (int currRow = 0; currRow < expected.Length; currRow++)
            {
                for (int currColumn = 0; currColumn < expected[0].Length; currColumn++)
                {
                    Assert.True(expected[currRow][currColumn].Equals(actual[currRow][currColumn]));
                }
            }
        }
    }
}