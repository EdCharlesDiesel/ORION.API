namespace Knuth_Morris_Pratt.Tests
{
    public class UnitTest1
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