namespace MinNumberOfJumps.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] input = { 3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3 };
            Assert.True(MinNumberOfJumpsClass.MinNumberOfJumps(input) == 4);
        }
    }
}