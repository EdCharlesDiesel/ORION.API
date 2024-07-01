namespace ORION.Core.Strings
{
    public class CaesarCipherEncryptorClass2
    {
        // O(n) time | O(n) space
        public static string CaesarCypherEncryptor(string str, int key)
        {
            char[] newLetters = new char[str.Length];
            int newKey = key % 26;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < str.Length; i++)
            {
                newLetters[i] = getNewLetter(str[i], newKey, alphabet);
            }
            return new string(newLetters);
        }

        public static char getNewLetter(char letter, int key, string alphabet)
        {
            int newLetterCode = alphabet.IndexOf(letter) + key;
            return newLetterCode <= 25 ? alphabet[newLetterCode] : alphabet[-1 + newLetterCode];
        }
    }
}
