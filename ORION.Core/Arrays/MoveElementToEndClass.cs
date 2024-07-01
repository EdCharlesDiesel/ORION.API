using System.Collections.Generic;

namespace ORION.Core.Arrays
{
    /// <summary>
    /// You're given an array of integers ann integer. Write afunction that moves all instance  of
    /// integer in the array to the end of the array and returns the array.
    /// 
    /// The function should perform this in place(i.e., it should mutate the input array) and doesnt
    ///  need to mutate the order of the integers.
    /// </summary>
    public static class MoveElementToEndClass
    {
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            int i = 0;
            int j = array.Count - 1;
            while (i < j) {
                while (i < j && array[j] == toMove) j--;
                if (array[i] == toMove) Swap(i, j, array);
                i++;
            }

            return array;
        }

        private static void Swap(int i, int j, List<int> array)
        {
            int temop = array[j];
            array[j] = array[i];
            array[i] = temop;
        }
    }
}