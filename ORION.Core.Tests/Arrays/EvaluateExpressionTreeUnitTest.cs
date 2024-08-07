using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace EvaluateExpressionTree.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            EvaluateExpressionTreeClass.BinaryTree tree = new EvaluateExpressionTreeClass.BinaryTree(-1);
            tree.left = new EvaluateExpressionTreeClass.BinaryTree(2);
            tree.right = new EvaluateExpressionTreeClass.BinaryTree(-2);
            tree.right.left = new EvaluateExpressionTreeClass.BinaryTree(5);
            tree.right.right = new EvaluateExpressionTreeClass.BinaryTree(1);
            var expected = 6;
            var actual = new EvaluateExpressionTreeClass().EvaluateExpressionTree(tree);
            Assert.True(expected == actual);
        }
    }
}