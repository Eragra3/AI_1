using AI_1.Extensions;
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
    public partial class GAExecutor
    {
        private static readonly Random _random = new Random();

        public static string GetDumpHeader()
        {
            return "generation,colors,k,valid,fitness,invalidEdges";
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetFitness(Genotype specimen)
        {
            if (specimen == null) return double.NegativeInfinity;

            #region non-zero fitness
            var maxColor = 0;

            if (Configuration.MaxColorWeight != 0)
            {
                maxColor = specimen.GetMaxColor();
            }

            var penalty = GetPenalty(specimen);

            return Configuration.MaxColorWeight * -maxColor - (1 - Configuration.MaxColorWeight) * penalty;
            #endregion

            #region only penalty
            //var penalty = GetPenalty(specimen);
            //return GetPenalty(specimen);
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetPenalty(Genotype specimen)
        {
            double penalty = 0;
            int color1;
            int color2;
            foreach (var edge in specimen.Edges)
            {
                color1 = specimen.Genes[edge.Vertex1ID].color;
                color2 = specimen.Genes[edge.Vertex2ID].color;

                if (!edge.IsValidWithColors(color1, color2))
                {
                    penalty += edge.Weight;
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

                var colorIncr = _random.Next(0, 100);

                if (colorIncr < 45)
                {
                    colorIncr = 1;
                }
                else if (colorIncr < 67)
                {
                    colorIncr = 2;
                }
                else if (colorIncr < 90)
                {
                    colorIncr = 3;
                }
                else
                {
                    colorIncr = 4;
                }

                if (_random.Next(0, 2) > 0)
                {
                    gene.color += colorIncr;
                    gene.color = Math.Min(gene.color, Configuration.ColorsCount);
                }
                {
                    gene.color -= colorIncr;
                    gene.color = Math.Max(gene.color, 0);
                }
            }
        }

        public Genotype StartTournament()
        {

            Genotype bestSpecimen = null;

            Genotype specimen = null;
            for (int i = 0; i < Configuration.SpecimensInTournament; i++)
            {
                while (specimen == null || specimen == bestSpecimen)
                {
                    specimen = Population[_random.Next(0, Population.Count)];
                }
                if (bestSpecimen == null || GetFitness(specimen) > GetFitness(bestSpecimen))
                {
                    bestSpecimen = specimen;
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
    }
}
