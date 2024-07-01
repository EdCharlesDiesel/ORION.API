namespace ORION.Core.Arrays
{
    /// <summary>
    /// Write a function that takes in a non-empty array of integers and
    /// returns an array of the same length, where each element in the output
    /// array is equal is equal to the product of every other number in the
    /// input array.
    /// 
    /// In other words, the value at output[i] is equal to the product of every 
    /// number in the input array other than input of output[i].
    /// 
    /// Note that you're expected to solve this problem without using division.
    /// </summary>
    public static class ArrayOfProductsClass
    {
        public static int[] ArrayOfProducts(int[] array)
        {
            var products = new int[array.Length];

            var runningProduct = 1;
            for (var i = 0; i < array.Length; i++) 
            {
                for (var j = 0; j < array.Length; j++)
                {
                    if (i != j)
                    {
                        runningProduct *= array[j]; 
                    }
                    products[i] = runningProduct;   
                }
            }

            return products;
        }
    }
}