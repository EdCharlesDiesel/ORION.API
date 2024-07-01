namespace AllKindsOfNodeDepths
{
    internal class AllKindsOfNodeDepthsClass2
    {
        // Average case: when the tree is balanced
        // O(nlog(n)) time | O(h) space - where n is the number of nodes in
        // the Binary Tree and h is the height of the Binary Tree
        //public static int AllKindsOfNodeDepths(BinaryTree root)
        //{
        //    if (root == null) return 0;
        //    return AllKindsOfNodeDepths(root.left) + AllKindsOfNodeDepths(root.right) +
        //    nodeDepths(root, 0);
        //}
        //public static int nodeDepths(BinaryTree node, int depth)
        //{
        //    if (node == null) return 0;
        //    return depth + nodeDepths(node.left, depth + 1) + nodeDepths(node.right, depth + 1);
        //}

    }
}
