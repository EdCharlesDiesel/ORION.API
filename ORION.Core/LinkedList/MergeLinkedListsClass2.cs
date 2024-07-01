namespace ORION.Core.LinkedList
{
    internal class MergeLinkedListsClass2
    {
        // O(n + m) time | O(n + m) space - where n is the number of nodes in the first
        // Linked List and m is the number of nodes in the second Linked List
        public static LinkedList mergeLinkedLists(LinkedList headOne, LinkedList headTwo)
        {
            recursiveMerge(headOne, headTwo, null!);
            return headOne.value < headTwo.value ? headOne : headTwo;
        }
        public static void recursiveMerge(LinkedList p1, LinkedList p2, LinkedList p1Prev)
        {
            if (p1 == null)
            {
                p1Prev.next = p2;
                return;
            }
            if (p2 == null)
                return;
            if (p1.value < p2.value)
            {
                recursiveMerge(p1.next, p2, p1);
            }
            else
            {
                if (p1Prev != null)
                    p1Prev.next = p2;
                LinkedList newP2 = p2.next;
                p2.next = p1;
                recursiveMerge(p1, newP2, p2);
            }
        }
    }

    public class LinkedListClass2
    {
        public int value;
        public LinkedList next;
        public LinkedListClass2(int value)
        {
            this.value = value;
            this.next = null!;
        }
    }
}
