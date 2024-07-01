
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MultiStringSearch
//{
//    internal class MultiStringSearchClass2
//    {
//        // O(b^2 + ns) time | O(b^2 + n) space
//        public static List<bool> MultistringSearch(string bigstring, string[] smallstrings)
//        {
//            ModifiedSuffixTrie modifiedSuffixTrie = new ModifiedSuffixTrie(bigstring);
//            List<bool> solution = new List<bool>();
//            foreach (string smallstring in smallstrings)
//            {
//                solution.Add(modifiedSuffixTrie.Contains(smallstring));
//            }
//            return solution;
//        }
//    }
//    public class TrieNode2
//    {
//        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
//    }
//    public class ModifiedSuffixTrie
//    {
//        TrieNode2 root = new TrieNode2();
//        public ModifiedSuffixTrie(string str)
//        {
//            populateModifiedSuffixTrieFrom(str);
//        }
//        public void populateModifiedSuffixTrieFrom(string str)
//        {
//            for (int i = 0; i < str.Length; i++)
//            {
//                insertSubstringStartingAt(i, str);
//            }
//        }
//        public void insertSubstringStartingAt(int i, string str)
//        {
//            TrieNode node = root;
//            for (int j = i; j < str.Length; j++)
//            {
//                char letter = str[j];
//                if (!node.children.ContainsKey(letter))
//                {
//                    TrieNode newNode = new TrieNode();
//                    node.children.Add(letter, newNode);
//                }
//                node = node.children[letter];
//            }
//        }
//        public bool Contains(string str)
//        {
//            TrieNode2 node = root;
//            for (int i = 0; i < str.Length; i++)
//            {
//                char letter = str[i];
//                if (!node.children.ContainsKey(letter))
//                {
//                    return false;
//                }
//                node = node.children[letter];
//            }
//            return true;
//        }
//    }

//}
