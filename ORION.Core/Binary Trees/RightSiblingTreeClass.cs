namespace ORION.Core.BinaryTrees
{
    public class RightSiblingTreeClass
    {
        // O(n) time | O(d) space - where n is the number of nodes in
        // the Binary Tree and d is the depth (height) of the Binary Tree
        //public static BinaryTree RightSiblingTree(BinaryTree root)
        //{
        //    mutate(root, null, false);
        //    return root;
        //}
        //public static void mutate(BinaryTree node, BinaryTree parent, bool isLeftChild)
        //{
        //    if (node == null) return;
        //    var left = node.left;
        //    var right = node.right;
        //    mutate(left, node, true);
        //    if (parent == null)
        //    {
        //        node.right = null;
        //    }
        //    else if (isLeftChild)
        //    {
        //        node.right = parent.right;
        //    }
        //    else
        //    {
        //        if (parent.right == null)
        //        {
        //            node.right = null;
        //        }
        //        else
        //        {
        //            node.right = parent.right.left;
        //        }
        //    }
        //    mutate(right, node, false);
        //}
       
    }
    //public class BinaryTree
    //{
    //    public int value_;
    //    public BinaryTree left = null;
    //    public BinaryTree right = null;
    //    public BinaryTree(int value_)
    //    {
    //        this.value = value_;
    //    }
    //}
}