
using System.Collections.Generic;

namespace PowerSet.Tests
{
    public class PowerSetUnitTest
    {

        [Fact]
        public void TestCase1()
        {
            //List<List<int>> output = PowerSet.Powerset(new List<int>(){1, 2, 3});
            //Assert.True(output.Count == 8);
            //Assert.True(Contains(output, new int[] { }));
            //Assert.True(Contains(output, new int[] { 1 }));
            //Assert.True(Contains(output, new int[] { 2 }));
            //Assert.True(Contains(output, new int[] { 1, 2 }));
            //Assert.True(Contains(output, new int[] { 3 }));
            //Assert.True(Contains(output, new int[] { 1, 3 }));
            //Assert.True(Contains(output, new int[] { 2, 3 }));
            //Assert.True(Contains(output, new int[] { 1, 2, 3 }));
        }

        public bool Contains(List<List<int>> arr1, int[] arr2)
        {
            foreach (List<int> subArr in arr1)
            {
                subArr.Sort();
                if (compare(subArr, arr2))
                {
                    return true;
                }
            }
            return false;
        }

        public bool compare(List<int> arr1, int[] arr2)
        {
            if (arr1.Count != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Count; i++)
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
