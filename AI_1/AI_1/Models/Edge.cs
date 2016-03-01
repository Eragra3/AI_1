using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Edge
    {
        public int Vertex1ID { get; set; }

        public Vertex Vertex1 { get; set; }

        public int Vertex2ID { get; set; }

        public Vertex Vertex2 { get; set; }

        public int Weight { get; set; }

        public const char ABBREVIATION = 'e';
    }
}
