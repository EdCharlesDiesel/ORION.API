

using System;

namespace ORION.Core.LinkedList
{
    public class ShiftLinkedListClass
    {
        // O(n) time | O(1) space - where n is the number of nodes in the Linked List
        public static LinkedList_ ShiftLinkedList(LinkedList_ head, int k)
        {
            //int listLength = 1;
            //LinkedList_ listTail = head;
            //while (listTail.next != null)
            //{
            //    listTail = listTail.next;
            //    listLength++;
            //}
            //int offset = Math.Abs(k) % listLength;
            //if (offset == 0) return head;
            //int newTailPosition = k > 0 ? listLength - offset : offset;
            //LinkedList newTail = head;
            //for (int i = 1; i < newTailPosition; i++)
            //{
            //    newTail = newTail.next;
            //}
            //LinkedList newHead = newTail.next;
            //newTail.next = null;
            //listTail.next = head;
            //return newHead;

            throw new NotImplementedException();
        }

    }

    public class LinkedList_
    {
        public int value;
        public LinkedList next;
        public LinkedList_(int value)
        {
            this.value = value;
            next = null;
        }
    }
}