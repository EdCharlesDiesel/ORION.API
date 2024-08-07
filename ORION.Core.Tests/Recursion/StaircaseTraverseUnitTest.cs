using NUnit.Framework;

namespace StaircaseTraverse.Tests
{
    public class StaircaseTraverseUnitTest
    {
        [Test]
        public void Test1()
        {
            int stairs = 4;
            int maxSteps = 2;
            int expected = 5;
            int actual = StaircaseTraverse.StaircaseTraversal(stairs, maxSteps);
            Assert.True(expected == actual);
        }
    }
}