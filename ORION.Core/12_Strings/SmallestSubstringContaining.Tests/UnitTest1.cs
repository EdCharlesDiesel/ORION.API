namespace SmallestSubstringContaining.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string bigstring = "abcd$ef$axb$c$";
            string smallstring = "$$abf";
            string expected = "f$axb$";
            Assert.True(SmallestSubstringContainingClass.SmallestSubstringContaining(bigstring, smallstring)
                                       .Equals(expected));
        }
    }
}
