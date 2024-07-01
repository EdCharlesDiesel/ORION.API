
using System.Collections.Generic;

namespace ORION.Core.BinaryTrees
{
    public class AllKindsOfNodeDepthsClass
    {
        // Average case: when the tree is balanced
        // O(nlog(n)) time | O(h) space - where n is the number of nodes in
        // the Binary Tree and h is the height of the Binary Tree
        public static int AllKindsOfNodeDepths(AllKindsOfNodeDepthsClassBinaryTree root)
        {
            int sumOfAllDepths = 0;
            Stack<AllKindsOfNodeDepthsClassBinaryTree> stack = new Stack<AllKindsOfNodeDepthsClassBinaryTree>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                AllKindsOfNodeDepthsClassBinaryTree node = stack.Pop();
                if (node == null) continue;
                sumOfAllDepths += nodeDepths(node, 0);
                stack.Push(node.left);
                stack.Push(node.right);
            }
            return sumOfAllDepths;
        }
        public static int nodeDepths(AllKindsOfNodeDepthsClassBinaryTree node, int depth)
        {
            if (node == null) return 0;
            return depth + nodeDepths(node.left, depth + 1) + nodeDepths(node.right, depth + 1);
        }


    }
    public class AllKindsOfNodeDepthsClassBinaryTree
    {
        public int value;
        public AllKindsOfNodeDepthsClassBinaryTree left;
        public AllKindsOfNodeDepthsClassBinaryTree right;
        public AllKindsOfNodeDepthsClassBinaryTree(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }

}