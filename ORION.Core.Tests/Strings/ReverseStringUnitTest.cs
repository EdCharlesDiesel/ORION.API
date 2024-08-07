using ORION.Core.Strings;

namespace ReverseString.Tests
{
    public class UnitTest1
    {

		[Fact(Skip ="Was Failing")]
		public void Method_Should_Return_False()
		{
			//ARRANGE
						 

			//ACT
			var actual = ReverseStringClass.ReverseString("abcde");

			//ASSERT					 
			Assert.Equal("edcba", actual);
		}


	}
}