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
        private Graph graph;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ReadFile(object sender, EventArgs e)
        {
            var parse = new COLReader();

            graph = parse.ParseFile(Configuration.GEOM20);
            //Console.WriteLine(graph.Print());
            WriteToConsole(graph.Print());
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
            if (graph != null)
            {
                var randomizer = new Randomizer();
                randomizer.RandomizeColors(graph);

                WriteToConsole(graph.Print());
            }
        }
    }
}
