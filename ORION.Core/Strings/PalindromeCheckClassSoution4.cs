namespace PalindromeCheck
{
    public class PalindromeCheckClassSoution4
    {
        // O(n) time | O(1) space
        public static bool IsPalindrome(string str)
        {
            int leftIdx = 0;
            int rightIdx = str.Length - 1;
            while (leftIdx < rightIdx)
            {
                if (str[leftIdx] != str[rightIdx])
                {
                    return false;
                }
                leftIdx++;
                rightIdx--;
            }
            return true;
        }
    }
}
