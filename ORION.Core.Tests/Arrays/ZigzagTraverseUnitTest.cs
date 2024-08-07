namespace ZigzagTraverse.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<List<int>> test = new List<List<int>>();
            test.Add(new List<int>() { 1, 3, 4, 10 });
            test.Add(new List<int>() { 2, 5, 9, 11 });
            test.Add(new List<int>() { 6, 8, 12, 15 });
            test.Add(new List<int>() { 7, 13, 14, 16 });
            List<int> expected =
              new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            //Assert.True(ZigzagTraverseClass.ZigzagTraverse(test).SequenceEqual(expected));
        }
    }
    }
