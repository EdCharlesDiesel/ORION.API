using ORION.Core.GreadyAlgorithmns;

namespace TandemBicycle.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int[] redShirtSpeeds = new int[] { 5, 5, 3, 9, 2 };
        int[] blueShirtSpeeds = new int[] { 3, 6, 7, 2, 1 };
        bool fastest = true;
        int expected = 32;
        var actual =
            new TandemBicycleClass().TandemBicycle(redShirtSpeeds, blueShirtSpeeds, fastest);
        Assert.True(expected == actual);
    }
}