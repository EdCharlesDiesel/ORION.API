namespace MissingNumbers.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var input = new int[] { 4, 5, 1, 3 };
            var expected = new int[] { 2, 6 };
            var actual = new MissingNumbersClass().MissingNumbers(input);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        }
    }
}