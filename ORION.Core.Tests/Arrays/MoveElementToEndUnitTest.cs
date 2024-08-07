
using ORION.Core.Arrays;

namespace MoveElementToEnd.Tests
{
    public class Tests
    {
         [Fact]
        public void Test1()
        {
            List<int> array = new List<int>(){
                2, 1, 2, 2, 2, 3, 4, 2
            };

            int toMove = 2;

            List<int> expectedStart = new List<int>(){
                1, 3, 4
            };

            List<int> expectedEnd = new List<int>(){
                2, 2, 2, 2, 2
            };

            List<int> output = MoveElementToEndClass.MoveElementToEnd(array, toMove);
            List<int> outputStart = output.GetRange(0, 3);
            outputStart.Sort();
            List<int> outputEnd = output.GetRange(3, output.Count - 3);
            Assert.True(outputStart.SequenceEqual(expectedStart));
            Assert.True(outputEnd.SequenceEqual(expectedEnd));
        }
    }
}