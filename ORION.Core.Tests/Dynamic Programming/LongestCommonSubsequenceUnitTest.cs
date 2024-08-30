namespace LongestCommonSubsequence.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="Fix this")]
        public void Test1()
        {
            //char[] expected = { 'X', 'Y', 'Z', 'W' };
            //Assert.True(
            //  compare(LongestCommonSubsequenceClass.LongestCommonSubsequence("ZXVVYZW", "XKYKZPW"), expected)
            //);
        }

        private static bool compare(List<char> arr1, char[] arr2)
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