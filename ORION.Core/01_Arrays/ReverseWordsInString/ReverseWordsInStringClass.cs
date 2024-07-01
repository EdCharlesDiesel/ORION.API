namespace ReverseWordsInString
{
    public class ReverseWordsInStringClass
    {
        public string ReverseWordsInString(string str)
        {
            List<string> words = new List<string>();
            int startOfWord = 0;

            for (int i = 0; i < str.Length; i++)
            {
                char charecter = str[i];

                if (charecter == ' ')
                {
                    words.Add(str.Substring(startOfWord, i - startOfWord));
                    startOfWord = i;
                }
                else if (str[startOfWord] == ' ')
                {
                    words.Add(" ");
                    startOfWord = i;
                }
            }

            words.Add(str.Substring(startOfWord));
            words.Reverse();
            return String.Join(" ", words);
        }
    }
}
