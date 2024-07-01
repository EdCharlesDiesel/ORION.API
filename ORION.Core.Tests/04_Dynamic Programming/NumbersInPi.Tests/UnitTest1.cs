namespace NumbersInPi.Tests
{
    public class UnitTest1
    {
        string PI = "3141592653589793238462643383279";
        [Fact]
        public void Test1()
        {
            string[] numbers = new string[] {
      "314159265358979323846",
      "26433",
      "8",
      "3279",
      "314159265",
      "35897932384626433832",
      "79"
    };
            Assert.True(NumbersInPiClass.NumbersInPi(PI, numbers) == 2);
        }
    }
}