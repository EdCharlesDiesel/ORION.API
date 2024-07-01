namespace CaesarCipherEncryptor.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
       Assert.True(CaesarCipherEncryptorClass.CaesarCypherEncryptor("xyz", 2).Equals("zab"));
            
        }
    }
}