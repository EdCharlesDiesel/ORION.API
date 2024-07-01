using System;
using System.Collections.Generic;
namespace ORION.Core.Recursion
{
    /// <summary>
    /// Write a function that takes in a "special" array 
    /// and returns it's  product sum. A "Special" array is
    /// a non-empty array that contains either integer or other 
    /// "special" array is the sum of it elements. where "special"
    /// array inside it are summed themselves and then  multiplied
    /// by their level of debth.
    /// 
    /// The depth of a "special" array is how far nested it is. 
    /// For instance, the depth of [] is 1; the depth if the 
    /// inner array [[]] is 2; the debth. of the innermost array 
    /// in [[[]]] is 3.
    /// 
    /// Therefore, the production sum of [x,y] is x + y; the 
    /// product sum of [x,[y,z]] is x + 2 (y+z); the product sum 
    /// of [x,[y,[z]]] is x + 2 * (y + 3z).
    /// 
    /// Sample input.
    /// array = [5,2,[7,-1],3,[6,[-13,8],4]].
    /// 
    /// </summary>
    public static class ProductSumClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static int ProductSum(List<object> array)
        {
            return ProductSumHelper(array, 1);
        }


        /// <summary>
        /// O(n) time | O(d) space - where n is the total 
        /// number of elements in the array, includin sub-elements, and
        /// the greatest debth of "special" arrays in the array.
        /// indexer the
        /// </summary>
        /// <param name="array"></param>
        /// <param name="muliplier"></param>
        /// <returns></returns>
        private static int ProductSumHelper(List<object> array, int muliplier)
        {
            int sum = 0;
            foreach (object item in array)
            {
                if (item is IList<object>)
                {
                    sum += ProductSumHelper((List<object>)item, muliplier + 1);
                }else
                {
                    sum += (int)item;
                }
            }
            return sum * muliplier;
        }
    }
}