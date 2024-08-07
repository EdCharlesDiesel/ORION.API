namespace InvertBinaryTree.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            TestBinaryTree tree = new TestBinaryTree(1);
            tree.insert(new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }, 0);
            InvertBinaryTreeClass.InvertBinaryTree(tree);
            InvertedBinaryTree invertedTree = new InvertedBinaryTree(1);
            invertedTree.insert(new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }, 0);
            Assert.True(compareBT(tree, invertedTree));
        }

        private bool compareBT(InvertBinaryTreeClass.BinaryTree tree1, InvertedBinaryTree tree2)
        {
            if (tree1 == null && tree2 == null)
            {
                return true;
            }
            if (tree1 != null && tree2 != null)
            {
                return tree1.value == tree2.value && compareBT(tree1.left, tree2.left) &&
                       compareBT(tree1.right, tree2.right);
            }
            return false;
        }

        class InvertedBinaryTree
        {
            public int value;
            public InvertedBinaryTree left;
            public InvertedBinaryTree right;

            public InvertedBinaryTree(int value)
            {
                this.value = value;
            }

            public void insert(int[] values, int i)
            {
                if (i >= values.Length)
                {
                    return;
                }
                List<InvertedBinaryTree> queue = new List<InvertedBinaryTree>();
                queue.Add(this);
                var index = 0;
                while (index < queue.Count)
                {
                    InvertedBinaryTree current = queue[index];
                    index += 1;
                    if (current.right == null)
                    {
                        current.right = new InvertedBinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.right);
                    if (current.left == null)
                    {
                        current.left = new InvertedBinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.left);
                }
                insert(values, i + 1);
            }
        }

        public class TestBinaryTree : InvertBinaryTreeClass.BinaryTree
        {
            public TestBinaryTree(int value) : base(value) { }

            public void insert(int[] values, int i)
            {
                if (i >= values.Length)
                {
                    return;
                }
                List<InvertBinaryTreeClass.BinaryTree> queue = new List<InvertBinaryTreeClass.BinaryTree>();
                queue.Add(this);
                var index = 0;
                while (index < queue.Count)
                {
                    InvertBinaryTreeClass.BinaryTree current = queue[index];
                    index += 1;
                    if (current.left == null)
                    {
                        current.left = new InvertBinaryTreeClass.BinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.left);
                    if (current.right == null)
                    {
                        current.right = new InvertBinaryTreeClass.BinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.right);
                }
                insert(values, i + 1);
            }
        }
    }
}