using System.Collections.Generic;
namespace FlattenBinaryTree
{
    public class FlattenBinaryTreeClass
    {
        // O(n) time | O(n) space - where n is the number of nodes in the Binary Tree
        public static BinaryTree FlattenBinaryTree(BinaryTree root)
        {
            List<BinaryTree> inOrderNodes = getNodesInOrder(root, new List<BinaryTree>());
            for (int i = 0; i < inOrderNodes.Count - 1; i++)
            {
                BinaryTree leftNode = inOrderNodes[i];
                BinaryTree rightNode = inOrderNodes[i + 1];
                leftNode.right = rightNode;
                rightNode.left = leftNode;
            }
            return inOrderNodes[0];
        }
        public static List<BinaryTree> getNodesInOrder(BinaryTree tree, List<BinaryTree> array)
        {
            if (tree != null)
            {
                getNodesInOrder(tree.left, array);
                array.Add(tree);
                getNodesInOrder(tree.right, array);
            }
            return array;
        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;
            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
    }
}