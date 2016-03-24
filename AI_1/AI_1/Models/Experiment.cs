using AI_1.Enums;
using AI_1.Logic;
using AI_1.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Experiment
    {
        private string FilePath { get; set; }

        public int Repetitions { get; set; }

        #region CONFIGURATION
        public CrossoverMethods CrossoverMethod { get; set; } = CrossoverMethods.POP;
        public MutationMethods MutationMethod { get; set; } = MutationMethods.RAND_INC;

        public double MutationRate { get; set; } = Configuration.MUTATION_RATE;
        public double ImmigrationRate { get; set; } = Configuration.IMMIGRATION_RATE;
        public double CrossoverRate { get; set; } = Configuration.CROSSOVER_RATE;
        public double FitnessAlpha { get; set; } = Configuration.MAX_COLOR_WEIGHT;

        public int ColorsCount { get; set; } = Configuration.COLORS_COUNT;
        public int PopulationCount { get; set; } = Configuration.POPULATION_COUNT;
        public int GenerationsCount { get; set; } = Configuration.GENERATIONS_COUNT;
        public int SpecimensInTournament { get; set; } = Configuration.SPECIMENS_IN_TOURNAMENT;
        #endregion

        public Experiment(string filePath)
        {
            FilePath = filePath;
        }

        public Genotype Run()
        {
            Configuration.SetDefaults();
            SetConfiguration();

            var parse = new COLReader();

            var graph = parse.ParseFile(FilePath);

            var executor = new GAExecutor(graph);
            var fileName = Regex.Match(FilePath, @"/[A-Za-z0-9.]+$").Value;
            fileName = fileName.Substring(1, fileName.IndexOf('.') - 1);
            

            var solution = executor.RunHeuristic(
                Configuration.PopulationCount, 
                Configuration.GenerationsCount,
                Configuration.GetExperimentLogFilePath(fileName));

            return solution;
        }

        private void SetConfiguration()
        {
            Configuration.MutationMethod = MutationMethod;
            Configuration.CrossoverMethod = CrossoverMethod;

            Configuration.MutationRate = MutationRate;
            Configuration.ImmigrationRate = ImmigrationRate;
            Configuration.MaxColorWeight = FitnessAlpha;
            Configuration.CrossoverRate = CrossoverRate;

            Configuration.ColorsCount = ColorsCount;
            Configuration.PopulationCount = PopulationCount;
            Configuration.GenerationsCount = GenerationsCount;
            Configuration.SpecimensInTournament = SpecimensInTournament;

            Configuration.SourceFilePath = FilePath;
        }
    }
}
