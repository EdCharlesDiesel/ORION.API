using System;

namespace ORION.Core.FamousAlgorithms
{
    public class DijkstrasAlgorithmnClass
    {
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < verticesCount; i++)
            {
                if (shortestPathTreeSet[i] && distance[i] <= min)
                {
                    minIndex = i;
                    min = distance[i];
                }
            }

            return minIndex;
        }

        public static void Dijkstras(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount; count++)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;
                for (int v = 0; v < verticesCount; v++)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) &&
                        distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
            }
        }
    }
}