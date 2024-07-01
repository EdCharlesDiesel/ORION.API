using System;

namespace ORION.Core.Arrays
{
    /// <summary>
    /// Write a function that takes i two non-empty array of integers, finds the pair of numbers
    /// (one from each array) whose absolute difference is closer to zero, and returns as array
    /// containing those two numbers, with the number from the first arrau in the first positiobn.
    /// 
    /// Note that the absolute difference of the two integers is the distance between them an the
    /// real number line. For example, the absolute difference of -5 and 5 is 10 and the absolute 
    /// difference of -5 and -4 is 1.
    /// 
    /// You can assume that there will only be pne pair of numbers with the smallest difference.
    /// </summary>
    public static class SmallestDifferenceClass
    {
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            int indexOne = 0;
            int indexTwo = 0;
            int smallest = Int32.MaxValue;
            int current = Int32.MaxValue;
            int[] smallestpair = new int[2];
            while (indexOne < arrayOne.Length && indexTwo < arrayTwo.Length) 
            {
                int firstNumber = arrayOne[indexOne];
                int secondNumber = arrayTwo[indexTwo];

                if (firstNumber < secondNumber) 
                {
                    current = secondNumber - firstNumber;
                    indexOne++;
                }else if (secondNumber < firstNumber)
                { 
                    current = firstNumber - secondNumber;
                    indexTwo++;
                }
                else
                {
                    return new int[] { firstNumber, secondNumber };
                }

                if (smallest > current)
                {
                    smallest = current;
                    smallestpair = new int[] { firstNumber,secondNumber};
                }
            }
            return smallestpair;
        }
    }
}