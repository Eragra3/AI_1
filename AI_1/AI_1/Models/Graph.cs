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

        public string Print()
        {
            return "";
        }
    }
}
