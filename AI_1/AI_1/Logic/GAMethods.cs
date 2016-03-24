using AI_1.Extensions;
using AI_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Random;

namespace AI_1.Logic
{
    public partial class GAExecutor
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

        public static string GetDumpHeader()
        {
            return "generation,colors,k,valid,fitness,invalidEdges";
        }

        public static double GetFitness(Genotype specimen)
        {
            if (specimen == null) return double.NegativeInfinity;

            var maxColor = 0;

            if (Configuration.MaxColorWeight != 0)
            {
                maxColor = specimen.GetMaxColor();
            }

            var penalty = GetPenalty(specimen);

            return Configuration.MaxColorWeight * -maxColor - (1 - Configuration.MaxColorWeight) * penalty;
        }

        public static double GetPenalty(Genotype specimen)
        {
            double penalty = 0;
            int color1;
            int color2;
            Edge edge;
            var edges = specimen.Edges;
            for (int i = 0; i < specimen.Edges.Length; i++)
            {
                edge = edges[i];
                color1 = specimen.Genes[edge.Vertex1ID].color;
                color2 = specimen.Genes[edge.Vertex2ID].color;

                if (!edge.IsValidWithColors(color1, color2))
                {
                    penalty += edge.Weight - Math.Abs(color1 - color2);
                }
            }
            return penalty;
        }


        public Tuple<Genotype, Genotype> CrossoverPOP(Genotype parent1, Genotype parent2)
        {
            var child1 = new Genotype(LoadedGraph.Edges, LoadedGraph.VerticesIds, parent1.MaxID);
            var child2 = new Genotype(LoadedGraph.Edges, LoadedGraph.VerticesIds, parent1.MaxID);
            var cutPosition = _random.Next(1, parent1.Genes.Length);

            var child1Genes = child1.Genes;
            var child2Genes = child2.Genes;
            var parent1Genes = parent1.Genes;
            var parent2Genes = parent2.Genes;

            for (int i = 0; i < cutPosition; i++)
            {
                if (parent1Genes[i] != null)
                {
                    child1Genes[i].color = parent1Genes[i].color;
                }
                if (parent2Genes[i] != null)
                {
                    child2Genes[i].color = parent2Genes[i].color;
                }
            }

            for (int i = cutPosition; i < parent2.Genes.Length; i++)
            {
                if (parent2Genes[i] != null)
                {
                    child1Genes[i].color = parent2Genes[i].color;
                }
                if (parent1Genes[i] != null)
                {
                    child2Genes[i].color = parent1Genes[i].color;
                }
            };

            return new Tuple<Genotype, Genotype>(child1, child2);
        }

        public Tuple<Genotype, Genotype> CrossoverMOX(Genotype parent1, Genotype parent2)
        {
            var genesPool = parent1.Genes.Skip(1).Concat(parent2.Genes.Skip(1)).ToList();
            genesPool.Shuffle();

            var child1 = new Genotype(LoadedGraph.Edges, parent1.MaxID);
            var child2 = new Genotype(LoadedGraph.Edges, parent1.MaxID);

            for (int i = 0; i < genesPool.Count; i++)
            {
                var gene = genesPool[i];
                if (child2.Genes[gene.id] == null)
                {
                    child2.Genes[gene.id] = gene;
                }
                else
                {
                    child1.Genes[gene.id] = gene;
                }
            }

            return new Tuple<Genotype, Genotype>(child1, child2);
        }

        public void MutateRandomIncrement(Genotype specimen)
        {
            foreach (var gene in specimen.Genes)
            {
                if (!(_random.NextDouble() < Configuration.MutationRate) ||
                    gene == null) continue;

                bool increment;
                int colorIncr;
                do
                {
                    var pseudoNormalDistribution = _random.Next(0, 100);
                    increment = _random.Next(0, 2) > 0;

                    if (pseudoNormalDistribution < 45)
                    {
                        colorIncr = 1;
                    }
                    else if (pseudoNormalDistribution < 67)
                    {
                        colorIncr = 2;
                    }
                    else if (pseudoNormalDistribution < 90)
                    {
                        colorIncr = 3;
                    }
                    else
                    {
                        colorIncr = 4;
                    }
                } while (increment ? gene.color + colorIncr > Configuration.ColorsCount : gene.color - colorIncr < 1);

                if (increment)
                {
                    gene.color += colorIncr;
                }
                {
                    gene.color -= colorIncr;
                }
            }
        }
        public double GetRandomNormalDistribution(int max)
        {
            var _random = new Random();

            var n = Math.Min((1 / _random.NextDouble() - 1) * 0.1, 1);
            //n = Math.Pow(n, 0.7);

            return n * max;
        }

        public void MutateNormalDistribution(Genotype specimen)
        {
            foreach (var gene in specimen.Genes)
            {
                if (!(_random.NextDouble() < Configuration.MutationRate) ||
                    gene == null) continue;

                var colorsToMax = Configuration.ColorsCount - gene.color;

                if (_random.Next(0, 2) > 0)
                {
                    gene.color += (int)(GetRandomNormalDistribution(colorsToMax) + 1);
                }
                {
                    gene.color -= (int)(GetRandomNormalDistribution(gene.color) + 1);
                }
            }
        }

        public void MutateRandom(Genotype specimen)
        {
            foreach (var gene in specimen.Genes)
            {
                if (!(_random.NextDouble() < Configuration.MutationRate) ||
                    gene == null) continue;

                gene.color = _random.Next(0, Configuration.ColorsCount);
            }
        }

        public Genotype StartTournament()
        {

            Genotype bestSpecimen = null;
            var bestSpecimenFitness = double.NegativeInfinity;


            Genotype specimen = null;
            for (int i = 0; i < Configuration.SpecimensInTournament; i++)
            {
                while (specimen == null || specimen == bestSpecimen)
                {
                    specimen = Population[_random.Next(0, Population.Count)];
                }
                if (bestSpecimen == null || GetFitness(specimen) > bestSpecimenFitness)
                {
                    bestSpecimen = specimen;
                    bestSpecimenFitness = GetFitness(bestSpecimen);
                }

                specimen = null;
            }

            return bestSpecimen;
        }

        public Genotype GetBestSpecimen(IList<Genotype> population)
        {
            Genotype bestSpecimen = null;
            foreach (var specimen in population)
            {
                if (GetFitness(specimen) > GetFitness(bestSpecimen))
                {
                    bestSpecimen = specimen;
                }
            }

            return bestSpecimen;
        }

        public Genotype CloneSpecimen(Genotype specimen)
        {
            var clone = new Genotype(LoadedGraph.Edges, LoadedGraph.VerticesIds, specimen.MaxID);

            foreach (var gene in specimen.Genes)
            {
                if (gene == null) continue;
                clone.Genes[gene.id].color = gene.color;
            }

            return clone;
        }
    }
}
