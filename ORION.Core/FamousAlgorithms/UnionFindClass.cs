using System.Collections.Generic;

namespace ORION.Core.FamousAlgorithms
{
    /// <summary>
    /// 
    /// </summary>
    public class UnionFindClass
    {
        public class UnionFind
        {
            private Dictionary<int, int> parents = new Dictionary<int, int>();

            //O(1) time | O(1) space
            public void CreateSet(int value)
            {
                parents[value] = value;
            }

            public int? Find(int value)
            {
                if (!parents.ContainsKey(value))
                {
                    return null;
                }

                int currentParent = value;
                while (currentParent != parents[currentParent])
                {
                    currentParent = parents[currentParent];
                }
                return currentParent;
            }

            public void Union(int valueOne, int valueTwo)
            {
                if (!parents.ContainsKey(valueOne) || !parents.ContainsKey(valueTwo))
                {
                    return;
                }

                int valueOneRoot = (int)Find(valueOne);
                int valueTwoRoot = (int)Find(valueTwo);
                parents[valueTwoRoot] = valueOneRoot;
            }
        }
    }
}