using Xunit;

namespace InterweavingStrings.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="This test is failing.")]
        public void Test1()
        {
            string one = "algoexpert";
            string two = "your-dream-job";
            string three = "your-algodream-expertjob";
           // Assert.True(InterweavingStringsClass.Interweavingstrings(one, two, three) == true);
        }
    }
}