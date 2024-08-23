using Xunit;
using ORION.Core.Arrays;

namespace ORION.Core.Arrays.Tests
{
    public class PrintMatrixClassTests
    {
        [Theory]
        [InlineData(4)]
        public void DoMatrixATest(int n)
        {

            // Arrange
            var expected = new[,] {

                  { 1, 5, 9,  13 },
                  { 2, 6, 10, 14 },
                  { 3, 7, 11, 15 },
                  { 4, 8, 12, 16 }
                };

            // Act
            var actual = PrintMatrixClass.DoMatrixA(n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4)]
        public void DoMatrixBTest(int n)
        {
            // Arrange
            var expected = new[,] {

                  { 1, 8, 9,  16 },
                  { 2, 7, 10, 15 },
                  { 3, 6, 11, 14 },
                  { 4, 5, 12, 13 }
                };

            // Act
            var actual = PrintMatrixClass.DoMatrixB(n);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}