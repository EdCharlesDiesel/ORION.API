using System;
using System.Collections.Generic;
namespace ORION.Core.Recursion
{
    public class BlackJackProbability
    {
        public double BlackjackProbability(int target, int startingHand)
        {
            Dictionary<int,double> memo = new Dictionary<int,double>();
            return Math.Round(calculateProbability(target, startingHand,memo)* 1000f)/1000f;  
        }

        private double calculateProbability(int target, int currentHand, Dictionary<int, double> memo)
        {
            if (memo.ContainsKey(currentHand))
            {
                return memo[currentHand];
            }

            if(currentHand> target){
                return 1;
            }

            if (currentHand + 4 >= target)
            {
                return 0;
            }
            double totalProbelity = 0;
            for (int drawCard = 1; drawCard <= 10; drawCard++)
            {
                totalProbelity += .1 * calculateProbability(target, currentHand + drawCard, memo);
            }
            memo[currentHand] = totalProbelity;
            return totalProbelity;
        }
    }
}