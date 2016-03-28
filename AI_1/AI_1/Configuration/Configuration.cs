using AI_1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Helpers;

namespace AI_1
{
    public static class Configuration
    {

        #region test variables

        #endregion


        static Configuration()
        {
            SetDefaults();
        }

        public static readonly string RESOURCES_PATH = "C:/School/AI_Resources/";

        public static string GetLogFilePath => "C:/School/AI_Resources/Logs/GA_statistics_"
                                              + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";


        public static string GetExperimentLogFilePath(string fileName)
        {
            var directory = "C:/School/AI_Resources/Logs/";
            var subDir = StaticWriter.Description.Substring(0, StaticWriter.Description.IndexOf('.'));
            //return directory + fileName + "/" +  description + "/" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";
            return directory + subDir + "/" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";
        }


        public static readonly string GEOM20 = RESOURCES_PATH + "GEOM20.col";
        public static readonly string GEOM30 = RESOURCES_PATH + "GEOM30.col";
        public static readonly string GEOM40 = RESOURCES_PATH + "GEOM40.col";
        public static readonly string GEOM70 = RESOURCES_PATH + "GEOM70.col";
        public static readonly string GEOM100a = RESOURCES_PATH + "GEOM100a.col";
        public static readonly string GEOM120 = RESOURCES_PATH + "GEOM120.col";


        public static CrossoverMethods CrossoverMethod { get; set; }
        public static MutationMethods MutationMethod { get; set; }

        public static double MutationRate { get; set; }
        public static double CrossoverRate { get; set; }
        public static double ImmigrationRate { get; set; }
        public static double MaxColorWeight { get; set; }
        public static int ColorsCount { get; set; }
        //keep this value even, crossovers produce two childs
        public static int PopulationCount { get; set; }
        public static int GenerationsCount { get; set; }
        public static int SpecimensInTournament { get; set; }

        public static string SourceFilePath { get; set; }

        public static readonly double MUTATION_RATE = 0.02;
        public static readonly double IMMIGRATION_RATE = 0;
        public static readonly double CROSSOVER_RATE = 0.95;
        public static readonly double MAX_COLOR_WEIGHT = 0.01;
        public static readonly int COLORS_COUNT = 45;

        public static readonly int POPULATION_COUNT = 300;
        public static readonly int GENERATIONS_COUNT = 1000;
        public static readonly int SPECIMENS_IN_TOURNAMENT = 10;

        public static void SetDefaults()
        {
            CrossoverMethod = CrossoverMethods.POP;
            MutationMethod = MutationMethods.RAND_INC;

            MutationRate = MUTATION_RATE;
            ImmigrationRate = IMMIGRATION_RATE;
            CrossoverRate = CROSSOVER_RATE;
            MaxColorWeight = MAX_COLOR_WEIGHT;
            ColorsCount = COLORS_COUNT;
            PopulationCount = POPULATION_COUNT;
            GenerationsCount = GENERATIONS_COUNT;
            SpecimensInTournament = SPECIMENS_IN_TOURNAMENT;
        }

        public static string DumpCurrentSettings()
        {
            var sb = new StringBuilder();

            sb.Append("mutation_rate;crossover_rate;immigration_rate;fitness_alpha;" +
                      "max_color;populaton;generations;specimens_in_tournament;" +
                      "crossover_method;mutation_method;file_name;log_name");

            sb.AppendLine();

            sb.Append(
                $"{MutationRate};{CrossoverRate};{ImmigrationRate};{MaxColorWeight};{ColorsCount};{PopulationCount};{GenerationsCount};{SpecimensInTournament};{CrossoverMethod.ToString()};{MutationMethod.ToString()};{SourceFilePath};{GetLogFilePath}");

            return sb.ToString();
        }

        public static string DumpCurrentHeuristicSettings()
        {
            var sb = new StringBuilder();

            sb.Append(
                $"{MutationRate};{CrossoverRate};{ImmigrationRate};{MaxColorWeight};{ColorsCount};{PopulationCount};{GenerationsCount};{SpecimensInTournament};{CrossoverMethod.ToString()};{MutationMethod.ToString()}");

            return sb.ToString();
        }
        public static string DumpHeuristicSettingsHeader()
        {
            var sb = new StringBuilder();

            sb.Append("best_solution;first_gen_with_solution;mutation_rate;crossover_rate;immigration_rate;fitness_alpha;" +
                      "max_color;populaton;generations;specimens_in_tournament;" +
                      "crossover_method;mutation_method;log_file_path");

            return sb.ToString();
        }
    }
}
