using System;
using System.Linq;

namespace ORION.Core.Arrays
{
    internal class MinRewardsClass3
    {
        public static int MinRewards(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            Array.Fill(rewards, 1);
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > scores[i - 1]) rewards[i] = rewards[i - 1] + 1;
            }
            for (int i = scores.Length - 2; i >= 0; i--)
            {
                if (scores[i] > scores[i + 1])
                {
                    rewards[i] = Math.Max(rewards[i], rewards[i + 1] + 1);
                }
            }
            return rewards.Sum();
        }
    }
}
