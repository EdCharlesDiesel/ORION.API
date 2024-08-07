
using ORION.Core.Arrays;

namespace NonConstructibleChange.Tests
{
    public class Tests
    {   

        [Fact]
        public void Test1()
        {
            int[] input = new int[] { 5, 7, 1, 1, 2, 3, 22 };
            int expected = 20;
            var actual = new NonConstructibleChangeClass().NonConstructibleChange(input);
            Assert.True(expected == actual);
        }
    }
}