using System;

namespace ORION.Core.Arrays
{
    public class LongestPeakClass
    {
        /// <summary>
        /// Write a function that takes in an array of integer and  returns the length of the
        /// longest peak in the array. 
        /// 
        /// A peak is defined as adjacent integers in the array that are strictly increasing until
        /// a tip( the highest value in the peak), att which point they  become strictly decreasing.
        /// At least three integer are required for form a peak.
        /// 
        /// For example. the integers [1,4,10,2] form a peak, but the integers [4,0,10] don't and
        /// neither do the integers [1,2,2,0].Similaly, the integers [1,2,3] don't form a peak
        /// because there aren't any strictly decreasing integers after the 3.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int LongestPeak(int[] array)
        {
            int longestPeakLength = 0;
            int i = 1;
            while (i < array.Length - 1) 
            {
                bool isPeak = array[i - 1] < array[i] && array[i] > array[i + 1];
                if (!isPeak)
                {
                    i +=1;
                    continue;
                }

                int leftIndex = i - 2;
                while (leftIndex >= 0 && array[leftIndex] < array[leftIndex + 1])
                {
                    leftIndex -= 1 ;
                }

                int rightIndex = i + 2;
                while (rightIndex < array.Length && array[rightIndex] < array[rightIndex - 1])
                {
                    rightIndex += 1;
                }

                int currentPeakLenghth = rightIndex  - leftIndex - 1;
                if (currentPeakLenghth > longestPeakLength)
                {
                    longestPeakLength = currentPeakLenghth;
                }

                i = rightIndex;

            }

            return longestPeakLength;
        }
    }
}


