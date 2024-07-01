namespace SquareOfZeroes.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="Fix later")]
        public void Test1()
        {
            List<List<int>> test = new List<List<int>>();
            test.Add(new List<int>() { 1, 1, 1, 0, 1, 0 });
            test.Add(new List<int>() { 0, 0, 0, 0, 0, 1 });
            test.Add(new List<int>() { 0, 1, 1, 1, 0, 1 });
            test.Add(new List<int>() { 0, 0, 0, 1, 0, 1 });
            test.Add(new List<int>() { 0, 1, 1, 1, 0, 1 });
            test.Add(new List<int>() { 0, 0, 0, 0, 0, 1 });
          //  Utils.AssertTrue(Program.SquareOfZeroes(test));
        }
    }
}