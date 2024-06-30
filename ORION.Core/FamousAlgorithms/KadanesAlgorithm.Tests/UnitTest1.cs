namespace KadanesAlgorithm.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] input = { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 };
            Assert.True(KadanesAlgorithmClass.KadanesAlgorithm(input) == 19);
        }
    }
}