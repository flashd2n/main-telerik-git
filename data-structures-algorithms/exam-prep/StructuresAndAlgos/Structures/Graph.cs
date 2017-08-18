using System;
using System.Collections.Generic;
using System.Linq;

namespace Structures
{
    public class Graph
    {
        public enum GraphType
        {
            Matrix = 1,
            AdjacencyList = 2,
            SetOfEdges = 3,
        }

        private readonly int verticesCount;
        private readonly int edgesCount;
        private readonly int[,] matrix;
        private readonly List<List<Node>> adjList;
        private readonly List<Edge> edgeList;
        private readonly Dictionary<int, string> dict;
        private int dictCount;

        public Graph(int vertices, int edgesCount, GraphType graphType)
        {
            this.verticesCount = vertices;
            this.edgesCount = edgesCount;
            this.dict = new Dictionary<int, string>(vertices + 1);
            this.dictCount = 1;

            if (graphType == GraphType.Matrix)
            {
                this.matrix = new int[vertices + 1, vertices + 1];
                this.adjList = null;
                this.edgeList = null;
            }
            else if (graphType == GraphType.AdjacencyList)
            {
                this.adjList = new List<List<Node>>(vertices + 1);

                for (int i = 0; i < vertices + 1; i++)
                {
                    this.adjList.Add(new List<Node>());
                }

                this.matrix = null;
                this.edgeList = null;
            }
            else if (graphType == GraphType.SetOfEdges)
            {
                this.matrix = null;
                this.adjList = null;
                this.edgeList = new List<Edge>(edgesCount * 2);
            }
            else
            {
                throw new Exception("Unrecognized graph type");
            }
        }

        public int[,] MatrixGraph => this.matrix;
        public List<List<Node>> AdjListGraph => this.adjList;
        public List<Edge> EdgeListGraph => this.edgeList;
        public Dictionary<int, string> Dictionary => this.dict;

        public void ReadEdges()
        {
            if (this.adjList != null)
            {
                this.FillAdjList();
                return;
            }
            else if (this.edgeList != null)
            {
                this.FillEdgeList();
                return;
            }
            else
            {
                this.FillMatrix();
                return;
            }
        }

        private void FillEdgeList()
        {
            for (int i = 0; i < this.edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').ToArray();

                if (!dict.ContainsValue(vertices[0]))
                {
                    dict.Add(dictCount, vertices[0]);
                    ++dictCount;
                }
                if (!dict.ContainsValue(vertices[1]))
                {
                    dict.Add(dictCount, vertices[1]);
                    ++dictCount;
                }

                var from = dict.First(x => x.Value == vertices[0]).Key;
                var to = dict.First(x => x.Value == vertices[1]).Key;

                var edge = new Edge();
                edge.From = from;
                edge.To = to;
                //edge.Weight = vertices[2];
                this.edgeList.Add(edge);

                var edgeTwo = new Edge();
                edgeTwo.From = to;
                edgeTwo.To = from;
                //edgeTwo.Weight = vertices[2];
                this.edgeList.Add(edgeTwo);
            }
        }

        private void FillAdjList()
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').ToArray();

                if (!dict.ContainsValue(vertices[0]))
                {
                    dict.Add(dictCount, vertices[0]);
                    ++dictCount;
                }
                if (!dict.ContainsValue(vertices[1]))
                {
                    dict.Add(dictCount, vertices[1]);
                    ++dictCount;
                }

                var from = dict.First(x => x.Value == vertices[0]).Key;
                var to = dict.First(x => x.Value == vertices[1]).Key;

                var node = new Node();
                node.Vertex = to;
                //node.Weight = int.Parse(vertices[2]);
                this.adjList[from].Add(node);

                var node2 = new Node();
                node2.Vertex = from;
                //node2.Weight = int.Parse(vertices[2]);
                this.adjList[to].Add(node2);
            }
        }

        private void FillMatrix()
        {
            for (int i = 0; i < this.edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').ToArray();

                if (!dict.ContainsValue(vertices[0]))
                {
                    dict.Add(dictCount, vertices[0]);
                    ++dictCount;
                }
                if (!dict.ContainsValue(vertices[1]))
                {
                    dict.Add(dictCount, vertices[1]);
                    ++dictCount;
                }

                var from = dict.First(x => x.Value == vertices[0]).Key;
                var to = dict.First(x => x.Value == vertices[1]).Key;
                //var weight = vertices[2];

                this.matrix[from, to] = 1;
                // undirected
                this.matrix[to, from] = 1;
            }
        }

    }
}
