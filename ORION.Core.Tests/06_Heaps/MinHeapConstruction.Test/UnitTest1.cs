namespace MinHeapConstruction.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}

//Program.MinHeap minHeap = new Program.MinHeap(new List<int>(
//   ) { 48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41 });
//minHeap.Insert(76);
//Utils.AssertTrue(isMinHeapPropertySatisfied(minHeap.heap));
//Utils.AssertTrue(minHeap.Peek() == -5);
//Utils.AssertTrue(minHeap.Remove() == -5);
//Utils.AssertTrue(isMinHeapPropertySatisfied(minHeap.heap));
//Utils.AssertTrue(minHeap.Peek() == 2);
//Utils.AssertTrue(minHeap.Remove() == 2);
//Utils.AssertTrue(isMinHeapPropertySatisfied(minHeap.heap));
//Utils.AssertTrue(minHeap.Peek() == 6);
//minHeap.Insert(87);
//Utils.AssertTrue(isMinHeapPropertySatisfied(minHeap.heap));
//  }

//  bool isMinHeapPropertySatisfied(List<int> array)
//{
//    for (int currentIdx = 1; currentIdx < array.Count; currentIdx++)
//    {
//        int parentIdx = (currentIdx - 1) / 2;
//        if (parentIdx < 0)
//        {
//            return true;
//        }
//        if (array[parentIdx] > array[currentIdx])
//        {
//            return false;
//        }
//    }

//    return true;
//}
//}