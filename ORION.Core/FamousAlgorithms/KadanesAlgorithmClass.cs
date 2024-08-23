using System;

namespace ORION.Core.FamousAlgorithms
{
    public class KadanesAlgorithmClass
    {
        // O(n) time | O(1) space
        public static int KadanesAlgorithm(int[] array)
        {
            int maxEndingHere = array[0];
            int maxSoFar = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                int num = array[i];
                maxEndingHere = Math.Max(num, maxEndingHere + num);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }
    }
}