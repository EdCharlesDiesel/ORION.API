using System.Collections.Generic;

namespace ZeroSumSubarray
{
    /// <summary>
    /// You're given a list of integer nums. Write a function that returns a boolean representing
    /// whether there exists a zero-sum subarray of nums.
    /// 
    /// A Zero-sum subarray is any subarray where all of the values add up to zero. A subarray is
    /// any contiguous section of the array. For the purposes of this problem, a subarray can be
    /// as small as one element and as long as the original array
    /// 
    /// </summary>
    public class ZeroSumSubarrayClass
    {
        public bool ZeroSumSubarray(IEnumerable<int> nums)
        {
            var sums = new HashSet<int> {0};
            foreach (var i in nums)
            {
                if (sums.Contains(i)) 
                {
                    return true;
                }
                sums.Add(i);
            }

            return false;
        }
    }
}