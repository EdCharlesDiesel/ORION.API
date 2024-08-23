using ORION.Core.DynamicProgramming;

namespace NumberOfWaysToMakeChange.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] input = { 1, 5 };
            Assert.True(NumberOfWaysToMakeChangeClass.NumberOfWaysToMakeChange(6, input) == 2);
        }
    }
}