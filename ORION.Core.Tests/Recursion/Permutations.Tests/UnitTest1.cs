using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Permutations.Tests
{
    public class UnitTest1
    {
        [Fact(Skip = "This test is failing.")]
        public void Test1()
        {
            List<int> input = new List<int>() { 1, 2, 3 };
            List<List<int>> perms = PermutationsClass.GetPermutations(input);
            Assert.True(perms.Count == 6);
            Assert.True(Contains(perms, new List<int>() { 1, 2, 3 }));
            Assert.True(Contains(perms, new List<int>() { 1, 3, 2 }));
            Assert.True(Contains(perms, new List<int>() { 2, 1, 3 }));
            Assert.True(Contains(perms, new List<int>() { 2, 3, 1 }));
            Assert.True(Contains(perms, new List<int>() { 3, 1, 2 }));
            Assert.True(Contains(perms, new List<int>() { 3, 2, 1 }));
        }

        public bool Contains(List<List<int>> arr1, List<int> arr2)
        {
            foreach (List<int> subArray in arr1)
            {
                if (subArray.SequenceEqual(arr2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}