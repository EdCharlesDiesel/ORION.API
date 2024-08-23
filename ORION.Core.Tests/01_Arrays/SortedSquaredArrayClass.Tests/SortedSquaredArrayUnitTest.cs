using NUnit.Framework;
using SortedSquaredArray;

namespace SortedSquaredArrayClass.Tests
{
    public class SortedSquaredArrayUnitTest
    {
        [Test]
        public void Test1()
        {
            var input = new int[] { 1, 2, 3, 5, 6, 8, 9 };
            var expected = new int[] { 1, 4, 9, 25, 36, 64, 81 };
            var actual = new SortedSquaredArray.SortedSquaredArrayClass().SortedSquaredArray(input);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(expected[i] == actual[i]);
            }
        }
    }
}