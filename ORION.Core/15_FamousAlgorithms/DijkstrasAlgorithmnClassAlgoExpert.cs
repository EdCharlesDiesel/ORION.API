using System;
using System.Collections.Generic;

namespace ORION.Core.FamousAlgorithms
{
    public static class DijkstrasAlgorithmnClassAlgoExpert
    {
        public static int[] DijkstrasAlgorithm(int start, int[][][] edges)
        {
            int numberOfVertices = edges.Length;

            int[] minDistances = new int[edges.Length];
            Array.Fill(minDistances, int.MaxValue);
            minDistances[start] = 0;

            HashSet<int> visited = new HashSet<int>();

            while (visited.Count != numberOfVertices)
            {
                int[] getVertexData = getVertextWithMinDistances(minDistances, visited);
                int vertex = getVertexData[0];
                int currentMinDistance = getVertexData[1];

                if (currentMinDistance == int.MaxValue)
                {
                    break;
                }

                visited.Add(vertex);

                foreach (var edge in edges[vertex])
                {
                    int destination = edge[0];
                    int distanceToDestination = edge[1];

                    if (visited.Contains(destination))
                    {
                        continue;
                    }

                    int newPathDistance = currentMinDistance + distanceToDestination;
                    int currentDestinationDistance = minDistances[destination];
                    if (newPathDistance < currentDestinationDistance)
                    {
                        minDistances[destination] = newPathDistance;
                    }
                }

            }

            int[] finalDestination = new int[minDistances.Length];
            for (int i = 0; i < minDistances.Length; i++)
            {
                int distance = minDistances[i];
                if (distance == int.MaxValue)
                {
                    finalDestination[i] = -1;
                }
                else
                {
                    finalDestination[i] = distance;
                }
            }

            return finalDestination;
        }

        private static int[] getVertextWithMinDistances(int[] minDistances, HashSet<int> visited)
        {
            int currentMinDistance = int.MaxValue;
            int vertex = -1;

            for (int vertexIndex = 0; vertexIndex < minDistances.Length; vertexIndex++)
            {
                int distance = minDistances[vertexIndex];

                if (visited.Contains(vertex))
                {
                    continue;
                }

                if (distance <= currentMinDistance)
                {
                    vertex = vertexIndex;
                    currentMinDistance = distance;
                }
            }

            return new int[] { currentMinDistance, vertex };
        }
    }
}
