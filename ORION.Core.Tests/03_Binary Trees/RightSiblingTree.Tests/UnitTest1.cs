namespace RightSiblingTree.Tests
{
    public class UnitTest1
    {
        [Fact(Skip = "Fix later")   ]
        public void Test1()
        {

        }
    }
}


//Program.BinaryTree root = new Program.BinaryTree(1);
//insert(root, new int[] { 2, 3, 4, 5, 6, 7, 8, 9 });
//root.left.right.right = new Program.BinaryTree(10);
//root.right.left.left = new Program.BinaryTree(11);
//root.right.right.left = new Program.BinaryTree(12);
//root.right.right.right = new Program.BinaryTree(13);
//root.right.left.left.left = new Program.BinaryTree(14);
//Program.BinaryTree mutatedRoot = Program.RightSiblingTree(root);
//List<int> actual = getDfsOrder(mutatedRoot);
//var expected = new List<int> {
//      1, 2, 4, 8, 9, 5, 6, 11, 14, 7, 12, 13, 3, 6, 11, 14, 7, 12, 13
//    };
//Utils.AssertTrue(expected.SequenceEqual(actual));
//  }

//  public void insert(Program.BinaryTree root, int[] values)
//{
//    insert(root, values, 0);
//}

//public void insert(Program.BinaryTree root, int[] values, int i)
//{
//    if (i >= values.Length)
//    {
//        return;
//    }
//    Queue<Program.BinaryTree> queue = new Queue<Program.BinaryTree>();
//    queue.Enqueue(root);
//    while (queue.Count > 0)
//    {
//        Program.BinaryTree current = queue.Dequeue();
//        if (current.left == null)
//        {
//            current.left = new Program.BinaryTree(values[i]);
//            break;
//        }
//        queue.Enqueue(current.left);
//        if (current.right == null)
//        {
//            current.right = new Program.BinaryTree(values[i]);
//            break;
//        }
//        queue.Enqueue(current.right);
//    }
//    insert(root, values, i + 1);
//}

//public List<int> getDfsOrder(Program.BinaryTree tree)
//{
//    List<int> values = new List<int>();
//    values.Add(tree.value);
//    if (tree.left != null)
//    {
//        values.AddRange(getDfsOrder(tree.left));
//    }
//    if (tree.right != null)
//    {
//        values.AddRange(getDfsOrder(tree.right));
//    }
//    return values;
//}