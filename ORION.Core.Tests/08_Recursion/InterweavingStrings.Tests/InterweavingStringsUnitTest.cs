using NUnit.Framework;

namespace InterweavingStrings.Tests
{
    public class Tests
    {
        [Test]
        public void TestCase1()
        {
            string one = "algoexpert";
            string two = "your-dream-job";
            string three = "your-algodream-expertjob";
            Assert.True(InterweavingStrings.Interweavingstrings(one, two, three) == true);
        }
    }
}