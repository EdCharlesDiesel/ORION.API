using Xunit;

namespace ArrayOfProducts.Tests
{
    public class ArrayOfProductsUnitTest
    {
        [Fact(Skip = "Need to look at this function")]
        public void Test1()
        {
            var input = new int[] { 5, 1, 4, 2 };
            var expected = new int[] { 8, 40, 10, 20 };
            int[] actual = ArrayOfProductsClass.ArrayOfProducts(input);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.True(actual[i] == expected[i]);
            }
        }
    }
}