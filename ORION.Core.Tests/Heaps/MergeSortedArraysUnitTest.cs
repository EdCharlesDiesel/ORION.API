using ORION.Core.Heaps;

namespace ORION.Core.Tests.Heaps
{
    public class MergeSortedArraysUnitTest
    {
        [Fact]
        public void Test1()
        {
            var arrays = new List<List<int>> {
              new List<int> { 1, 5, 9, 21 },
              new List<int> { -1, 0 },
              new List<int> { -124, 81, 121 },
              new List<int> { 3, 6, 12, 20, 150 },
             };


            var actual = MergeSortedArraysClass.MergeSortedArrays(arrays);
            var expected =
              new List<int> { -124, -1, 0, 1, 3, 5, 6, 9, 12, 20, 21, 81, 121, 150 };
            Assert.True(Enumerable.SequenceEqual(expected, actual));
        }
    }
}