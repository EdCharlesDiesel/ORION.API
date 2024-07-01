
using System;

namespace ORION.Core
{
    /// <summary>
    /// Given an array between 1 and n, inclusive, where n is 
    /// the length of the array. Write a function that returns
    /// the first integer that appears more than once (when the 
    /// array read from leghth to right).
    /// 
    /// In other words, out of all the integers that might occur
    /// more than once in the inpout array. your array function
    /// should return the one whose first duplicate value has the
    /// minimum index.
    /// 
    /// if no integer appears more than once, your function should
    /// return -1.
    /// 
    /// Note that you're not allowed to mutate the input array.
    /// </summary>
    public class FirstDuplicateValueClass
    {
        public int FirstDuplicateValue(int[] array)
        {
            var minimumSecondIndex= array.Length;
            for (int i = 0; i < array.Length; i++)
            {                
                int value= array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int valueToCompare = array[j];
                    if (value == valueToCompare)
                    {
                        minimumSecondIndex = Math.Min(minimumSecondIndex, j);           
                    }
                }
            }

            if (minimumSecondIndex ==array.Length) 
            {
                return -1;
            }
            

            return array[minimumSecondIndex];
        }
    }
}

