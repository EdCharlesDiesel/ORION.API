namespace PalindromeCheck.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(PalindromeCheckClass.IsPalindrome("abcdcba"));
        }
    }
}