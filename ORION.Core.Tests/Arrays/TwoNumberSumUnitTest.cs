using NUnit.Framework;
using System;

namespace TwoNumberSum.Tests
{
    public class TwoNumberSumUnitTest
    {
        [Test]
        public void Test1()
        {
            int[] output = new TwoNumberSumClass().TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10);
            Assert.IsTrue(output.Length == 2);
            Assert.IsTrue(Array.Exists(output, e => e == -1));
            Assert.IsTrue(Array.Exists(output, e => e == 11));
        }
    }
}