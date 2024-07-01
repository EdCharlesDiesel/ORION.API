namespace FirstNonRepeatingCharacter
{
    public class FirstNonRepeatingCharacterClass
    {
        public int FirstNonRepeatingCharacter(string str)
        {
            Dictionary<Char,int> charaterFrequency = new Dictionary<Char,int>();

            for (int i = 0; i < str.Length; i++)
            {
                char character = str[i];
                charaterFrequency[character] = 
                    charaterFrequency.GetValueOrDefault(character,0) + 1;
            }

            for (int i = 0; i < str.Length; i++)
            {
                char character = str[i];
               if (charaterFrequency[character]==1) 
                {
                    return i;
                }
            }

            return -1;
        }
    }
}