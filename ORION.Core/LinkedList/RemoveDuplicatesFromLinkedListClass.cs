namespace ORION.Core.LinkedList
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveDuplicatesFromLinkedListClass
    {
        public LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList) 
        {
            LinkedList currentNode = linkedList;
            while (currentNode != null) 
            {
                LinkedList nextDistince = currentNode.next;
                while (nextDistince != null && nextDistince.value == currentNode.value)
                {
                    nextDistince = nextDistince.next;
                }

                currentNode.next = nextDistince;
                currentNode = nextDistince;
            }

            return linkedList;
        }
    }

    public class LinkedList
    {
        public int value;
        public LinkedList next = null;
        public LinkedList(int value)
        {
            this.value = value;
        }
    }
}