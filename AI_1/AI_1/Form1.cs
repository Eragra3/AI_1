﻿using AI_1.Enums;
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
        private GAExecutor executor;

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
            if (executor == null)
            {
                var parse = new COLReader();


                var usedFile = Configuration.GEOM40;
                var graph = parse.ParseFile(usedFile);
                Configuration.SourceFilePath = usedFile;

                executor = new GAExecutor(graph);
            }
            var solution = executor.RunHeuristic(Configuration.PopulationCount, Configuration.GenerationsCount);

            Console.WriteLine(solution?.Dump() ?? string.Empty);
            Console.WriteLine(solution?.Print() ?? string.Empty);
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
                    var sw = new Stopwatch();

                    sw.Start();

                    var solution = experiment.Run();

                    var duration = sw.ElapsedMilliseconds;

                    writer.WriteLine("EXPERIMENT {0}", experimentNumber++);
                    writer.WriteLine("duration: {0}ms", duration);
                    writer.WriteLine(solution?.Dump() ?? string.Empty);
                    writer.WriteLine(solution?.Print() ?? string.Empty);
                    writer.WriteLine("@".PadLeft(40, '@'));
                    writer.WriteLine("@".PadLeft(40, '@'));
                    writer.WriteLine("@".PadLeft(40, '@'));
                    writer.Flush();

                    solutions.Add(solution);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var script = new GEOM40Script();

            RunScript(script);
        }
    }
}
