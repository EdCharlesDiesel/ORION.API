

using System.Collections.Generic;

namespace ORION.Core.BinaryTrees
{
    // Average case: when the tree is balanced
    // O(n) time | O(h) space - where n is the number of nodes in
    // the Binary Tree and h is the height of the Binary Tree
    public class NodeDepthsClass
    {  
        //public static int NodeDepths(BinaryTree root)
        //{
        //    int sumOfDepths = 0;
        //    Stack<Level> stack = new Stack<Level>();
        //    stack.Push(new Level(root, 0));
        //    while (stack.Count > 0)
        //    {
        //        Level top = stack.Pop();
        //        BinaryTree node = top.root;
        //        int depth = top.depth;
        //        if (node == null) continue;
        //        sumOfDepths += depth;
        //        stack.Push(new Level(node.left, depth + 1));
        //        stack.Push(new Level(node.right, depth + 1));
        //    }
        //    return sumOfDepths;
        //}
    }

    public class Level
    {
        public BinaryTree root;
        public int depth;
        public Level(BinaryTree root, int depth)
        {
            this.root = root;
            this.depth = depth;
        }
    }
    public class BinaryTree
    {
        //public int value;
        //public BinaryTree left;
        //public BinaryTree right;
        //public BinaryTree(int value)
        //{
        //    this.value = value;
        //    left = null;
        //    right = null;
        //}
    }
}