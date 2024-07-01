namespace CommonCharacters
{
    public class CommonCharactersClass
    {
        public string[] CommonCharacters(string[] strings)
        {
            Dictionary<char, int> characterCounts = new Dictionary<char, int>();
            foreach (var str in strings)
            {
                HashSet<char> uniqueStringChars = new HashSet<char>();
                for (int i = 0; i < str.Length; i++)
                {
                    uniqueStringChars.Add(str[i]);
                }

                foreach (var character in uniqueStringChars)
                {
                    if (!characterCounts.ContainsKey(character))
                    {
                        characterCounts[character] = 0;
                    }
                    characterCounts[character] = characterCounts[character] + 1;
                }
            }

            List<char> finalChars = new List<char>();
            foreach (var characterCount in characterCounts) 
            {
                char charater = characterCount.Key;
                int count = characterCount.Value;
                if (count == strings.Length)
                {
                    finalChars.Add(charater);
                }
            }

            string[] finalCharArray = new string[finalChars.Count];
            for (int i = 0;i<finalCharArray.Length;i++)
            {
                finalCharArray[i] = finalChars[i].ToString();
            }
            return finalCharArray;
        }
    }
}