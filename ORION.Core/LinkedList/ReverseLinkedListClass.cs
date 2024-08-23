namespace ORION.Core.LinkedList
{
    public class ReverseLinkedListClass
    {
        // O(n) time | O(1) space - where n is the number of nodes in the Linked List
        public static LinkedList ReverseLinkedList(LinkedList head)
        {
            LinkedList p1 = null;
            LinkedList p2 = head;
            while (p2 != null)
            {
                LinkedList p3 = p2.Next;
                p2.Next = p1;
                p1 = p2;
                p2 = p3;
            }
            return p1;
        }
        public class LinkedList
        {
            public int Value;
            public LinkedList Next = null;
            public LinkedList(int value)
            {
                this.Value = value;
            }
        }
    }
}


