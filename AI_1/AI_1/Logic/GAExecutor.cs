using AI_1.Enums;
using AI_1.Helpers;
using AI_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AI_1.Extensions;

namespace AI_1.Logic
{
    public partial class GAExecutor
    {
        public IList<Genotype> Population { get; set; }

        public IList<Genotype> NextPopulation { get; set; }

        public Graph LoadedGraph { get; set; }

        private StreamWriter _writer;

        public GAExecutor(Graph graph)
        {
            Population = new List<Genotype>(Configuration.PopulationCount);
            NextPopulation = new List<Genotype>(Configuration.PopulationCount);

            LoadedGraph = graph;
        }

        public Genotype RunHeuristic(int populationCount, int generationsCount, string logFilePath = null, bool openLogFile = false)
        {
            Genotype bestSolution = null;

            logFilePath = logFilePath ?? Configuration.GetLogFilePath;

            var lastSlash = logFilePath.LastIndexOf('/');

            Directory.CreateDirectory(logFilePath.Substring(0, lastSlash));

            using (_writer = new StreamWriter(logFilePath, true))
            {
                if (openLogFile) Process.Start(logFilePath);

                Population.Clear();
                NextPopulation.Clear();

                for (int i = 0; i < populationCount; i++)
                {
                    var specimen = Randomizer.GetRandomGenotype(LoadedGraph);

                    Population.Add(specimen);

                    if (specimen.IsValid() && GetFitness(specimen) > GetFitness(bestSolution))
                    {
                        bestSolution = specimen;
                    }
                }

                DumpMessage(Configuration.DumpCurrentSettings());
                DumpGenerationHeader();
                var flushCounter = 0;

                var generationIndex = 0;

                for (generationIndex = 0; generationIndex < generationsCount; generationIndex++)
                {
                    Parallel.For(0, populationCount/2, j =>
                    {
                        Genotype child1, child2, parent1, parent2;

                        parent1 = StartTournament();
                        parent2 = null;
                        while (parent2 == null || parent1 == parent2)
                        {
                            parent2 = StartTournament();
                        }

                        child1 = null;
                        child2 = null;


                        #region crossover

                        if (_random.NextDouble() < Configuration.CrossoverRate)
                        {
                            Tuple<Genotype, Genotype> children;
                            switch (Configuration.CrossoverMethod)
                            {
                                case CrossoverMethods.POP:
                                    children = CrossoverPOP(parent1, parent2);
                                    child1 = children.Item1;
                                    child2 = children.Item2;
                                    break;
                                case CrossoverMethods.MOX:
                                    children = CrossoverMOX(parent1, parent2);
                                    child1 = children.Item1;
                                    child2 = children.Item2;
                                    break;
                            }
                        }
                        else
                        {
                            child1 = CloneSpecimen(parent1);
                            child2 = CloneSpecimen(parent2);
                        }

                        #endregion


                        #region mutation

                        switch (Configuration.MutationMethod)
                        {
                            case MutationMethods.RAND_INC:
                                MutateRandomIncrement(child1);
                                MutateRandomIncrement(child2);
                                break;
                            case MutationMethods.NORMAL:
                                MutateNormalDistribution(child1);
                                MutateNormalDistribution(child2);
                                break;
                            case MutationMethods.RANDOM:
                                MutateRandom(child1);
                                MutateRandom(child2);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        #endregion


                        #region immigration

                        if (child1.IsWild = _random.NextDouble() < Configuration.ImmigrationRate)
                        {
                            Randomizer.InitialRoll(child1);
                        }
                        if (child2.IsWild = _random.NextDouble() < Configuration.ImmigrationRate)
                        {
                            Randomizer.InitialRoll(child2);
                        }

                        #endregion


                        #region check same speciman is already in population

                        int mutationsLeft = 5;
                        while (NextPopulation.ContainsSpecimen(child1) && mutationsLeft > 0)
                        {
                            switch (Configuration.MutationMethod)
                            {
                                case MutationMethods.RAND_INC:
                                    MutateRandomIncrement(child1);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            mutationsLeft--;
                        }
                        if (mutationsLeft < 5 && NextPopulation.ContainsSpecimen(child1))
                        {
                            Randomizer.InitialRoll(child1);
                        }
                        NextPopulation.AddParallel(child1);

                        mutationsLeft = 5;

                        while (NextPopulation.ContainsSpecimen(child2) && mutationsLeft > 0)
                        {
                            switch (Configuration.MutationMethod)
                            {
                                case MutationMethods.RAND_INC:
                                    MutateRandomIncrement(child2);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            mutationsLeft--;
                        }
                        if (mutationsLeft < 5 && NextPopulation.ContainsSpecimen(child2))
                        {
                            Randomizer.InitialRoll(child2);
                        }
                        NextPopulation.AddParallel(child2);

                        #endregion
                    });

                    flushCounter++;
                    if (flushCounter == 10)
                    {
                        flushCounter = 0;
                        _writer.Flush();
                    }


                    foreach (var specimen in Population)
                    {
                        if (specimen.IsValid() &&
                            specimen.GetMaxColor() < (bestSolution?.GetMaxColor() ?? int.MaxValue))
                        {
                            bestSolution = specimen;
                        }
                    }

                    DumpGenerationStatistics(Population, generationIndex, bestSolution);

                    var temp = Population;
                    Population = NextPopulation;
                    NextPopulation = temp;
                    NextPopulation.Clear();
                }

                DumpGenerationStatistics(Population, generationIndex, bestSolution);

                StaticWriter.Log((bestSolution?.GetMaxColor() ?? -1) + ";" + Configuration.DumpCurrentHeuristicSettings());

                _writer.Flush();
            }

            return bestSolution;
        }

        private void DumpGenerationHeader()
        {
            var header = "generation;best;worst;average;best_solution";
            _writer.WriteLine(header);
        }

        private double DumpGenerationStatistics(
            IList<Genotype> population,
            int generation,
            Genotype bestSolution)
        {
            Genotype bestSpecimen = null;
            Genotype worstSpecimen = null;
            double avgSpecimenFitness = 0;
            var domesticPopulation = 0;

            //IList<Genotype> wildSpecimens = new List<Genotype>((int)(Configuration.PopulationCount * Configuration.ImmigrationRate * 2));

            var worstSpecimenFitness = double.PositiveInfinity;

            foreach (var specimen in population)
            {
                //skip wild specimens
                if (specimen.IsWild) continue;

                domesticPopulation++;

                var specimenFitness = GetFitness(specimen);
                var bestSpecimenFitness = GetFitness(bestSpecimen);

                if (specimenFitness > bestSpecimenFitness)
                {
                    bestSpecimen = specimen;
                }
                if (specimenFitness < worstSpecimenFitness)
                {
                    worstSpecimen = specimen;
                    worstSpecimenFitness = GetFitness(worstSpecimen);
                }

                avgSpecimenFitness += specimenFitness;
            }

            avgSpecimenFitness /= domesticPopulation;

            _writer.WriteLine("{0};{1};{2};{3};{4}", generation, GetFitness(bestSpecimen), GetFitness(worstSpecimen), avgSpecimenFitness, bestSolution?.GetMaxColor() ?? -1);

            return avgSpecimenFitness;
        }

        private void DumpMessage(string msg)
        {
            _writer.WriteLine(msg);
        }
    }
}
