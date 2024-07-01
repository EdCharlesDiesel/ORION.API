using System;

namespace SortedSquaredArray;
public class SortedSquaredArrayClass
{
    /// <summary>
    /// Write a function that takes in a non-empty array of integers that are sorted
    /// in ascending  order and returns a new array of the saw length with the squares
    /// of the original integer  also sorted in ascending order.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int[] SortedSquaredArray(int[] array)
    {
        var sortedSquares = new int[array.Length];
        for (int index = 0; index < array.Length; index++)
        {
            var value = array[index];
            sortedSquares[index] = value*value;
        }

        Array.Sort(sortedSquares);
        return sortedSquares;
    }
}
