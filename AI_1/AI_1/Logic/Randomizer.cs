using AI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Logic
{
    public class Randomizer
    {
        private readonly Random _random;

        public Randomizer()
        {
            _random = new Random();
        }

        public void RandomizeColors(Graph graph)
        {
            foreach (var edge in graph.Edges)
            {
                if (edge.Vertex1.Color == 0 && edge.Vertex2.Color == 0)
                {
                    var colors = GetRandomColors(edge.Weight);

                    edge.Vertex1.Color = colors.Item1;
                    edge.Vertex2.Color = colors.Item2;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<int, int> GetRandomColors(int weight)
        {
            var colorOffset = weight / _random.Next(1, weight / 2);

            return new Tuple<int, int>(0 + 2 * colorOffset, weight + (1 - colorOffset));
        }

    }
}
