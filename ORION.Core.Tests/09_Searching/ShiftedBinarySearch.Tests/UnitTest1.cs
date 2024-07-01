namespace ShiftedBinarySearch.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(
                 ShiftedBinarySearchClass.ShiftedBinarySearch(
                   new int[] { 45, 61, 71, 72, 73, 0, 1, 21, 33, 37 }, 33
                 ) == 8
               );
        }
    }
}