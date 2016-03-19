using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Models;

namespace AI_1
{
    public class GEOM70Script : IScript
    {
        public IList<Experiment> Experiments { get; set; }

        public string SourceFile { get; set; } = Configuration.GEOM70;

        public GEOM70Script()
        {
            Experiments = new List<Experiment>
            {
                new Experiment(SourceFile)
                {
                    ColorsCount = 45
                },
            };
        }
    }
}
