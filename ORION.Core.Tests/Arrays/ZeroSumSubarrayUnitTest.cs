using ORION.Core.Arrays;

namespace ZeroSumSubarray.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var input = new int[] { 4, 2, -1, -1, 3 };
            var expected = true;
            var actual = new ZeroSumSubarrayClass().ZeroSumSubarray(input);
            Assert.True(expected == actual);
        }
    }
}