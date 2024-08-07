using ORION.Core.Searching;

namespace FindThreeLargestNumbers.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] expected = { 18, 141, 541 };
            Assert.True(compare(
              FindThreeLargestNumbersClass.FindThreeLargestNumbers(
                new int[] { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 }
              ),
              expected
            ));
        }

        public bool compare(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}