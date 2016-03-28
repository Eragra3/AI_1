using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class GenotypeStatistics
    {
        public Genotype Genotype;

        public int FirstGenerationWithSolution;

        public static implicit operator Genotype(GenotypeStatistics specimenStatistics)
        {
            return specimenStatistics.Genotype;
        }
    }

}
