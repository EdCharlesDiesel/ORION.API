using ORION.Core.Strings;

namespace PatternMatcher.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string[] expected = { "go", "powerranger" };
            string inputPattern = "xxyxxy";
            string inputstring = "gogopowerrangergogopowerranger";
            Assert.True(
              compare(PatternMatcherClass.PatternMatcher(inputPattern, inputstring), expected)
            );
        }

        public bool compare(string[] arr1, string[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            if (arr1.Length == 0 && arr2.Length == 0)
            {
                return true;
            }
            return arr1[0].Equals(arr2[0]) && arr1[1].Equals(arr2[1]);
        }
    }
}