using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Graph
    {
        // use an adjacency matrix -- faster than an adjacency list
        private bool[,] adjacency;
        public bool[,] Adjacency
        {
            get
            {
                return adjacency;
            }
        }

        public Graph(bool[,] adjacency)
        {
            if (adjacency.GetLength(0) != adjacency.GetLength(1))
                throw new GraphAdjacencyException($"Graph adjacency should be a square 2-dimensional array; is {adjacency.GetLength(0)}x{adjacency.GetLength(1)}");

            this.adjacency = adjacency;
        }

        // returns a List of the indices of the vertices that are connected to `vertex`
        // we can then use this to iterate over and draw lines (arcs) to each connected vertex
        // NB. in the drawing system, use this for a breadth-first traversal -- *make sure to keep track of completed arcs*
        public List<int> GetConnectedVertices(int vertex)
        {
            List<int> connectedVertices = new List<int>();
            int verticesToCheck = adjacency.GetLength(0); // precalculate for speed

            for(int i = 0; i < verticesToCheck; i++)
            {
                if (adjacency[vertex, i]) connectedVertices.Add(i);
            }

            return connectedVertices;
        }
    }
    public class GraphAdjacencyException : Exception
    {
        public GraphAdjacencyException(string error) : base(error) { }
    }
}
