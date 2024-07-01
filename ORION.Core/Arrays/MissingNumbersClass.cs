using System.Collections.Generic;

namespace ORION.Core.Arrays
{
    public class MissingNumbersClass
    {
        public int[] MissingNumbers(int[] numbers)
        {
            HashSet<int> includedNums = new HashSet<int>();
            foreach (int number in numbers)
            {
                includedNums.Add(number);
            }
            int[] solution = new int[] {-1,-1};
            for (int num = 1; num < numbers.Length + 3; num++)
            {
                if (!includedNums.Contains(num))
                {
                    if (solution[0] == -1) 
                    {
                        solution[0] = num;
                    }
                    else
                    {
                        solution[1] = num;
                    }
                }
            }

            return solution;

        }
    }
}