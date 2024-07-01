using NUnit.Framework;

namespace TransposeMatrix.Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            int[,] input = new int[3, 3] {
                {1,2,3},{4,5,6},{7,8,9}
            };
            int[,] expected = new int[3, 3] {
                {1,4,7},{2,5,8},{3,6,9}
            };

            int[,] actual = new TransposeMatrixClass().TransposeMatrix(input);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.True(expected[i, j] == actual[i, j]);
                }
            }
        }
    }
}