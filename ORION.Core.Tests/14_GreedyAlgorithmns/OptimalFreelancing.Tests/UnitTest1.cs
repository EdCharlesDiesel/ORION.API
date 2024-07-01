using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace OptimalFreelancing.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Dictionary<string, int>[] input = new Dictionary<string, int>[1];
            Dictionary<string, int> job = new Dictionary<string, int>();
            job["deadline"] = 1;
            job["payment"] = 1;
            input[0] = job;
            var expected = 1;
            var actual = new OptimalFreelancingClass().OptimalFreelancing(input);
            Assert.True(expected == actual);
        }
    }
}