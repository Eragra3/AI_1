using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Models;

namespace AI_1
{
    public interface IScript
    {
        IList<Experiment> Experiments { get; set; }

        string SourceFile { get; set; }
    }
    public enum ScriptType
    {
        MutationRate,
        CrossoverRate,
        TournamentSize,
        Alpha,
        ImmigrationRate
    }
}
