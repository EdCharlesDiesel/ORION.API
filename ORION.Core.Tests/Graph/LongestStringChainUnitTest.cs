using ORION.Core.Graphs;

namespace LongestStringChain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<string> strings = new List<string>(
     new[] { "abde", "abc", "abd", "abcde", "ade", "ae", "1abde", "abcdef" }
   );
            List<string> expected =
              new List<string>() { "abcdef", "abcde", "abde", "ade", "ae" };
            Assert.True(LongestStringChainClass.longeststringChain(strings).SequenceEqual(expected)
            );
        }
    }
}