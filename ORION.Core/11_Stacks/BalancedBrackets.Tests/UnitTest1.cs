namespace BalancedBrackets.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string input = "([])(){}(())()()";
            Assert.True(BalancedBracketsClass.BalancedBrackets(input));
        }
    }
}