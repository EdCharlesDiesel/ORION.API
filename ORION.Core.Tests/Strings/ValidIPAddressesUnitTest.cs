using ORION.Core.Strings;

namespace ValidIPAddresses.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string input = "1921680";
            List<string> expected = new List<string>();
            expected.Add("1.9.216.80");
            expected.Add("1.92.16.80");
            expected.Add("1.92.168.0");
            expected.Add("19.2.16.80");
            expected.Add("19.2.168.0");
            expected.Add("19.21.6.80");
            expected.Add("19.21.68.0");
            expected.Add("19.216.8.0");
            expected.Add("192.1.6.80");
            expected.Add("192.1.68.0");
            expected.Add("192.16.8.0");
            var actual = new ValidIPAddressesClass().ValidIPAddresses(input);
            Assert.True(Enumerable.SequenceEqual(expected, actual));
        }
    }
}