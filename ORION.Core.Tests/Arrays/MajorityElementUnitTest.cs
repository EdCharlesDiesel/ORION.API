
using ORION.Core.Arrays;

namespace MajorityElement.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var input = new int[] { 1, 2, 3, 2, 2, 1, 2 };
            var expected = 2;
            var actual = new MajorityElementClass().MajorityElement(input);
            Assert.True(expected == actual);
        }
    }
}