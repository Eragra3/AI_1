using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Graph
    {
        public IList<Vertex> Vertices { get; set; }

        public IList<Edge> Edges { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>(1000);

            Edges = new List<Edge>(200);
        }

        public int GetMaxColor()
        {
            int k = 0;

            foreach (var vertex in Vertices)
            {
                if (vertex.Color > k)
                {
                    k = vertex.Color;
                }
            }

            return k;
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(new string('-', 50));
            result.AppendLine("GRAPH");
            result.AppendLine(string.Format("edges: {0} vertices: {1}", Edges.Count, Vertices.Count));
            result.AppendLine(string.Format("k: {0}", GetMaxColor()));

            foreach (var edge in Edges)
            {
                result.AppendLine(edge.Print());
            }
            foreach (var vertex in Vertices)
            {
                result.AppendLine(vertex.Print());
            }
            result.AppendLine(new string('-', 50));

            return result.ToString();
        }
    }
}
