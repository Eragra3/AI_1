using AI_1.Enums;
using AI_1.Helpers;
using AI_1.Logic;
using AI_1.Models;
using AI_1.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_1
{
    public partial class Form1 : Form
    {
        private GAExecutor _executor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            crossoverMethodCB.DataSource = Enum.GetValues(typeof(CrossoverMethods));
            mutationMethodCB.DataSource = Enum.GetValues(typeof(MutationMethods));
        }

        private void startAlgorithmButton_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.BackColor = Color.Yellow;
            var task = Task.Run(() =>
            {
                var parse = new COLReader();


                var usedFile = Configuration.GEOM40;
                var graph = parse.ParseFile(usedFile);
                Configuration.SourceFilePath = usedFile;

                _executor = new GAExecutor(graph);

                var solution = _executor.RunHeuristic(Configuration.PopulationCount, Configuration.GenerationsCount, openLogFile: true);

                Console.WriteLine(solution?.Dump() ?? string.Empty);
                Console.WriteLine(solution?.Print() ?? string.Empty);
            });
            task.ContinueWith((t) =>
            {
                splitContainer1.Panel2.BackColor = Color.White;
            });
        }

        private void crossoverMethodCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CrossoverMethods newMethod;

            if (Enum.TryParse(crossoverMethodCB.SelectedValue.ToString(), out newMethod))
            {
                Configuration.CrossoverMethod = newMethod;
            }
        }

        private void mutationMethodCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MutationMethods newMethod;

            if (Enum.TryParse(mutationMethodCB.SelectedValue.ToString(), out newMethod))
            {
                Configuration.MutationMethod = newMethod;
            }
        }

        private void StartBasicScriptButton_Click(object sender, EventArgs e)
        {
            var script = new BasicScript();

            RunScript(script);
        }

        private void StartGEOM70ScriptButton_Click(object sender, EventArgs e)
        {
            var script = new GEOM70Script();

            RunScript(script);
        }

        private void RunScript(IScript script)
        {

            using (var writer = new StreamWriter(
                Configuration.RESOURCES_PATH + "Solutions/solutions_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm") + ".txt", true)
                )
            {
                var solutions = new List<Genotype>(script.Experiments.Count);

                var experimentNumber = 1;
                foreach (var experiment in script.Experiments)
                {
                    for (int i = 0; i < experiment.Repetitions; i++)
                    {
                        var sw = new Stopwatch();

                        sw.Start();

                        var solution = experiment.Run();

                        var duration = sw.ElapsedMilliseconds;

                        writer.WriteLine("EXPERIMENT {0} REPETITION {1}", experimentNumber++, i);
                        writer.WriteLine("duration: {0}ms", duration);
                        writer.WriteLine(solution?.Dump() ?? string.Empty);
                        //writer.WriteLine(solution?.Print() ?? string.Empty);
                        writer.WriteLine("@".PadLeft(40, '@'));
                        writer.WriteLine("@".PadLeft(40, '@'));
                        writer.WriteLine("@".PadLeft(40, '@'));
                        writer.Flush();

                        solutions.Add(solution);
                    }
                }
            }

            Console.WriteLine("Finished script");
        }

        private void startGEOM40_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.BackColor = Color.Yellow;
            var task = Task.Run(() =>
            {
                IScript script;

                //StaticWriter.Description = "Mutation.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.MutationRate);
                //RunScript(script);

                //StaticWriter.Description = "Mutation_Wide.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.MutationRateWide);
                //RunScript(script);

                //StaticWriter.Description = "Crossover.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.CrossoverRate);
                //RunScript(script);

                //StaticWriter.Description = "Alpha.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.Alpha);
                //RunScript(script);

                //StaticWriter.Description = "Alpha_Wide.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.AlphaWide);
                //RunScript(script);

                //StaticWriter.Description = "Immigration.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.ImmigrationRate);
                //RunScript(script);

                StaticWriter.Description = "Tournament.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM40Script(ScriptType.TournamentSize);
                RunScript(script);

                //StaticWriter.Description = "ColorsCount.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.ColorsCount);
                //RunScript(script);

                //StaticWriter.Description = "Population.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM40Script(ScriptType.PopulationSize);
                RunScript(script);
            });
            task.ContinueWith((t) =>
            {
                splitContainer1.Panel2.BackColor = Color.White;
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.BackColor = Color.Yellow;
            var task = Task.Run(() =>
            {
                //StaticWriter.Description = "Crossover.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //var script = new GEOM20Script(ScriptType.CrossoverRate);
                //RunScript(script);

                //StaticWriter.Description = "Alpha.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM20Script(ScriptType.Alpha);
                //RunScript(script);

                //StaticWriter.Description = "Immigration.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //script = new GEOM20Script(ScriptType.ImmigrationRate);
                //RunScript(script);

                //StaticWriter.Description = "Tournament.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //var script = new GEOM20Script(ScriptType.TournamentSize);
                //RunScript(script);

                //StaticWriter.Description = "Mutations_fixed.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //var script = new GEOM20Script(ScriptType.ColorsCount);
                //RunScript(script);

                //StaticWriter.Description = "colors_count.txt";
                //StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                //var script = new GEOM20Script(ScriptType.ColorsCount);
                //RunScript(script);

            });
            task.ContinueWith((t) =>
            {
                splitContainer1.Panel2.BackColor = Color.White;
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.BackColor = Color.Yellow;
            var task = Task.Run(() =>
            {
                IScript script;

                StaticWriter.Description = "Mutation.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.MutationRate);
                RunScript(script);

                StaticWriter.Description = "Mutation_Wide.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.MutationRateWide);
                RunScript(script);

                StaticWriter.Description = "Crossover.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.CrossoverRate);
                RunScript(script);

                StaticWriter.Description = "Alpha.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.Alpha);
                RunScript(script);

                StaticWriter.Description = "Alpha_Wide.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.AlphaWide);
                RunScript(script);

                StaticWriter.Description = "Immigration.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.ImmigrationRate);
                RunScript(script);

                StaticWriter.Description = "Tournament.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.TournamentSize);
                RunScript(script);

                StaticWriter.Description = "ColorsCount.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.ColorsCount);
                RunScript(script);

                StaticWriter.Description = "Population.txt";
                StaticWriter.Log(Configuration.DumpHeuristicSettingsHeader());
                script = new GEOM120Script(ScriptType.PopulationSize);
                RunScript(script);
            });
            task.ContinueWith((t) =>
            {
                splitContainer1.Panel2.BackColor = Color.White;
            });
        }
    }
}
