using AI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1
{
    public class BasicScript : IScript
    {
        public IList<Experiment> Experiments { get; set; }

        public string SourceFile { get; set; } = "various_files";

        public BasicScript()
        {
            Experiments = new List<Experiment>
            {
                new Experiment(Configuration.GEOM20)
                {
                    ColorsCount = 50
                },
                new Experiment(Configuration.GEOM20)
                {
                    ColorsCount = 30
                },
                new Experiment(Configuration.GEOM20)
                {
                    ColorsCount = 25
                },
                new Experiment(Configuration.GEOM20)
                {
                    ColorsCount = 21
                },
                new Experiment(Configuration.GEOM20)
                {
                    ColorsCount = 20
                },
                new Experiment(Configuration.GEOM20)
                {
                    ColorsCount = 29
                },
                new Experiment(Configuration.GEOM70)
                {
                  ColorsCount  =  100
                },
                new Experiment(Configuration.GEOM70)
                {
                  ColorsCount  =  80
                },
                new Experiment(Configuration.GEOM70)
                {
                  ColorsCount  =  70
                },
                new Experiment(Configuration.GEOM70)
                {
                  ColorsCount  =  60
                },
                new Experiment(Configuration.GEOM100a)
                {
                    ColorsCount = 150
                },
                new Experiment(Configuration.GEOM100a)
                {
                    ColorsCount = 120
                },
                new Experiment(Configuration.GEOM100a)
                {
                    ColorsCount = 115
                },
                new Experiment(Configuration.GEOM100a)
                {
                    ColorsCount = 110
                }
            };
        }
    }
}
