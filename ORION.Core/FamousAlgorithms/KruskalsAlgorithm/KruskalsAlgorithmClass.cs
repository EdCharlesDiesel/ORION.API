using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalsAlgorithm
{
    /// <summary>
    /// You're given a list of edges representing a weighted,
    /// undirected graph with at least one node.
    /// 
    /// The given list is what is called adjaceny list, and it
    /// represents a graph. The number of vertices
    /// in the graph is equa t the length of the edges, where
    /// each index i in edges contains vertex i's siblings, in no
    /// particular order. Each of these siblings is an array of
    /// length two, with the first value  denoting the weight of 
    /// of the edge. Note that this graph is undirected, meaning 
    /// that if a vertexx appears in the edge list of another vertex
    /// then the inverse will be true(along with the same weight)
    /// 
    /// If the graph is not connected, your function should return
    /// the minimum spanning forest(ie all of
    /// the nodes should be able to reach the same nodes as they could
    /// in the initial list).
    /// 
    /// Note that the graph represented by edges won't contain any 
    /// self-loops (vertices that have an outbound edge to themselves)
    /// and will only have positively weighted edges (ie no negative
    /// distances).
    /// 
    ///  
    /// </summary>
    public class KruskalsAlgorithmClass
    {
        public int[][][] KruskalsAlgorithm(int[][][] edges)
        {
            List<List<int>> sortedEdges = new List<List<int>>();
            for (int sourceIndex = 0;sourceIndex < edges.Length;sourceIndex++)
            {
                foreach (var edge in edges[sourceIndex])
                {
                    if (edge[0]> sourceIndex)
                    {
                        sortedEdges.Add(new List<int> { sourceIndex, edge[0],edge[1] });
                    }
                }
            }
            sortedEdges.Sort((edge1,edge2)=> edge1[2] - edge2[2]);

            int[] parents = new int[edges.Length];
            int[] ranks = new int[edges.Length];
            List<List<int[]>> mst = new List<List<int[]>>();

            for (int i = 0; i < edges.Length; i++)
            {
                parents[i] = i;
                ranks[i] = 0;
                mst.Insert(i,new List<int[]>());
            }


            foreach (var edge in sortedEdges)
            {
                int vertext1Root = find(edge[0], parents);
                int vertext2Root = find(edge[1], parents);
                if (vertext1Root != vertext2Root)
                {
                    mst[edge[0]].Add(new int[] { edge[1], edge[2] });
                    mst[edge[1]].Add(new int[] { edge[0], edge[2] });
                Union(vertext1Root, vertext2Root,parents,ranks);
                }
            }


            int[][][] arrayMst= new int[edges.Length][][];
            for (int i = 0; i < mst.Count; i++)
            {
                arrayMst[i] = new int[mst[i].Count][];
                for (int j = 0; j < mst[i].Count; j++)
                {
                    arrayMst[i][j]= mst[i][j];
                }
            }

            return arrayMst;
        }

        private int find(int vertex, int[] parents)
        {
            if (vertex != parents[vertex])
            {
                parents[vertex] = find(parents[vertex], parents);
            }

            return parents[vertex];
        }

        private void Union(int vertex1Root, int vertex2Root, int[] parents, int[] ranks)
        {
            if (ranks[vertex1Root]< ranks[vertex2Root])
            {
                parents[vertex1Root] = vertex2Root;
            }else if (ranks[vertex1Root]> ranks[vertex2Root])
            {
                parents[vertex2Root] = vertex1Root;
            }
            else
            {
                parents[vertex2Root] = vertex1Root;
                ranks[vertex1Root]++;
            }
        }
    }
}