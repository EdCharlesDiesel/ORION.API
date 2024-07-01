using BinarySearch;
using System;

namespace BinarySearch
{
    /// <summary>
    /// 
    /// </summary>
    public class BinarySearchClass
    {
        public int BinarySearch(int[] A, int n, int key)
        {
            int l = 0;
            int r = n - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (key == A[mid])
                    return mid;
                else if (key < A[mid])
                    r = mid - 1;
                else if (key > A[mid])
                    l = mid + 1;
            }
            return -1;
        }

        #region Solution One
        public  int BinarySearchSolutionOne(int[] array, int target)
        {
            return BinarySearchSolutionOne(array, target, 0, array.Length - 1);
        }

        public  int BinarySearchSolutionOne(int[] array, int target, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            int middle = (left + right) / 2;
            int potentialMatch = array[middle];
            if (target == potentialMatch) 
            { 
                return middle;
            }else if (target< potentialMatch)
            {
                return BinarySearchSolutionOne(array, target, left, middle -1);
            }
            else
            {
                return BinarySearchSolutionOne(array, target, middle + 1, right);    
            }
        }

        #endregion
    }
}

