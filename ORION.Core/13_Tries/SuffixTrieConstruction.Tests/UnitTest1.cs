namespace SuffixTrieConstruction.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            SuffixTrieConstructionClass.SuffixTrie trie = new SuffixTrieConstructionClass.SuffixTrie("babc");
            Assert.True(trie.Contains("abc"));
        }
    }
}