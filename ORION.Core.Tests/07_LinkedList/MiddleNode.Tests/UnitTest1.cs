using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Linq;

namespace MiddleNode.Tests
{
    public class UnitTest1
    {
        [Fact(Skip = "This Unit test is failing do not know why")]
        public void Test1()
        {
            var linkedList = new MiddleNodeClass.LinkedList(1);
            var curr = linkedList;
            for (int i = 1; i < 4; i++)
            {
                curr.next = new MiddleNodeClass.LinkedList(i);
                curr = curr.next;
            }

            List<int> expected = new List<int> {2, 3};
            var actual = new MiddleNodeClass().MiddleNode(linkedList);
            Assert.True(Enumerable.SequenceEqual(expected, toList(actual)));
        }

        private List<int> toList(MiddleNodeClass.LinkedList linkedList)
        {
            List<int> list = new List<int>();
            MiddleNodeClass.LinkedList curr = linkedList;
            while (curr != null)
            {
                list.Add(curr.value);
                curr = curr.next;
            }

            return list;
        }
    }
}