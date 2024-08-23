namespace FlattenBinaryTree.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            FlattenBinaryTreeClass.BinaryTree root = new FlattenBinaryTreeClass.BinaryTree(1);
            insert(root, new int[] { 2, 3, 4, 5, 6 });
            root.left.right.left = new FlattenBinaryTreeClass.BinaryTree(7);
            root.left.right.right = new FlattenBinaryTreeClass.BinaryTree(8);
            FlattenBinaryTreeClass.BinaryTree leftMostNode = FlattenBinaryTreeClass.FlattenBinaryTree(root);
            List<int> leftToRightToLeft = this.leftToRightToLeft(leftMostNode);
            List<int> expected =
              new List<int>() { 4, 2, 7, 5, 8, 1, 6, 3, 3, 6, 1, 8, 5, 7, 2, 4 };
            Assert.True(expected.SequenceEqual(leftToRightToLeft));
        }

        public void insert(FlattenBinaryTreeClass.BinaryTree root, int[] values)
        {
            insert(root, values, 0);
        }

        public void insert(FlattenBinaryTreeClass.BinaryTree root, int[] values, int i)
        {
            if (i >= values.Length)
            {
                return;
            }
            Queue<FlattenBinaryTreeClass.BinaryTree> queue = new Queue<FlattenBinaryTreeClass.BinaryTree>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                FlattenBinaryTreeClass.BinaryTree current = queue.Dequeue();
                if (current.left == null)
                {
                    current.left = new FlattenBinaryTreeClass.BinaryTree(values[i]);
                    break;
                }
                queue.Enqueue(current.left);
                if (current.right == null)
                {
                    current.right = new FlattenBinaryTreeClass.BinaryTree(values[i]);
                    break;
                }
                queue.Enqueue(current.right);
            }
            insert(root, values, i + 1);
        }

        public List<int> leftToRightToLeft(FlattenBinaryTreeClass.BinaryTree leftMost)
        {
            List<int> nodes = new List<int>();
            FlattenBinaryTreeClass.BinaryTree current = leftMost;
            while (current.right != null)
            {
                nodes.Add(current.value);
                current = current.right;
            }
            nodes.Add(current.value);
            while (current != null)
            {
                nodes.Add(current.value);
                current = current.left;
            }
            return nodes;
        }
    }
}