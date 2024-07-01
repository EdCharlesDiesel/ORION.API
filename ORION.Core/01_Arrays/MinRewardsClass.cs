namespace MinRewards
{
    public class MinRewardsClass
    {
        // O(n^2) time | O(n) space - where in is the length of the input array
  
            public static int MinRewards(int[] scores)
            {
                int[] rewards = new int[scores.Length];
                Array.Fill(rewards, 1);
                for (int i = 1; i < scores.Length; i++)
                {
                    int j = i - 1;
                    if (scores[i] > scores[j])
                    {
                        rewards[i] = rewards[j] + 1;
                    }
                    else
                    {
                        while (j >= 0 && scores[j] > scores[j + 1])
                        {
                            rewards[j] = Math.Max(rewards[j], rewards[j + 1] + 1);
                            j--;
                        }
                    }
                }
                return rewards.Sum();
            }
        
    }
}