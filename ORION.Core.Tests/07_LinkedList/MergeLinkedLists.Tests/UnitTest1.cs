namespace MergeLinkedLists.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="Fix this")]
        public void Test1()
        {
            //TestLinkedList list1 = new TestLinkedList(2);
            //list1.addMany(new List<int>() { 6, 7, 8 });
            //TestLinkedList list2 = new TestLinkedList(1);
            //list2.addMany(new List<int>() { 3, 4, 5, 9, 10 });
            //TestLinkedList output =
            //  (TestLinkedList)Program.mergeLinkedLists(list1, list2);
            //List<int> expectedNodes = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Utils.AssertTrue(output.getNodesInArray().SequenceEqual(expectedNodes));
        }
    }

    //public class TestLinkedList : MergeLinkedListsClass.LinkedList
    //{
    //    public TestLinkedList(int val) : base(val) { }

    //    public TestLinkedList addMany(List<int> values)
    //    {
    //        TestLinkedList current = this;
    //        while (current.next != null)
    //        {
    //            current = (TestLinkedList)current.next;
    //        }
    //        foreach (int value in values)
    //        {
    //            current.next = new TestLinkedList(value);
    //            current = (TestLinkedList)current.next;
    //        }
    //        return this;
    //    }

    //    public List<int> getNodesInArray()
    //    {
    //        List<int> nodes = new List<int>();
    //        TestLinkedList current = this;
    //        while (current != null)
    //        {
    //            nodes.Add(current.value);
    //            current = (TestLinkedList)current.next;
    //        }
    //        return nodes;
    //    }
    //}
}