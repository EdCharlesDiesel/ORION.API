using NUnit.Framework;
using System.Linq;

namespace SmallestDifference.Tests
{
    public class SmallestDifferenceUnitTest
    {
        [Test]
        public void TestCase1()
        {
            int[] expected = { 28, 26 };
            Assert.IsTrue(Enumerable.SequenceEqual(
                 SmallestDifferenceClass.SmallestDifference(new int[] { -1, 5, 10, 20, 28, 3 }, new int[] { 26, 134, 135, 15, 17 }), expected));
        }
    }
}