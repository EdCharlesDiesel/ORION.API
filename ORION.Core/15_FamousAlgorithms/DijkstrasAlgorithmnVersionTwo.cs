using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORION.Core.FamousAlgorithms
{
    internal class DijkstrasAlgorithmnVersionTwo
    {
        Dictionary<Node, int> Distances;
        Dictionary<Node, Node> Routes;
        Graph graph;
        List<Node> AllNodes;

        public DijkstrasAlgorithmnVersionTwo(Graph g)
        {
            graph = g;
            AllNodes = g.GetNodes();
            Distances = SetDistances();
            Routes = SetRoutes();
        }

        private Dictionary<Node, int> SetDistances()
        {
            Dictionary<Node, int> Distances = new Dictionary<Node, int>();

            foreach (Node n in graph.GetNodes())
            {
                Distances.Add(n, int.MaxValue);
            }
            return Distances;
        }

        private Dictionary<Node, Node> SetRoutes()
        {
            Dictionary<Node, Node> Routes = new Dictionary<Node, Node>();

            foreach (Node n in graph.GetNodes())
            {
                Routes.Add(n, null);
            }
            return Routes;
        }
    }

    class Graph
    {
        private List<Node> Nodes;

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public void Add(Node n)
        {
            Nodes.Add(n);
        }

        public void Remove(Node n)
        {
            Nodes.Remove(n);
        }

        public List<Node> GetNodes()
        {
            return Nodes.ToList();
        }

        public int getCount()
        {
            return Nodes.Count;
        }
    }

    class Node
    {
        private string Name;
        private Dictionary<Node, int> Neighbors;

        public Node(string NodeName)
        {
            Name = NodeName;
            Neighbors = new Dictionary<Node, int>();
        }

        public void AddNeighbour(Node n, int cost)
        {
            Neighbors.Add(n, cost);
        }

        public string getName()
        {
            return Name;
        }

        public Dictionary<Node, int> getNeighbors()
        {
            return Neighbors;
        }
    }
}
