using ORION.Core.GreadyAlgorithmns;

namespace ValidStartingCity.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] distances = new int[] { 5, 25, 15, 10, 15 };
            int[] fuel = new int[] { 1, 2, 1, 0, 3 };
            int mpg = 10;
            int expected = 4;
            var actual = new ValidStartingCityClass().ValidStartingCity(distances, fuel, mpg);
          Assert.True(expected == actual);
        }
    }
}