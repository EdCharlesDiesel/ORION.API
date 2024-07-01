namespace UnderscorifySubstring.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string expected =
    "_test_this is a _testtest_ to see if _testestest_ it works";
            string output = UnderscorifySubstringClass.UnderscorifySubstring(
              "testthis is a testtest to see if testestest it works", "test"
            );
            Assert.True(expected.Equals(output));
        }
    }
}