namespace CaesarCipherEncryptor
{
    /// <summary>
    /// Given a non empty string of lowercase letters and non-negative
    /// integer representing a key. write a function that returns a
    /// new string obtained by shifting every letter in the input
    /// string by k position in the alphabet,
    /// where k is the key.
    /// 
    /// Note that letters should "wrap" around;
    /// in other words, the letter  shifted by
    /// one returns letter a
    /// 
    /// </summary>
    public class CaesarCipherEncryptorClass
    {
        // O(n) time | O(n) space
        public static string CaesarCypherEncryptor(string str, int key)
        {
            char[] newLetters = new char[str.Length];
            int newKey = key % 26;
            for (int i = 0; i < str.Length; i++)
            {
                newLetters[i] = GetNewLetter(str[i], newKey);
            }
            return new string(newLetters);
        }
        public static char GetNewLetter(char letter, int key)
        {
            int newLetterCode = letter + key;
            return newLetterCode <=  122 ? (char)newLetterCode : (char)(96 + newLetterCode % 122);
        }
    }
}