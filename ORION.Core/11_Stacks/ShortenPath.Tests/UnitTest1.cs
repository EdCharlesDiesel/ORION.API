namespace ShortenPath.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expected = "/foo/bar/baz";
            var actual = ShortenPathClass.ShortenPath("/foo/../test/../test/../foo//bar/./baz");
            Assert.Equal(expected, actual);
        }
    }
}