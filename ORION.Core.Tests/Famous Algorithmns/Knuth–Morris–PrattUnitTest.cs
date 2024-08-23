using ORION.Core.FamousAlgorithms;

namespace ORION.Core.Tests
{
    public class KnuthMorrisPrattClassUnitTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(
                  KnuthMorrisPrattClass.KnuthMorrisPrattAlgorithm("aefoaefcdaefcdaed", "aefcdaed") == true
                );
        }
    }
}