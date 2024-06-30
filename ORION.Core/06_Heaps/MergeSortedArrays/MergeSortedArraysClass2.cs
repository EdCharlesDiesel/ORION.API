//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MergeSortedArrays
//{
//    internal class MergeSortedArraysClass2
//    {
//        // O(nlog(k) + k) time | O(n + k) space - where where n is the total
//        // number of array elements and k is the number of arrays
//        public static List<int> MergeSortedArrays(List<List<int>> arrays)
//        {
//            List<int> sortedList = new List<int>();
//            List<Item> smallestItems = new List<Item>();
//            for (int arrayIdx = 0; arrayIdx < arrays.Count; arrayIdx++)
//            {
//                smallestItems.Add(new Item(arrayIdx, 0, arrays[arrayIdx][0]));
//            }
//            MinHeap minHeap = new MinHeap(smallestItems);
//            while (!minHeap.isEmpty())
//            {
//                Item smallestItem = minHeap.Remove();
//                sortedList.Add(smallestItem.num);
//                if (smallestItem.elementIdx ==
//                arrays[smallestItem.arrayIdx].Count - 1) continue;
//                minHeap.Insert(new Item(
//                smallestItem.arrayIdx,
//                smallestItem.elementIdx + 1,
//                arrays[smallestItem.arrayIdx][smallestItem.elementIdx + 1]
//                ));
//            }
//            return sortedList;
//        }
//    }

//    //public class Item
//    //{
//    //    public int arrayIdx;
//    //    public int elementIdx;
//    //    public int num;
//    //    public Item(int arrayIdx, int elementIdx, int num)
//    //    {
//    //        this.arrayIdx = arrayIdx;
//    //        this.elementIdx = elementIdx;
//    //        this.num = num;
//    //    }
//    //}

//    public class MinHeap
//    {
//        List<Item> heap = new List<Item>();
//        public MinHeap(List<Item> array)
//        {
//            heap = buildHeap(array);
//        }
//        public bool isEmpty()
//        {
//            return heap.Count == 0;
//        }
//        public List<Item> buildHeap(List<Item> array)
//        {
//            int firstParentIdx = (array.Count - 2) / 2;
//            for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
//            {
//                siftDown(currentIdx, array.Count - 1, array);
//            }
//            return array;
//        }
//        public void siftDown(int currentIdx, int endIdx, List<Item> heap)
//        {
//            int childOneIdx = currentIdx * 2 + 1;
//            while (childOneIdx <= endIdx)
//            {
//                int childTwoIdx = currentIdx * 2 + 2 <=
//                endIdx ? currentIdx * 2 + 2 : -1;
//                int idxToSwap;
//                if (childTwoIdx != -1 &&
//                heap[childTwoIdx].num < heap[childOneIdx].num)
//                {
//                    idxToSwap = childTwoIdx;
//                }
//                else
//                {
//                    idxToSwap = childOneIdx;
//                }
//                if (heap[idxToSwap].num < heap[currentIdx].num)
//                {
//                    swap(currentIdx, idxToSwap, heap);
//                    currentIdx = idxToSwap;
//                    childOneIdx = currentIdx * 2 + 1;
//                }
//                else
//                {
//                    return;
//                }
//            }
//        }

//        public void siftUp(int currentIdx, List<Item> heap)
//        {
//            int parentIdx = (currentIdx - 1) / 2;
//            while (currentIdx > 0 && heap[currentIdx].num < heap[parentIdx].num)
//            {
//                swap(currentIdx, parentIdx, heap);
//                currentIdx = parentIdx;
//                parentIdx = (currentIdx - 1) / 2;
//            }
//        }
//        public Item Remove()
//        {
//            swap(0, heap.Count - 1, heap);
//            Item valueToRemove = heap[heap.Count - 1];
//            heap.RemoveAt(heap.Count - 1);
//            siftDown(0, heap.Count - 1, heap);
//            return valueToRemove;
//        }
//        public void Insert(Item value)
//        {
//            heap.Add(value);
//            siftUp(heap.Count - 1, heap);
//        }
//        public void swap(int i, int j, List<Item> heap)
//        {
//            Item temp = heap[j];
//            heap[j] = heap[i];
//            heap[i] = temp;
//        }
//    }
//}
