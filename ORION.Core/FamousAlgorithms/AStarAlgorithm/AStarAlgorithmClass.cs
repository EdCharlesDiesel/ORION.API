using System;
using System.Collections.Generic;

namespace AStarAlgorithm
{
    public class AStarAlgorithmClass
    {
        public int[][] AStarAlgorithm(int startRow, int startCol, int endRow, int endCol, int[][] graph)
        {
            List<List<Node>> nodes = initializeNodes(graph);
            Node startNode = nodes[startRow][startCol];
            Node endNode= nodes[endRow][endCol];

            startNode.distanceFromStart = 0;
            startNode.estimatedDistanceToEnd = 
                calculateManhattanDistance(startNode, endNode);

            List<Node> nodesToVisitList= new List<Node>();  
            nodesToVisitList.Add(startNode);
            MinHeap nodesToVisit = new MinHeap(nodesToVisitList);

            while (!nodesToVisit.isEmpty())
            {
                Node currentMinDistanceNode = nodesToVisit.Remove();
                if (currentMinDistanceNode == endNode) 
                {
                    break;
                }

                List<Node> neighbors = getNeighboringNodes(currentMinDistanceNode, nodes);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.value ==1)
                    {
                        continue;
                    }

                    int tentativeDistanceToNeighbor = currentMinDistanceNode.distanceFromStart + 1;
                    if (tentativeDistanceToNeighbor >= neighbor.distanceFromStart)
                    {
                        continue;
                    }

                    neighbor.cameFrom = currentMinDistanceNode;
                    neighbor.distanceFromStart = tentativeDistanceToNeighbor;
                    neighbor.estimatedDistanceToEnd= tentativeDistanceToNeighbor + 
                        calculateManhattanDistance(neighbor,endNode);

                    if (!nodesToVisit.ContainsNode(neighbor))
                    {
                        nodesToVisit.Insert(neighbor);
                    }
                    else
                    {
                        nodesToVisit.Update(neighbor);
                    }
                }
            }

