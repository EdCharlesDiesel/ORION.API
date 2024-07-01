using System;
using System.Collections.Generic;

namespace ORION.Core.Stacks
{
    public class ShortenPathClass
    {
        // O(n) time | O(n) space - where n is the length of the path
        public static string ShortenPath(string path)
        {
            bool startsWithPath = path[0] == '/';
            string[] tokensArr = path.Split("/");
            List<string> tokensList = new List<string>(tokensArr);
            List<string> filteredTokens = tokensList.FindAll(token => isImportantToken(token));
            Stack<string> stack = new Stack<string>();
            if (startsWithPath) stack.Push("");
            foreach (string token in filteredTokens)
            {
                if (token.Equals(".."))
                {
                    if (stack.Count == 0 || stack.Peek().Equals(".."))
                    {
                        stack.Push(token);
                    }
                    else if (!stack.Peek().Equals(""))
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(token);
                }
            }
            if (stack.Count == 1 && stack.Peek().Equals("")) return "/";
            var arr = stack.ToArray();
            Array.Reverse(arr);
            return String.Join("/", arr);
        }
        public static bool isImportantToken(string token)
        {
            return token.Length > 0 && !token.Equals(".");
        }
    }
}