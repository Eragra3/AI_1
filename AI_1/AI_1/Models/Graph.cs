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

        public int VerticesCount
        {
            get
            {
                return Vertices?.Count ?? 0;
            }
        }

        public int MaxVertexID { get; set; }

        public IList<int> VerticesIds { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>(1000);

            Edges = new List<Edge>(200);

            VerticesIds = new List<int>(200);
        }

        public int GetHighestColor()
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

        public int GetColorsCount()
        {
            IList<int> colors = new List<int>(20);

            foreach (var vertex in Vertices)
            {
                if (!colors.Contains(vertex.Color))
                {
                    colors.Add(vertex.Color);
                }
            }

            return colors.Count;
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(new string('-', 50));
            result.AppendLine("GRAPH");
            result.AppendLine(string.Format("edges: {0} vertices: {1}", Edges.Count, Vertices.Count));
            result.AppendLine(string.Format("colors: {0} k: {1}", GetColorsCount(), GetHighestColor()));

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

        public bool IsValid()
        {
            var IsValid = true;
            for (int i = 0; IsValid && i < Edges.Count; i++)
            {
                IsValid = Edges[i].IsValid();
            }

            return IsValid;
        }
    }
}
