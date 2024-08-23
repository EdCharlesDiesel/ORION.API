
using MonotonicArray;
using ORION.Core.Arrays;

namespace MonotonicArray.Tests
{
    public class Tests
    {    

        [Fact]
        public void Test1()
        {
            var array = new int[] { -1, -5, -10, -1100, -1100, -1101, -1102, -9001 };
            var actual = IsMonotonicClass.IsMonotonic(array);
           // Assert.That(actual, Is.EqualTo(true));
        }
    }
}