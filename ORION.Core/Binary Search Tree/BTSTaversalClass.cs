using System.Collections.Generic;

namespace ORION.Core.BinarySearchTree
{
    public class BTSTaversalClass
    {
        // O(n) time | O(n) space
        public static List<int> InOrderTraverse(BST tree, List<int> array)
        {
            if (tree.left != null)
            {
                InOrderTraverse(tree.left, array);
            }
            array.Add(tree.value);
            if (tree.right != null)
            {
                InOrderTraverse(tree.right, array);
            }
            return array;
        }
        // O(n) time | O(n) space
        public static List<int> PreOrderTraverse(BST tree, List<int> array)
        {
            array.Add(tree.value);
            if (tree.left != null)
            {
                PreOrderTraverse(tree.left, array);
            }
            if (tree.right != null)
            {
                PreOrderTraverse(tree.right, array);
            }
            return array;
        }
        // O(n) time | O(n) space
        public static List<int> PostOrderTraverse(BST tree, List<int> array)
        {
            if (tree.left != null)
            {
                PostOrderTraverse(tree.left, array);
            }
            if (tree.right != null)
            {
                PostOrderTraverse(tree.right, array);
            }
            array.Add(tree.value);
            return array;
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