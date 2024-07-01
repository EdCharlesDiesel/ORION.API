namespace ORION.Core
{
    public class EvaluateExpressionTreeClass
    {
        public int EvaluateExpressionTree(BinaryTree tree)
        {
            if (tree.value >=0)
            {
                return tree.value;
            }

            int leftValue = EvaluateExpressionTree(tree.left);
            int rightValue = EvaluateExpressionTree(tree.right);

            if (tree.value ==-1) 
            {
                return leftValue + rightValue;
            }else if (tree.value == -2) 
            {
                return leftValue - rightValue;
            }
            else if (tree.value == -3) 
            {
                return leftValue / rightValue;
            }

            return leftValue * rightValue;
        }



        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
    }
  
}