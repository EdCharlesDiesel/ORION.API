namespace MinHeightBST.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="Fix this")]
        public void Test1()
        {
            //var array = new List<int> { 1, 2, 5, 7, 10, 13, 14, 15, 22 };
            //var tree = Program.MinHeightBst(array);

            //Utils.AssertTrue(validateBst(tree));
            //Utils.AssertEquals(4, getTreeHeight(tree));

            //var inOrder = inOrderTraverse(tree, new List<int> { });
            //var expected = new List<int> { 1, 2, 5, 7, 10, 13, 14, 15, 22 };
            //Utils.AssertTrue(Enumerable.SequenceEqual(inOrder, expected));
        }

        //static bool validateBst(Program.BST tree)
        //{
        //    return validateBst(tree, Int32.MinValue, Int32.MaxValue);
        //}

        //static bool validateBst(Program.BST tree, int minValue, int maxValue)
        //{
        //    if (tree.value < minValue || tree.value >= maxValue)
        //    {
        //        return false;
        //    }
        //    if (tree.left != null && !validateBst(tree.left, minValue, tree.value))
        //    {
        //        return false;
        //    }
        //    if (tree.right != null && !validateBst(tree.right, tree.value, maxValue))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //static List<int> inOrderTraverse(Program.BST tree, List<int> array)
        //{
        //    if (tree.left != null)
        //    {
        //        inOrderTraverse(tree.left, array);
        //    }
        //    array.Add(tree.value);
        //    if (tree.right != null)
        //    {
        //        inOrderTraverse(tree.right, array);
        //    }
        //    return array;
        //}

        //static int getTreeHeight(Program.BST tree)
        //{
        //    return getTreeHeight(tree, 0);
        //}

        //static int getTreeHeight(Program.BST tree, int height)
        //{
        //    if (tree == null) return height;
        //    int leftTreeHeight = getTreeHeight(tree.left, height + 1);
        //    int rightTreeHeight = getTreeHeight(tree.right, height + 1);
        //    return Math.Max(leftTreeHeight, rightTreeHeight);
        //}
    }
    
}