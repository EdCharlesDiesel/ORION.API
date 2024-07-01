using NUnit.Framework;

namespace AmbiguousMeasurements.Tests
{
    public class AmbiguousMeasurementsUnitTest
    {
        [Test]
        public void Test1()
        {
            int[][] cups = new int[][] {
            new int[] { 200, 210 }, new int[] { 450, 465 }, new int[] { 800, 850 }
        };
            int low = 2100;
            int high = 2300;
            bool expected = true;
            var actual = new AmbiguousMeasurementsClass().AmbiguousMeasurements(cups, low, high);
            Assert.True(expected == actual);
        }
    }
}