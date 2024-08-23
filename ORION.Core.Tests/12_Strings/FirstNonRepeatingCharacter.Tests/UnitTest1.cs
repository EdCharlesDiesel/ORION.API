using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FirstNonRepeatingCharacter.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string input = "abcdcaf";
            int expected = 1;
            var actual = new FirstNonRepeatingCharacterClass().FirstNonRepeatingCharacter(input);
            Assert.True(expected == actual);
        }
    }
}