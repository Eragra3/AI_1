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
        private readonly Random _random;

        public Randomizer()
        {
            _random = new Random();
        }

        public Phenotype GetRandomGenotype(Graph graph)
        {
            var genotype = new Phenotype(graph.Edges, graph.VerticesIds, graph.MaxVertexID);

            int colorLimit = 150;

            InitialRoll(genotype);

            while (!genotype.IsValid())
            {
                for (int i = 0; !genotype.IsValid() && i < 100; i++)
                {
                    RandomizeColors(genotype, colorLimit);
                }
                colorLimit += 100;
            }

            return genotype;
        }

        public void InitialRoll(Phenotype genotype)
        {
            foreach (int i in Enumerable.Range(0, genotype.Edges.Count).OrderBy(x => _random.Next()))
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
                    var newBestColor = GetRandomColor(edge.Weight, gene2.color);

                    gene1.color = newBestColor;
                }
                else if (gene2.color == 0)
                {
                    var newBestColor = GetRandomColor(edge.Weight, gene1.color);

                    gene2.color = newBestColor;
                }
            }
        }

        public void RandomizeColors(Phenotype genotype, int colorLimit)
        {
            foreach (int i in Enumerable.Range(0, genotype.Edges.Count).OrderBy(x => _random.Next()))
            {
                var edge = genotype.Edges[i];
                var gene1 = genotype.Genes[edge.Vertex1ID];
                var gene2 = genotype.Genes[edge.Vertex2ID];

                if (!edge.IsValidWithColors(gene1.color, gene2.color))
                {
                    var colors = FixColors(edge.Weight, gene1.color, gene2.color, colorLimit);
                    if (gene1.color < gene2.color)
                    {
                        gene1.color = colors.Item1;
                        gene2.color = colors.Item2;
                    }
                    else
                    {
                        gene2.color = colors.Item1;
                        gene1.color = colors.Item2;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<int, int> GetRandomColors(int weight)
        {
            var colorOffset = _random.Next(1, weight * 5);

            var lowerColor = (int)(colorOffset * (0.5 + _random.NextDouble()));

            var upperColor = (int)(1 + weight + colorOffset * (0.5 + _random.NextDouble()));

            return new Tuple<int, int>(lowerColor, upperColor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetRandomColor(int weight, int nodeColor)
        {
            int newColor = nodeColor;
            bool solutionFound = false;

            while (!solutionFound && newColor > 0)
            {
                newColor -= _random.Next(1, 4);

                solutionFound = CommonMethods.BCPIsValid(weight, newColor, nodeColor);
            }

            if (!solutionFound) newColor = nodeColor;

            while (!solutionFound)
            {
                newColor += _random.Next(1, 4);

                solutionFound = CommonMethods.BCPIsValid(weight, newColor, nodeColor);
            }

            return newColor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<int, int> FixColors(int weight, int color1, int color2, int maxColor)
        {
            var newLowerColor = Math.Min(color1, color2);
            var newUpperColor = Math.Max(color1, color2);
            var solutionFound = false;

            while (!solutionFound &&
                newLowerColor > 0 &&
                newLowerColor < maxColor &&
                newUpperColor > 0 &&
                newUpperColor < maxColor)
            {
                newLowerColor += _random.Next(-3, 4);

                solutionFound = CommonMethods.BCPIsValid(weight, newLowerColor, newUpperColor);
                if (!solutionFound)
                {
                    newUpperColor += _random.Next(-3, 4);

                    solutionFound = CommonMethods.BCPIsValid(weight, newLowerColor, newUpperColor);
                }
            }

            newLowerColor = newLowerColor.Clamp(1, maxColor);
            newUpperColor = newUpperColor.Clamp(1, maxColor);

            return new Tuple<int, int>(
                Math.Min(newLowerColor, newUpperColor),
                Math.Max(newLowerColor, newUpperColor));
        }
    }
}
