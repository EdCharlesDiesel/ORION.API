namespace KnightConnection
{
    /// <summary>
    /// 
    /// </summary>
    public class KnightConnectionClass
    {
        public int KnightConnection(int[] knightA, int[] knightB)
        {
            int[,] possibleMoves = new int[8, 2] {

                {-2, 1 },
                {-1, 2 },
                {1, 2 },                
                {2,1 },                
                {2,-1 },                
                {1,-2 },
                {-1,-2 },
                {-2,-1 },
            };

            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue(new List<int> { knightA[0], knightA[1],0});
            HashSet<string> visited = new HashSet<string>();
            visited.Add(knightA.ToString()!);

            while (queue.Count>0)
            {
                List<int> currentPosition = queue.Dequeue();

            //    if (currentPosition[0] == knightB[0]&& currentPosition[1]==knightB)
            //    {
                    
            //    }
            }

            return -1;
        }
    }
}