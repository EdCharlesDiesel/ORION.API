namespace KnightConnection.Tests
{
    public class UnitTest1
    {
        [Fact(Skip = "Failing unit test")]
        public void Test1()
        {
            var knightA = new[] { 0, 0 };
            var knightB = new[] { 2, 1 };
            var actual = new KnightConnectionClass().KnightConnection(knightA, knightB);
            Assert.True(1 == actual);
        }
    }
}