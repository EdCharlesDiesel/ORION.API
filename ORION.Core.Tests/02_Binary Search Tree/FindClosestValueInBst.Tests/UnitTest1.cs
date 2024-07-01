namespace FindClosestValueInBst.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var root = new FindClosestValueInBstClass.Bst(10);
            root.left = new FindClosestValueInBstClass.Bst(5);
            root.left.left = new FindClosestValueInBstClass.Bst(2);
            root.left.left.left = new FindClosestValueInBstClass.Bst(1);
            root.left.right = new FindClosestValueInBstClass.Bst(5);
            root.right = new FindClosestValueInBstClass.Bst(15);
            root.right.left = new FindClosestValueInBstClass.Bst(13);
            root.right.left.right = new FindClosestValueInBstClass.Bst(14);
            root.right.right = new FindClosestValueInBstClass.Bst(22);

            var expected = 13;
            var actual = FindClosestValueInBstClass.FindClosestValueInBst(root, 12);
            Assert.Equal(expected, actual);
        }
    }
}