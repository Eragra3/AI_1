using AI_1.Enums;
using AI_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Logic
{
    public partial class GAExecutor
    {
        public IList<Genotype> Population { get; set; }

        public IList<Genotype> NextPopulation { get; set; }

        public Graph LoadedGraph { get; set; }

        private StreamWriter writer;

        public GAExecutor(Graph graph)
        {
            Population = new List<Genotype>(300);
            NextPopulation = new List<Genotype>(300);

            LoadedGraph = graph;
        }

        public Genotype RunHeuristic(int populationCount, int generationsCount, string logFilePath = null)
        {
            var randomizer = new Randomizer();

            Genotype bestSolution = null;

            logFilePath  = logFilePath ?? Configuration.GetLogFilePath;


            using (writer = new StreamWriter(logFilePath, true))
            {
                //Process.Start(logFilePath);

                Population.Clear();
                NextPopulation.Clear();

                for (int i = 0; i < populationCount; i++)
                {
                    var specimen = randomizer.GetRandomGenotype(LoadedGraph);

                    Population.Add(specimen);

                    if (specimen.IsValid() && GetFitness(specimen) > GetFitness(bestSolution))
                    {
                        bestSolution = specimen;
                    }

                    Console.WriteLine("randomized: {0}", i);
                }

                DumpMessage(Configuration.DumpCurrentSettings());
                DumpGenerationHeader();
                var flushCounter = 0;

                var staleGenerations = 0;
                var avgFitness = double.NegativeInfinity;
                var weStillBelieve = 0;
                Genotype newBestSolution = null;
                //weStillBelieve < 100
                for (var i = 0; i < generationsCount && (bestSolution == null || weStillBelieve < -1); i++)
                {
                    Console.WriteLine("Run: {0}", i);

                    for (int j = 0; j < populationCount / 2; j++)
                    {
                        var parent1 = StartTournament();
                        var parent2 = StartTournament();

                        Genotype child1 = null;
                        Genotype child2 = null;

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

                        switch (Configuration.MutationMethod)
                        {
                            case MutationMethods.RAND_INC:
                                MutateRandomIncrement(child2);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        if (child1.IsWild = _random.NextDouble() < Configuration.ImmigrationRate)
                        {
                            randomizer.InitialRoll(child1);
                        }
                        if (child2.IsWild = _random.NextDouble() < Configuration.ImmigrationRate)
                        {
                            randomizer.InitialRoll(child2);
                        }

                        NextPopulation.Add(child1);
                        NextPopulation.Add(child2);

                        if (child2.IsValid() && child2.GetMaxColor() < (newBestSolution?.GetMaxColor() ?? int.MaxValue))
                        {
                            newBestSolution = child2;
                        }

                        if (child1.IsValid() && child1.GetMaxColor() < (newBestSolution?.GetMaxColor() ?? int.MaxValue))
                        {
                            newBestSolution = child1;
                        }
                    }

                    var avgChildrenFitness = DumpGenerationStatistics(Population, i, newBestSolution);

                    flushCounter++;
                    if (flushCounter == 10)
                    {
                        flushCounter = 0;
                        writer.Flush();
                    }

                    var temp = Population;
                    Population = NextPopulation;
                    NextPopulation = temp;
                    NextPopulation.Clear();

                    if (avgFitness.Equals(avgChildrenFitness))
                    {
                        staleGenerations++;
                    }
                    else
                    {
                        avgFitness = avgChildrenFitness;
                        staleGenerations = 0;
                    }
                    if (staleGenerations == Configuration.MAX_STALE_GENERATIONS)
                    {
                        Console.WriteLine("Stopped because of stale generations");
                        //stop algorithm
                        goto end_loop;
                    }

                    //if we have solution wait 100 generations
                    //if nothing happens, stop
                    if (bestSolution != null)
                    {
                        if (bestSolution == newBestSolution)
                        {
                            weStillBelieve++;
                        }
                        else
                        {
                            weStillBelieve = 0;
                        }
                    }
                    bestSolution = newBestSolution;

                    //var currentBestSpecimenFitness = GetFitness(GetBestSpecimen(Population));
                    //if (Math.Abs(currentBestSpecimenFitness - bestFitness) < Configuration.MaxColorWeight * 2)
                    //{
                    //    staleGenerations++;
                    //}
                    //#region kickstart, sudden death
                    //if (staleGenerations == 99)
                    //{
                    //    staleGenerations = 0;
                    //    for (int n = 0; n < Population.Count; n += 2)
                    //    {
                    //        var newSpecimen = new Genotype(
                    //            LoadedGraph.Edges,
                    //            LoadedGraph.VerticesIds,
                    //            Population[n].MaxID);
                    //        randomizer.InitialRoll(newSpecimen);
                    //        Population[n] = newSpecimen;
                    //    }
                    //}
                    //#endregion
                }

            end_loop:

                DumpGenerationStatistics(Population, generationsCount, bestSolution);
            }

            return bestSolution;
        }

        private void DumpGenerationHeader()
        {
            var header = "generation;best;worst;average;best_solution";
            writer.WriteLine(header);
        }

        private double DumpGenerationStatistics(IList<Genotype> population,
            int generation, Genotype bestSolution)
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

            writer.WriteLine("{0};{1};{2};{3};{4}", generation, GetFitness(bestSpecimen), GetFitness(worstSpecimen), avgSpecimenFitness, bestSolution?.GetMaxColor() ?? -1);

            return avgSpecimenFitness;
        }

        private void DumpMessage(string msg)
        {
            writer.WriteLine(msg);
        }
    }
}
