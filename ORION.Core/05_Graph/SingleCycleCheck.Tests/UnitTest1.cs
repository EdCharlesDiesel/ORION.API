namespace SingleCycleCheck.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
           Assert.True(SingleCycleCheckClass.HasSingleCycle(new int[] { 2, 3, 1, -4, -4, 2 }));
        }
    }
}