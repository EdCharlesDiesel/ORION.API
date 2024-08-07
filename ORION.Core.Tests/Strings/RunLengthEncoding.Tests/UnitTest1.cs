namespace RunLengthEncoding.Tests
{
    public class UnitTest1
    {

		[Fact]
		public void Method_Should_Return_False()
		{
            //ARRANGE
            var input = "AAAAAAAAAAAAABBCCCCDD";
            var expected = "9A4A2B4C2D";

            //ACT
            var actual = new RunLengthEncodingClass().RunLengthEncoding(input);

            //ASSERT
            Assert.True(expected.Equals(actual));					 
        }
    }
}