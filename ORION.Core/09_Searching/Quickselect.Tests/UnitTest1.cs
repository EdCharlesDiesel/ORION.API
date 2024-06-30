namespace Quickselect.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(
              QuickselectClass.Quickselect(new int[] { 8, 5, 2, 9, 7, 6, 3 }, 3) == 5
            );
        }
    }
}