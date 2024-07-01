using Xunit;

namespace LongestPeak.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input = new int[] { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 };
        var expected = 6;
        var actual = LongestPeakClass.LongestPeak(input);
        Assert.True(expected == actual);
    }
}