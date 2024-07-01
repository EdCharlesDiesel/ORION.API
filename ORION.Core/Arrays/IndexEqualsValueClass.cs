namespace ORION.Core.Arrays
{
    /// <summary>
    /// Write a function that takes in a sorted array of distinct
    /// integers and returns the first index in the array that is equal
    /// to the first index. In other words, your function should return
    /// the minimum index where index ==array[index]
    /// </summary>
    public class IndexEqualsValueClass
    {
        public int IndexEqualsValue(int[] array)
        {
            for (int i = 0; i < array.Length; i++) 
            {
                int value= array[i];
                if (i == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}