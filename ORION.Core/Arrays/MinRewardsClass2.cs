using System;
using System.Collections.Generic;
using System.Linq;

namespace ORION.Core.Arrays
{
    internal class MinRewardsClass2
    {
        // O(n) time | O(n) space - where in is the length of the input array

        public static int MinRewards(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            Array.Fill(rewards, 1);
            List<int> localMinIdxs = getLocalMinIdxs(scores);
            foreach (int localMinIdx in localMinIdxs)
            {
                expandFromLocalMinIdx(localMinIdx, scores, rewards);
            }
            return rewards.Sum();
        }
        public static List<int> getLocalMinIdxs(int[] array)
        {
            List<int> localMinIdxs = new List<int>();
            if (array.Length == 1)
            {
                localMinIdxs.Add(0);
                return localMinIdxs;
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0 && array[i] < array[i + 1]) localMinIdxs.Add(i);
                if (i == array.Length - 1 && array[i] < array[i - 1]) localMinIdxs.Add(i);
                if (i == 0 || i == array.Length - 1) continue;
                if (array[i] < array[i + 1] && array[i] < array[i - 1]) localMinIdxs.Add(i);
            }
            return localMinIdxs;
        }
        public static void expandFromLocalMinIdx(int localMinIdx, int[] scores, int[] rewards)
        {
            int leftIdx = localMinIdx - 1;
            while (leftIdx >= 0 && scores[leftIdx] > scores[leftIdx + 1])
            {
                rewards[leftIdx] = Math.Max(rewards[leftIdx], rewards[leftIdx + 1] + 1);
                leftIdx--;
            }
            int rightIdx = localMinIdx + 1;
            while (rightIdx < scores.Length && scores[rightIdx] > scores[rightIdx - 1])
            {
                rewards[rightIdx] = rewards[rightIdx - 1] + 1;
                rightIdx++;
            }
        }
    }
}
