namespace FindLoop.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            TestLinkedList test = new TestLinkedList(0);
            test.addMany(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            test.getNthNode(10).next = test.getNthNode(5);
            Assert.True(FindLoopClass.FindLoop(test) == test.getNthNode(5));
        }
    }

    public class TestLinkedList : FindLoopClass.LinkedList
    {
        public TestLinkedList(int value) : base(value) { }

        public void addMany(int[] values)
        {
            FindLoopClass.LinkedList current = this;
            while (current.next != null)
            {
                current = current.next;
            }
            foreach (int value in values)
            {
                current.next = new FindLoopClass.LinkedList(value);
                current = current.next;
            }
        }

        public FindLoopClass.LinkedList getNthNode(int n)
        {
            int counter = 1;
            FindLoopClass.LinkedList current = this;
            while (counter < n)
            {
                current = current.next;
                counter++;
            }
            return current;
        }
    }
}