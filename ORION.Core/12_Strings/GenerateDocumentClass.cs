namespace GenerateDocument
{
    public class GenerateDocumentClass
    {
        public bool GenerateDocument(string characters, string document)
        {
            HashSet<char> alreadyCounted = new HashSet<char>();

            for (int index = 0; index < document.Length; index++)
            {
                char character = document[index];
                if (alreadyCounted.Contains(character))
                {
                    continue;
                }

                int documentFrequency = CountcharFrequency(character, document);
                int characterFrequency= CountcharFrequency(character, characters);
                if (documentFrequency > characterFrequency) 
                { 
                    return false;
                }

                alreadyCounted.Add(character);
            }

            return true;
        }

        private int CountcharFrequency(char character, string target)
        {
            int frequency = 0;
            for (int index = 0; index < target.Length; index++)
            {
                char c = target[index];
                if (c == character)
                {
                    frequency += 1;
                }
            }

            return frequency;
        }
    }
}