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

        public Genotype GetRandomGenotype(Graph graph)
        {
            var genotype = new Genotype(graph.Edges, graph.VerticesIds, graph.MaxVertexID);

            for (int i = 0; !genotype.IsValid() && i < 1000; i++)
            {
                RandomizeColors(genotype);
            }

            return genotype;
        }

        public void RandomizeColors(Genotype genotype)
        {
            foreach (var edge in genotype.Edges)
            {
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
                    if (edge.IsValidWithColors(gene2.color, newBestColor))
                    {
                        gene1.color = newBestColor;
                    }
                    else {
                        newBestColor += Math.Abs(edge.Weight - gene2.color);
                    }
                }
                else if (gene2.color == 0)
                {
                    var newBestColor = GetRandomColor(edge.Weight, gene1.color);
                    if (edge.IsValidWithColors(gene1.color, newBestColor))
                    {
                        gene2.color = newBestColor;
                    }
                    else {
                        newBestColor += Math.Abs(edge.Weight - gene1.color);
                    }
                }
                else if (!edge.IsValidWithColors(gene1.color, gene2.color))
                {
                    var colors = FixColors(edge.Weight, gene1.color, gene2.color);
                    if (gene1.color < gene2.color)
                    {
                        gene1.color += colors.Item1;
                        gene2.color += colors.Item2;
                    }
                    else
                    {
                        gene2.color += colors.Item1;
                        gene1.color += colors.Item2;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<int, int> GetRandomColors(int weight)
        {
            var colorOffset = _random.Next(1, 11);

            return new Tuple<int, int>(colorOffset, 1 + weight + (int)(colorOffset * 1.2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetRandomColor(int edgeWeight, int nodeColor)
        {
            var newColor = nodeColor - edgeWeight;
            if (newColor < 1)
            {
                newColor = nodeColor + edgeWeight;
            }

            return newColor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<int, int> FixColors(int weight, int color1, int color2)
        {
            var newLowerColor = Math.Min(color1, color2);
            var newUpperColor = Math.Max(color1, color2);
            var solutionFound = false;

            while (!solutionFound && newLowerColor > 0)
            {
                newLowerColor--;

                solutionFound = CommonMethods.BCPIsValid(weight, newLowerColor, newUpperColor);
            }

            if (!solutionFound) newLowerColor = Math.Min(color1, color2);

            while (!solutionFound && newLowerColor > 0)
            {
                newLowerColor--;

                solutionFound = CommonMethods.BCPIsValid(weight, newLowerColor, newUpperColor);
                if (!solutionFound)
                {
                    newUpperColor++;

                    solutionFound = CommonMethods.BCPIsValid(weight, newLowerColor, newUpperColor);
                }
            }

            if (!solutionFound) newLowerColor = Math.Min(color1, color2);

            while (!solutionFound && newUpperColor < 1000)
            {
                newUpperColor++;

                solutionFound = CommonMethods.BCPIsValid(weight, newLowerColor, newUpperColor);
            }

            if (color1 < color2)
            {
                return new Tuple<int, int>(newLowerColor, newUpperColor);
            }
            else
            {
                return new Tuple<int, int>(newUpperColor, newLowerColor);
            }
        }
    }
}
