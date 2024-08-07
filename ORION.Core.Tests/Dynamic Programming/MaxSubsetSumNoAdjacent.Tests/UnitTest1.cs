namespace MaxSubsetSumNoAdjacent.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] input = { 75, 105, 120, 75, 90, 135 };
            Assert.True(MaxSubsetSumNoAdjacentClass.MaxSubsetSumNoAdjacent(input) == 330);
        }
    }
}