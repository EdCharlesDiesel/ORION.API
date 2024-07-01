using System.Collections;

namespace MiddleNode
{
    public class MiddleNodeClass
    {
        public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

        public LinkedList MiddleNode(LinkedList linkedList)
        {
            LinkedList slowNode = linkedList;
            LinkedList fastnode = linkedList;
            while (fastnode != null && fastnode.next != null) 
            {
                slowNode = fastnode.next;
                fastnode = fastnode.next;
            }

            return slowNode;
        }
    }
}