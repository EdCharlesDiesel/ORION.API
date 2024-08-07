using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SpiralTraverse.Tests
{
    public class SpiralTraverseUnitTest
    {
        [Test]
        public void Test1()
        {
            int[,] input = {
            {1, 2, 3, 4},
            {12, 13, 14, 5},
            {11, 16, 15, 6},
            {10, 9, 8, 7},
            };

            var expected = new List<int> {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
            };

            var actual = SpiralTraverseClass.SpiralTraverse(input);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}