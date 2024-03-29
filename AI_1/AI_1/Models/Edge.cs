﻿using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Edge
    {
        public int Vertex1ID;

        public Vertex Vertex1;

        public int Vertex2ID;

        public Vertex Vertex2;

        public int Weight;

        public const char ABBREVIATION = 'e';

        public string Print()
        {
            var v1Id = Vertex1ID.ToString().PadLeft(3, ' ');
            var v2Id = Vertex2ID.ToString().PadLeft(3, ' ');
            var weight = Weight.ToString().PadLeft(3, ' ');

            var isValid = IsValid() ? string.Empty : "INVALID";

            return string.Format("{0} {1} {2} {3} {4}", ABBREVIATION, v1Id, v2Id, weight, isValid);
        }

        public string Print(IList<Gene> genes)
        {
            var v1Id = Vertex1ID.ToString().PadLeft(3, ' ');
            var v2Id = Vertex2ID.ToString().PadLeft(3, ' ');
            var weight = Weight.ToString().PadLeft(3, ' ');

            var isValid = IsValidWithColors(genes[Vertex1ID].color, genes[Vertex2ID].color);
            var isValidText = isValid ? string.Empty : "INVALID";

            return string.Format("{0} {1} {2} {3} {4}", ABBREVIATION, v1Id, v2Id, weight, isValidText);
        }

        public bool IsValidWithColors(int color1, int color2)
        {
            return Math.Abs(color1 - color2) >= Weight && color1 > 0 && color2 > 0;
        }

        public bool IsValid()
        {
            return Vertex1.Color > 0 && Vertex2.Color > 0 && Math.Abs(Vertex1.Color - Vertex2.Color) >= Weight;
        }
    }
}
