using System;

namespace ORION.Core.GreadyAlgorithmns
{
    /// <summary>
    /// 
    /// </summary>
    public class MinimumWaitingTimeClass
    {
        public int MinimumWaitingTime(int[] queries)
        {
            Array.Sort(queries);
            int totailWaitingTime = 0;
            for (int index = 0; index < queries.Length; index++) 
            {
            
                int duration= queries[index];
                int queriesLeft= queries.Length - (index + 1);
                totailWaitingTime += duration * queriesLeft;
            }
            return totailWaitingTime;
        }
    }
}