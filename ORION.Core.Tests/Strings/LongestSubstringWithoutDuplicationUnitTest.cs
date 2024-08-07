namespace LongestSubstringWithoutDuplication.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(LongestSubstringWithoutDuplicationClass.LongestSubstringWithoutDuplication("clementisacap")
                    .Equals("mentisac"));
        }
    }
}