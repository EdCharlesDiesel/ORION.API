namespace MinNumberOfJumps
{
    public class MinNumberOfJumpsClass
    {
        // O(n^2) time | O(n) space
        public static int MinNumberOfJumps(int[] array)
        {
            int[] jumps = new int[array.Length];
            Array.Fill(jumps, Int32.MaxValue);
            jumps[0] = 0;
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] >= i - j)
                    {
                        jumps[i] = Math.Min(jumps[j] + 1, jumps[i]);
                    }
                }
            }
            return jumps[jumps.Length - 1];
        }
    }
}