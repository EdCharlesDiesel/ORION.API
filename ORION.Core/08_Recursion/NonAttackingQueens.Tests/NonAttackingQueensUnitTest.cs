using NUnit.Framework;

namespace NonAttackingQueens.Tests
{
    public class NonAttackingQueensUnitTest
    {
        [Test]
        public void TestCaseSolution1()
        {
            var input = 4;
            var expected = 2;
            var actual_ = new NonAttackingQueensClass();
           var actual = actual_.NonAttachingQueens(input);
                
            Assert.IsTrue(expected == actual);
        }
    }
}