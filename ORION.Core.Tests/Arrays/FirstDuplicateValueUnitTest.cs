using ORION.Core.Arrays;
using Xunit;

namespace FirstDuplicateValue.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var input = new int[] { 2, 1, 5, 2, 3, 3, 4 };
            var expected = 2;
            var actual = new FirstDuplicateValueClass().FirstDuplicateValue(input);
            Assert.True(expected == actual);
        }
    }
}