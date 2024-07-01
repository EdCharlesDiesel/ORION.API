using System;

namespace ORION.Core.BinarySearchTree
{
    public class ValidateBSTClass
    {
        // O(n) time | O(d) space
        public static bool ValidateBst(BST tree)
        {
            return ValidateBst(tree, Int32.MinValue, Int32.MaxValue);
        }
        public static bool ValidateBst(BST tree, int minValue, int maxValue)
        {
            if (tree.value < minValue || tree.value >= maxValue)
            {
                return false;
            }
            if (tree.left != null && !ValidateBst(tree.left, minValue, tree.value))
            {
                return false;
            }
            if (tree.right != null && !ValidateBst(tree.right, tree.value, maxValue))
            {
                return false;
            }
            return true;
        }
        public class BST
        {
            public int value;
            public BST left;
            public BST right;
            public BST(int value)
            {
                this.value = value;
            }
        }
    }
}