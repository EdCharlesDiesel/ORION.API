using System;

namespace ORION.Core.DynamicProgramming
{
    public class LevenshteinDistanceClass2
    {
        // O(nm) time | O(min(n, m)) space
        public static int LevenshteinDistance(string str1, string str2)
        {
            string small = str1.Length < str2.Length ? str1 : str2;
            string big = str1.Length >= str2.Length ? str1 : str2;
            int[] evenEdits = new int[small.Length + 1];
            int[] oddEdits = new int[small.Length + 1];
            for (int j = 0; j < small.Length + 1; j++)
            {
                evenEdits[j] = j;
            }
            int[] currentEdits;
            int[] previousEdits;
            for (int i = 1; i < big.Length + 1; i++)
            {
                if (i % 2 == 1)
                {
                    currentEdits = oddEdits;
                    previousEdits = evenEdits;
                }
                else
                {
                    currentEdits = evenEdits;
                    previousEdits = oddEdits;
                }
                currentEdits[0] = i;
                for (int j = 1; j < small.Length + 1; j++)
                {
                    if (big[i - 1] == small[j - 1])
                    {
                        currentEdits[j] = previousEdits[j - 1];
                    }
                    else
                    {
                        currentEdits[j] = 1 + Math.Min(previousEdits[j - 1], Math.Min(
                        previousEdits[j],
                        currentEdits[j -
                        1]));
                    }
                }
            }
            return big.Length % 2 == 0 ? evenEdits[small.Length] : oddEdits[small.Length];
        }
    }
}
