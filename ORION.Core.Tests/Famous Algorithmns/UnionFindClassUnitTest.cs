namespace ORION.Core.Tests
{
    public class UnionFindClassUnitTest
    {
        [Fact]
        public void Test1()
        {
            var unionFind = new UnionFindClass.UnionFind();
            Assert.True(unionFind.Find(1) == null);
            unionFind.CreateSet(1);
            Assert.True(unionFind.Find(1) == 1);
            unionFind.CreateSet(5);
            Assert.True(unionFind.Find(1) == 1);
            Assert.True(unionFind.Find(5) == 5);
            unionFind.Union(5, 1);
            Assert.True(unionFind.Find(5) == unionFind.Find(1));
        }
    }
}