using ORION.Core.Arrays;

namespace IndexEqualsValue.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(
              new IndexEqualsValueClass().IndexEqualsValue(new int[] { -5, -3, 0, 3, 4, 5, 9 }) == 3
            );

        }
    }
}