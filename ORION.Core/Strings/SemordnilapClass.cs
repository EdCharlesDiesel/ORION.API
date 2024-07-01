
using System;
using System.Collections.Generic;

namespace ORION.Core.Strings
{
    public class SemordnilapClass
    {
        public List<List<string>> Semordnilap(string[] words)
        {
            HashSet<string> wordsSet = new HashSet<string>();
            List<List<string>> semordnilapPairs = new List<List<string>>();

            foreach (var word in words) 
            {
                char[] chars = word.ToCharArray();
                Array.Reverse(chars);
                string reverse = new string(chars);
                if (wordsSet.Contains(reverse) && !reverse.Equals(word))
                {
                    List<string> semordnilapPair = new List<string> { word, reverse };
                    semordnilapPairs.Add(semordnilapPair);
                    wordsSet.Remove(word);
                    wordsSet.Remove(reverse);
                }
            }

            return semordnilapPairs;
        }
    }
}