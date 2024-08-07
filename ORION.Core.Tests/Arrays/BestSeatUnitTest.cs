using ORION.Core.Arrays;

namespace BestSeat.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var input = new int[] { 1, 0, 1, 0, 0, 0, 1 };
            var expected = 4;
            var actual = new BestSeatClass().BestSeat(input);
            Assert.True(expected == actual);
        }
    }
}