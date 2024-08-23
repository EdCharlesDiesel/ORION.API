namespace LevenshteinDistance.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(LevenshteinDistanceClass.LevenshteinDistance("abc", "yabd") == 2);
        }
    }
}