using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Models;

namespace AI_1
{
    public class GEOM120Script : IScript
    {
        public IList<Experiment> Experiments { get; set; }

        public string SourceFile { get; set; } = Configuration.GEOM120;

        //DEFAULT COLOR COUNT 130
        public GEOM120Script(ScriptType type)
        {
            var colorsCount = 130;
            var repetitions = 10;
            var population = 150;

            switch (type)
            {
                case ScriptType.MutationRate:
                    #region mutation
                    Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.001
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.002
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.003
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.004
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.005
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.006
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.007
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.008
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.009
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.01
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.011
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.012
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.013
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.014
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.015
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.016
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.017
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.018
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.019
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.02
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.021
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.022
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.023
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.024
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.025
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.026
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.027
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.028
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.029
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.03
                }
            };
                    #endregion
                    break;
                case ScriptType.CrossoverRate:
                    #region crossover
                    Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    CrossoverRate = 0.85
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    CrossoverRate = 0.875
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    CrossoverRate = 0.9
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    CrossoverRate = 0.925
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    CrossoverRate = 0.95
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    CrossoverRate = 0.975
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    CrossoverRate = 1
                }
            };
                    #endregion
                    break;
                case ScriptType.TournamentSize:
                    #region tournament
                    Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 2
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 4
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 6
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 8
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 10
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 12
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 14
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 16
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 18
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 20
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 22
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 24
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 26
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 28
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 30
                }
            };
                    #endregion
                    break;
                case ScriptType.Alpha:
                    #region alpha
                    Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.01
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.02
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.03
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.04
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.05
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.06
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.07
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.08
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.09
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.1
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.11
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.12
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.13
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.14
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.15
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.16
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.17
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.18
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.19
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.2
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.21
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.22
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.23
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.24
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.25
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.26
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.27
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.28
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.29
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.3
                }
            };
                    #endregion
                    break;
                case ScriptType.AlphaWide:
                    #region alpha
                    Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.1
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.2
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.3
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.4
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.5
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.6
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.7
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.8
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.9
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 1
                }
            };
                    #endregion
                    break;
                case ScriptType.ImmigrationRate:
                    #region immigration
                    Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.0
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.005
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.01
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.015
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.02
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.025
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.03
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.035
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.04
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.045
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    ImmigrationRate = 0.05
                }
            };
                    #endregion
                    break;
                case ScriptType.ColorsCount:
                    #region colorsCount

                    Experiments = new List<Experiment>
                    {
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 160,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 150,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 140,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 130,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 120,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 110,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 100,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 90,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 80,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 70,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 60,
                            Repetitions = repetitions
                        }
                    };
                    #endregion
                    break;
                case ScriptType.PopulationSize:
                    #region ColorsCount
                    Experiments = new List<Experiment>
                    {
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 50,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 100,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 150,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 200,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 250,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 300,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 350,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 400,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 450,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = 500,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions
                        }
                    };
                    #endregion
                    break;
                case ScriptType.MutationRateWide:
                    #region mutation
                    Experiments = new List<Experiment>
                    {
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.01
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.02
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.03
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.04
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.05
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.06
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.07
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.08
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.09
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.1
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.11
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.12
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.13
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.14
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.15
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.16
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.17
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.18
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.19
                        },
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = colorsCount,
                            Repetitions = repetitions,
                            MutationRate = 0.2
                        }
                    };
                    #endregion;
                    break;
                default:
                    break;
            }
        }
    }
}
