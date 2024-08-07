namespace BTSTaversal.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var root = new BTSTaversalClass.BST(10);
            root.left = new BTSTaversalClass.BST(5);
            root.left.left = new BTSTaversalClass.BST(2);
            root.left.left.left = new BTSTaversalClass.BST(1);
            root.left.right = new BTSTaversalClass.BST(5);
            root.right = new BTSTaversalClass.BST(15);
            root.right.right = new BTSTaversalClass.BST(22);

            List<int> inOrder = new List<int> { 1, 2, 5, 5, 10, 15, 22 };
            List<int> preOrder = new List<int> { 10, 5, 2, 1, 5, 15, 22 };
            List<int> postOrder = new List<int> { 1, 2, 5, 5, 22, 15, 10 };

            Assert.True(Enumerable.SequenceEqual(
              BTSTaversalClass.InOrderTraverse(root, new List<int>()), inOrder
            ));
            Assert.True(Enumerable.SequenceEqual(
              BTSTaversalClass.PreOrderTraverse(root, new List<int>()), preOrder
            ));
            Assert.True(Enumerable.SequenceEqual(
              BTSTaversalClass.PostOrderTraverse(root, new List<int>()), postOrder
            ));
        }
    }
}