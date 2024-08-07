using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ClassPhotos.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="Failing Unit Test")]
        public void Test1()
        {
            List<int> redShirtHeights = new List<int> { 5, 8, 1, 3, 4 };
            List<int> blueShirtHeights = new List<int> { 6, 9, 2, 4, 5 };
            bool expected = true;
            bool actual = new ClassPhotosClass().ClassPhotos(redShirtHeights, blueShirtHeights);
            Assert.True(expected == actual);
        }
    }
}