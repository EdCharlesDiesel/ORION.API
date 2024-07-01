using System;

namespace ORION.Core.LinkedList
{
    internal class MinNumberOfJumpsClass1
    {
        // O(n) time | O(1) space
        public static int MinNumberOfJumps(int[] array)
        {
            if (array.Length == 1)
            {
                return 0;
            }
            int jumps = 0;
            int maxReach = array[0];
            int steps = array[0];
            for (int i = 1; i < array.Length - 1; i++)
            {
                maxReach = Math.Max(maxReach, i + array[i]);
                steps--;
                if (steps == 0)
                {
                    jumps++;
                    steps = maxReach - i;
                }
            }
            return jumps + 1;
        }
    }
}
