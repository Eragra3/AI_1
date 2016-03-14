using AI_1.Enums;
using AI_1.Logic;
using AI_1.Models;
using AI_1.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void ReadFile(object sender, EventArgs e)
        {
            var parse = new COLReader();

            var graph = parse.ParseFile(Configuration.GEOM20);

            executor = new GAExecutor(graph);

            WriteToConsole(executor.LoadedGraph.Print());
        }

        public void WriteToConsole(string text)
        {
            Console_AI.AppendText(text);
        }

        private void Console_AI_TextChanged(object sender, EventArgs e)
        {

        }

        private void randomizeButton_Click(object sender, EventArgs e)
        {
            if (executor != null)
            {
                var bestG = GetRandomGenotype(executor.LoadedGraph);

                WriteToConsole(bestG.Print());
            }
        }

        private void startAlgorithmButton_Click(object sender, EventArgs e)
        {
            if (executor == null)
            {
                var parse = new COLReader();

                var graph = parse.ParseFile(Configuration.GEOM100a);

                executor = new GAExecutor(graph);
            }
            var solution = executor.RunHeuristic(Configuration.PopulationCount, Configuration.GenerationsCount);
            if (solution != null)
            {
                WriteToConsole(solution.Print());
            }
        }

        private Genotype GetRandomGenotype(Graph graph, int n = 100)
        {
            var randomizer = new Randomizer();

            Genotype bestG = randomizer.GetRandomGenotype(graph);
            for (int i = 0; i < n; i++)
            {
                var genotype = randomizer.GetRandomGenotype(graph);
                if (genotype.GetMaxColor() < bestG.GetMaxColor())
                {
                    bestG = genotype;
                }
            }

            return bestG;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
