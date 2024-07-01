using System;
namespace TwoNumberSum;
public class TwoNumberSumClass
{
    /// <summary>
    /// Write a function that takes in a non-empty array of distinct integers and an integer 
    /// representing a target sum. If any two numbers in the input array sum the target sum,
    /// the function should return them in an array, in any order. If no two numbers sum up to 
    /// to the target sum up to the target sum, the function should return an empty.
    /// 
    /// Note that the target sum has to be obtained by summing two different integers in
    /// the array; you can't add a single integer to itself in order to obtain the target sum.
    /// 
    /// You can assume that there will be at most pair of numbers summing up to the target sum.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="targetSum"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int[] TwoNumberSum(int[] array, int targetSum)
    {
        for (var i = 0; i < array.Length -1; i++)
        {
            var firstNum = array[i];
            for (var j = i + 1; j < array.Length; j++)
            {
                var secondNum = array[j];
                if (firstNum + secondNum == targetSum)
                {
                    return new int[] { firstNum, secondNum };
                }
            }
        }

        return Array.Empty<int>();
    }
}
