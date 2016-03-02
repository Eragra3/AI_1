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

        public string Print()
        {
            var v1Id = Vertex1ID.ToString().PadLeft(3, ' ');
            var v2Id = Vertex2ID.ToString().PadLeft(3, ' ');
            var weight = Weight.ToString().PadLeft(3, ' ');

            var isValid = IsValid() ? string.Empty : "INVALID";

            return string.Format("{0} {1} {2} {3} {4}", ABBREVIATION, v1Id, v2Id, weight, isValid);
        }

        public bool IsValid()
        {
            return Vertex1.Color > 0 && Vertex2.Color > 0 && Math.Abs(Vertex1.Color - Vertex2.Color) >= Weight;
        }
    }
}
