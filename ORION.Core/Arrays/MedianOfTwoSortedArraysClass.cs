using System;

namespace ORION.Core.Arrays
{
    /// <summary>
    /// You're given two sorted arrays of integers arrayOne and
    /// arrayTwo. Write a function that returns the median of these
    /// arrays.
    /// 
    /// You can assume both arrays have at least one value. however,
    /// they could be of difference lengths.if the median is a decimal
    /// value, it should not be rounded (beyound the inevitable rounding
    /// of floating rounding of point math)
    /// </summary>
    public class MedianOfTwoSortedArraysClass
    {
        public float MedianOfTwoSortedArrays(int[] arrayOne, int[] arrayTwo)
        {
            int[] smallArray = arrayOne.Length <= arrayTwo.Length ? arrayOne : arrayTwo;
            int[] bigArray = arrayOne.Length > arrayTwo.Length ? arrayOne : arrayTwo;

            int leftIndex = 0;
            int rightIndex = smallArray.Length - 1;
            int mergetLeftIndex = (smallArray.Length + bigArray.Length - 1) / 2;

            while (true)
            {
                int smallPartitionIndex =
                    (int)Math.Floor(((double)(leftIndex + rightIndex) / 2));
                int bigPartitionIndex = mergetLeftIndex - smallPartitionIndex - 1;

                int smallMaxLeftValue =
                    smallPartitionIndex >= 0 ? smallArray[smallPartitionIndex] : Int32.MinValue;
                int smallMinRightValue = smallPartitionIndex + 1 < smallArray.Length
                    ? smallArray[smallPartitionIndex + 1] : Int32.MaxValue;

                int bigMaxLeftValue =
                    bigPartitionIndex >= 0 ? bigArray[bigPartitionIndex] : Int32.MinValue;
                int bigMinRightValue = bigPartitionIndex + 1 < bigArray.Length
                    ? bigArray[bigPartitionIndex + 1] : Int32.MaxValue;

                if (smallMaxLeftValue > bigMinRightValue)
                {
                    rightIndex = smallPartitionIndex - 1;
                }
                else if (bigMaxLeftValue > smallPartitionIndex)
                {
                    leftIndex = smallPartitionIndex + 1;
                }
                else
                {
                    if ((smallArray.Length + bigArray.Length) % 2 == 0)
                    {
                        return (float)(Math.Max(smallMaxLeftValue, bigMinRightValue) +
                            Math.Min(smallMinRightValue, bigMinRightValue)) / 2;
                    }
                }

                return Math.Max(smallMaxLeftValue, bigMinRightValue);

            }
           
        }
    }
}