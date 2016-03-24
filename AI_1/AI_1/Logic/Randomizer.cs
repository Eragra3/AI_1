using AI_1.Extensions;
using AI_1.Helpers;
using AI_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Logic
{
    public class Randomizer
    {
        [ThreadStatic]
        private static Random _threadLocalRandom;

        private static Random _random
        {
            get
            {
                if (_threadLocalRandom == null)
                {
                    _threadLocalRandom = new Random();
                }
                return _threadLocalRandom;
            }
        }

        public static Genotype GetRandomGenotype(Graph graph)
        {
            var genotype = new Genotype(graph.Edges, graph.VerticesIds, graph.MaxVertexID);

            InitialRoll(genotype);

            return genotype;
        }

        public static void InitialRoll(Genotype genotype)
        {
            foreach (int i in Enumerable.Range(0, genotype.Edges.Length).OrderBy(x => _random.Next()))
            {
                var edge = genotype.Edges[i];
                var gene1 = genotype.Genes[edge.Vertex1ID];
                if (gene1 == null)
                {
                    genotype.Genes[edge.Vertex1ID] = new Gene(edge.Vertex1ID);
                    gene1 = genotype.Genes[edge.Vertex1ID];
                }
                var gene2 = genotype.Genes[edge.Vertex2ID];
                if (gene2 == null)
                {
                    genotype.Genes[edge.Vertex2ID] = new Gene(edge.Vertex2ID);
                    gene2 = genotype.Genes[edge.Vertex2ID];
                }

                if (gene1.color == 0 && gene2.color == 0)
                {
                    var colors = GetRandomColors(edge.Weight);

                    gene1.color = colors.Item1;
                    gene2.color = colors.Item2;
                }
                else if (gene1.color == 0)
                {
                    var newColor = GetRandomColor();

                    gene1.color = newColor;
                }
                else if (gene2.color == 0)
                {
                    var newColor = GetRandomColor();

                    gene2.color = newColor;
                }
            }
        }

        private static Tuple<int, int> GetRandomColors(int weight)
        {
            var color1 = GetRandomColor();
            int color2 = GetRandomColor();

            return new Tuple<int, int>(color1, color2);
        }

        public static int GetRandomColor()
        {
            return _random.Next(1, Configuration.ColorsCount + 1);
        }
    }
}