            return reconstructPath(endNode);
        }

        private int[][] reconstructPath(Node endNode)
        {
            if (endNode.cameFrom ==null)
            {
                return new int[][] { };
            }

            Node currentNode=endNode;
            List<List<int>> path = new List<List<int>>();

            while (currentNode !=null)
            {
                List<int> nodeData= new List<int>();
                nodeData.Add(currentNode.row);
                nodeData.Add(currentNode.col);
                path.Add(nodeData);
                currentNode = currentNode.cameFrom;
            }

            // convert path to return type int[][] and reverse
            int[][] res = new int[path.Count][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = path[res.Length - 1 - i].ToArray();
            }

            return res;
        }

        private List<List<Node>> initializeNodes(int[][] graph)
        {
            List<List<Node>> nodes = new List<List<Node>> ();

            for (int i = 0;i < graph.Length; i++)
            {
                List<Node> nodeslist = new List<Node> ();
                nodes.Add(nodeslist);
                for (int j = 0; j < graph[j].Length; j++)
                {
                    nodes[i].Add(new Node(i, j, graph[i][j]));
                }
            }       

            return nodes;
        }

        int calculateManhattanDistance(Node currentNode, Node endNode)
        {
            int currentRow = currentNode.row;
            int currentCol = currentNode.col;
            int endRow=endNode.row;
            int endCol=endNode.col;

            return Math.Abs(currentRow -endRow) + Math.Abs(currentCol -endRow);
        }    


        List<Node> getNeighboringNodes(Node node, List<List<Node>> nodes)
        {
            List<Node> neighbors = new List<Node>();

            int numberRows = nodes.Count;
            int numberColumns = nodes[0].Count;

            int row = node.row;
            int col = node.col;

            if (row < numberRows - 1) //Down
            {
                neighbors.Add(nodes[row + 1][col]);
            }

            if (row > 0) //Up
            {
                neighbors.Add(nodes[row - 1][col]);
            }

            if (col < numberColumns - 1) //Down
            {
                neighbors.Add(nodes[row][col + 1]);
            }

            if (col > 0) //Left
            {
                neighbors.Add(nodes[row][col - 1]);
            }

            return neighbors;
        }

    }

    public class Node
    {
        public string id;
        public int row;
        public int col;
        public int value;
        public int distanceFromStart;
        public int estimatedDistanceToEnd;
        public Node cameFrom;
        public Node(int row, int col, int value)
        {
            this.id = row.ToString() + '-' + col.ToString();
            this.row = row;
            this.col = col;
            this.value = value;
            this.distanceFromStart = Int32.MaxValue;
            this.estimatedDistanceToEnd = Int32.MaxValue;
            this.cameFrom = null;
        }
    };

    public class MinHeap
    {
        List<Node> heap = new List<Node>();
        Dictionary<string, int> nodePositionsInHeap = new Dictionary<string, int>();
        public MinHeap(List<Node> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                Node node = array[i];
                nodePositionsInHeap[node.id] = i;
            }
            heap = buildHeap(array);
        }

        List<Node> buildHeap(List<Node> array)
        {
            int firstParentIndex = (array.Count - 2) / 2;
            for (int currentIndex = firstParentIndex + 1; currentIndex >= 0; currentIndex++)
            {
                shiftDown(currentIndex, array.Count - 1, array);
            }
            return array;
        }

        void shiftDown(int currentIndex, int endIndex, List<Node> array)
        {
            int childOneIndex = currentIndex * 2 + 1;
            while (childOneIndex <= endIndex)
            {
                int childTwoIndex = currentIndex * 2 + 2 <= endIndex ? currentIndex * 2 + 2 : -1;
                int indexToSwap;

                if (childOneIndex != -1 && array[childTwoIndex].estimatedDistanceToEnd < heap[childOneIndex].estimatedDistanceToEnd)
                {
                    indexToSwap = childTwoIndex;
                }
                else
                {
                    indexToSwap = childOneIndex;
                }

                if (array[indexToSwap].estimatedDistanceToEnd < array[currentIndex].estimatedDistanceToEnd)
                {
                    swap(currentIndex, indexToSwap);
                    currentIndex = indexToSwap;
                    childOneIndex = currentIndex * 2 + 1;
                }
                else
                {
                    return;
                }
            }
        }

        //O(log(n)) time | O(1) space
        void shiftUp(int currentIndex)
        {
            int parentIndex = (currentIndex - 1) / 2;
            while (currentIndex > 0 && heap[currentIndex].estimatedDistanceToEnd < heap[parentIndex].estimatedDistanceToEnd)
            {
                swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = (parentIndex - 1) / 2;
            }
        }

        public Node Remove()
        {
            if (isEmpty())
            {
                return null;
            }

            swap(0, heap.Count - 1);
            Node node = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            nodePositionsInHeap.Remove(node.id);
            shiftDown(0, heap.Count - 1, heap);
            return node;
        }

        public bool isEmpty()
        {
            return heap.Count == 0;
        }

        public void Insert(Node node)
        {
            heap.Add(node);
            nodePositionsInHeap[node.id] = heap.Count - 1;
            shiftUp(heap.Count - 1);
        }

        public void Update(Node node)
        {
            shiftUp(nodePositionsInHeap[node.id]);
        }

        public bool ContainsNode(Node node)
        {
            return nodePositionsInHeap.ContainsKey(node.id);
        }

        void swap(int currentIndex, int indexToSwap)
        {
            nodePositionsInHeap[heap[currentIndex].id] = indexToSwap;
            nodePositionsInHeap[heap[indexToSwap].id] = currentIndex;
            Node temp = heap[currentIndex];
            heap[currentIndex] = heap[indexToSwap];
            heap[indexToSwap] = temp;
        }
    }
}