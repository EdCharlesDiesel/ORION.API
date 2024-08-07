using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MinimumWaitingTime.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] queries = new int[] { 3, 2, 1, 2, 6 };
            int expected = 17;
            var actual = new MinimumWaitingTimeClass().MinimumWaitingTime(queries);
            Assert.True(actual == expected);
        }
    }
}