namespace ValidateSubsequence
{
    /// <summary>
    /// Given two non-empty array of integers, write a function that determines whether the second
    /// array is a subsequence of the first one.
    /// 
    /// A subsequence of an array is a set of numbers that aren't necessarily adjacent in the array 
    /// but that are in the same order as they appear in the array. Fo instance, the number [1,3,4]
    /// form a subsequence of an array [1,2,3,4]. and so do the number [2,4]. note that a single 
    /// number in an array and the array itself are both valid subsequence of the array.
    /// </summary>
    public static class ValidateSubsequenceClass
    {
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            var sequenceIndex = 0;
            foreach (var val in array)
            {
                if (sequenceIndex == sequence.Count)
                {
                    break;
                }

                if (sequence[sequenceIndex] == val)
                {
                    sequenceIndex++;
                }
            }
            return sequenceIndex == sequence.Count;
        }
    }
}