namespace ORION.Core.Arrays
{

    /// <summary>
    /// Write a function that takes on an array of integers and returns a boolean representing 
    /// whether the array is monotonic.
    /// 
    /// An array is said to be monotonic if it's elements, from left to right, are entirely non-
    /// increasing ot entirelt non-descresing.
    /// 
    /// Non-incresing elements aren't necessarily exclusive decreasing; the simply don't increase.
    /// Similarly, non0descresing elements aren't necessarily exlucsively increasing; they simply 
    /// don't decrease.
    /// 
    /// Note that empty arrays and arrrays of one element are monotonic.
    /// </summary>
    public  static class IsMonotonicClass
    {
        #region Solution One
      
        // O(n) time | O(1) space - where n is the length of array
        public static bool IsMonotonic(int[] array)
        {
            if (array.Length <= 2) return true;

            var direction = array[1] - array[0];
            for (int i = 2; i < array.Length; i++)
            {
                if (direction == 0)
                {
                    direction = array[i] - array[i - 1];
                    continue;
                }

                if (breaksDirection(direction, array[i - 1], array[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool breaksDirection(int direction, int previous, int current)
        {
            var difference = current - previous;
            if (difference > 0) return difference < 0;
            return difference > 0;
        }

        #endregion

        #region Solution Two

        public static bool IsMonotonicMethod(int[] array)
        {
            var isNonDecreasing = true;
            var isNonIncreasing = true;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i]< array[i-1])
                {
                    isNonDecreasing = false;
                }

                if (array[i]> array[i-1])
                {
                    isNonIncreasing=false;
                }
            }

            return isNonDecreasing || isNonIncreasing;
        }
        #endregion
    }
}