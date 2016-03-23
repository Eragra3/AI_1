using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Models;

namespace AI_1
{
    public class GEOM20Script : IScript
    {
        public IList<Experiment> Experiments { get; set; }

        public string SourceFile { get; set; } = Configuration.GEOM20;

        //MIN 28
        public GEOM20Script(ScriptType type)
        {
            var colorsCount = 21;
            var repetitions = 10;
            var population = 300;

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
                    MutationRate = 0.005
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
                    MutationRate = 0.015
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
                    MutationRate = 0.025
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
                    MutationRate = 0.035
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
                    MutationRate = 0.045
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
                    MutationRate = 0.075
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.1
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
                //new Experiment(SourceFile)
                //{
                //    ColorsCount = colorsCount,
                //    Repetitions = repetitions,
                //    MutationRate = 0.0075
                //},
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
                //new Experiment(SourceFile)
                //{
                //    ColorsCount = colorsCount,
                //    Repetitions = repetitions,
                //    MutationRate = 0.0075
                //},
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    SpecimensInTournament = 3
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
                    SpecimensInTournament = 5
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
                    SpecimensInTournament = 7
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
                    SpecimensInTournament = 9
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
                    SpecimensInTournament = 15
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
                    FitnessAlpha = 0
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
                    FitnessAlpha = 0.1
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
                    FitnessAlpha = 0.2
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
                    FitnessAlpha = 0.3
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
                    FitnessAlpha = 0.35
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
                    FitnessAlpha = 0.45
                },
                new Experiment(SourceFile)
                {
                    PopulationCount = population,
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    FitnessAlpha = 0.5
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
                }
            };
                    #endregion
                    break;
                case ScriptType.ColorsCount:
                    #region colorsCount

                    Experiments = new List<Experiment>
                    {
                        //new Experiment(SourceFile)
                        //{
                        //    PopulationCount = population,
                        //    ColorsCount = 30,
                        //    Repetitions = repetitions
                        //},
                        new Experiment(SourceFile)
                        {
                            PopulationCount = population,
                            ColorsCount = 25,
                            Repetitions = repetitions
                        }
                    };
                    #endregion
                    break;
                default:
                    break;
            }
        }
    }
}
