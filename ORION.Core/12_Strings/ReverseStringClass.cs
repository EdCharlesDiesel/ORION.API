using System.Text;

namespace ReverseString
{
    public static class ReverseStringClass
    {
        public static string ReverseString(string ordinaryString)
        {
          
            for (int i = ordinaryString.Length - 1; i >= 0; i--)
            {
                ordinaryString[i].ToString();
            }
            
            return ordinaryString;
        }

    }
}