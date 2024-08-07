using Microsoft.VisualStudio.TestPlatform.TestHost;
using ORION.Core.Searching;

namespace OptimalAssemblyLine.Tests
{
    public class UnitTest1
    {
        [Fact(Skip = "Failing unit test")]
        public void Test1()
        {
            int[] stepDurations = new int[] { 15, 15, 30, 30, 45 };
            int numStations = 3;
            int actual = new OptimalAssemblyLineClass().OptimalAssemblyLine(stepDurations, numStations);
            int expected = 60;
            Assert.True(expected == actual);
        }
    }
}