using ORION.Core.Strings;

namespace CommonCharacters.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string[] input =  { "abc", "bcd", "cbad" };
            string[] expected = { "b", "c" };
            var actual = new CommonCharactersClass().CommonCharacters(input);
            Array.Sort(actual);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }
    }
}