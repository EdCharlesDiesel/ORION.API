namespace ORION.Core.Strings
{
    /// <summary>
    /// 
    /// </summary>
    public class PalindromeCheckClass
    {
        // O(n^2) time | O(n) space
        public static bool IsPalindrome(string str)
        {
            string reversedstring = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedstring += str[i];
            }
            return str.Equals(reversedstring);
        }
    }
}