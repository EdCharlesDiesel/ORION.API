using System;

namespace NonConstructibleChange
{
    /// <summary>
    /// Given an array of positive integers representing the values of coins in your possession,
    /// write a function that returns the minimum amount of change (minimum sum of money) that
    /// you cannot create. The given coins can have any positive integer value and arent 
    /// necessarily unique (i.e., you can have multiple coins of the same value). 
    /// 
    /// For example, if you're given coins = [1,2,5], the minimum amount of change that you
    /// can't create is 4. If you're given no coins, the minimum amount of change that you can't
    /// is 1.
    /// 
    /// </summary>
    public class NonConstructibleChangeClass
    {
        // O(nlogn) time | O(1) space - where n is the number of coins
        public int NonConstructibleChange(int[] coins)
        {
            Array.Sort(coins);

            var currentChangeCreated = 0;
            foreach (var coin in coins)
            {
                if (coin > currentChangeCreated + 1)
                {
                    return currentChangeCreated + 1; 
                }
                currentChangeCreated += coin;
            }

            return currentChangeCreated +1;
        }
    }
}