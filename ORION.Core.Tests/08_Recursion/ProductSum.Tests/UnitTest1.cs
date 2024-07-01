
namespace ProductSum.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public  void TestCase1()
        {
            List<object> test = new List<object>()
            {
                1,
                2,
                new List<object>()
                {
                    7,-1
                },
                3,
                 new List<object>()
                 {
                     6,
                     new List<object>()
                     {
                         -13,8
                     },
                     4
                 },
            };
            var result =  Program.ProductSum(test);
            Assert.That(result, Is.EqualTo(8));
        }
    }
}