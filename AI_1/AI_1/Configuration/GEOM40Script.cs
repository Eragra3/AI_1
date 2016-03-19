using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Models;

namespace AI_1
{
    public class GEOM40Script : IScript
    {
        public IList<Experiment> Experiments { get; set; }

        public string SourceFile { get; set; } = Configuration.GEOM40;

        //MIN 28
        public GEOM40Script()
        {
            var colorsCount = 33;
            var repetitions = 10;

            Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.005
                },
                //new Experiment(SourceFile)
                //{
                //    ColorsCount = colorsCount,
                //    Repetitions = repetitions,
                //    MutationRate = 0.0075
                //},
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.01
                },
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.015
                },
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.02
                },
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.025
                },
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.03
                },
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.035
                },
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.04
                },
                new Experiment(SourceFile)
                {
                    ColorsCount = colorsCount,
                    Repetitions = repetitions,
                    MutationRate = 0.045
                }
            };
        }
    }
}
