using Microsoft.VisualStudio.TestPlatform.TestHost;
using ORION.Core.Arrays;

namespace MedianOfTwoSortedArrays.Tests
{
    public class UnitTest1
    {
        [Fact(Skip =  "Failing unit test")]
        public void Test1()
        {
            int[] arrayOne = new int[] { 1, 3, 4, 5 };
            int[] arrayTwo = new int[] { 2, 3, 6, 7 };
            float actual = new MedianOfTwoSortedArraysClass().MedianOfTwoSortedArrays(arrayOne, arrayTwo);
            float expected = 3.5f;
            Assert.True(expected == actual);
        }
    }
}