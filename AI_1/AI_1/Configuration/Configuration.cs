using AI_1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1
{
    public static class Configuration
    {
        public static readonly string RESOURCES_PATH = "C:/School/AI_Resources/";
        public static string LogFilePath => "C:/School/AI_Resources/Logs/GA_statistics_"
                                              + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";

        public static readonly string GEOM20 = RESOURCES_PATH + "GEOM20.col";
        public static readonly string GEOM70 = RESOURCES_PATH + "GEOM70.col";
        public static readonly string GEOM100a = RESOURCES_PATH + "GEOM100a.col";
        public static readonly string GEOM120 = RESOURCES_PATH + "GEOM120.col";


        public static CrossoverMethods CrossoverMethod { get; set; } = CrossoverMethods.POP;
        public static MutationMethods MutationMethod { get; set; } = MutationMethods.RAND_INC;

        public static double MutationRate { get; set; } = 0.04;
        public static double ImmigrationRate { get; set; } = 0.01;
        public static double FitnessAlpha { get; set; } = 0.4;
        public static int ColorsCount { get; set; } = 100;
        //keep this value even, crossovers produce two childs
        public static int PopulationCount { get; set; } = 1000;
        public static int GenerationsCount { get; set; } = 2000;
        public static int SpecimensInTournament { get; set; } = 2;

        public static string SourceFilePath { get; set; }

        public static readonly double MUTATION_RATE = 0.03;
        public static readonly double IMMIGRATION_RATE = 0.01;
        public static readonly double FITNESS_ALPHA = 0.01;
        public static readonly int COLORS_COUNT = 100;

        public static readonly int POPULATION_COUNT = 1000;
        public static readonly int GENERATIONS_COUNT = 2000;
        public static readonly int SPECIMENS_IN_TOURNAMENT = 2;

        public static void SetDefaults()
        {
            CrossoverMethod = CrossoverMethods.POP;
            MutationMethod = MutationMethods.RAND_INC;

            MutationRate = MUTATION_RATE;
            ImmigrationRate = IMMIGRATION_RATE;
            FitnessAlpha = FITNESS_ALPHA;
            ColorsCount = COLORS_COUNT;
            PopulationCount = POPULATION_COUNT;
            GenerationsCount = GENERATIONS_COUNT;
            SpecimensInTournament = SPECIMENS_IN_TOURNAMENT;
        }

        public static string DumpCurrentSettings()
        {
            var sb = new StringBuilder();

            sb.Append("mutation_rate;immigration_rate;fitness_alpha;" +
                      "max_color;populaton;generations;specimens_in_tournament;" +
                      "crossover_method;mutation_method;file_name;log_name");

            sb.AppendLine();

            sb.Append(
                $"{MutationRate};{ImmigrationRate};{FitnessAlpha};{ColorsCount};{PopulationCount};{GenerationsCount};{SpecimensInTournament};{CrossoverMethod.ToString()};{MutationMethod.ToString()};{SourceFilePath};{LogFilePath}");

            return sb.ToString();
        }
    }
}
