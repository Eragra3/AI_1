using AI_1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Genotype
    {
        private static int idCounter = 1;

        public int ID { get; set; }

        public Edge[] Edges { get; set; }

        public Gene[] Genes { get; set; }

        public int MaxID { get; set; }

        public bool IsWild  { get; set; }

        public Genotype(Edge[] edges, IList<int> verticesIds, int maxID)
        {
            ID = idCounter++;

            Edges = edges;

            Genes = new Gene[maxID + 1];

            foreach (var id in verticesIds)
            {
                Genes[id] = new Gene(id);
            }

            MaxID = maxID;
        }

        public Genotype(Edge[] edges, int maxID)
        {
            ID = idCounter++;

            Edges = edges;

            Genes = new Gene[maxID + 1];

            MaxID = maxID;
        }

        public bool IsValid()
        {
            var isValid = true;
            for (int i = 0; isValid && i < Edges.Length; i++)
            {
                var edge = Edges[i];

                var color1 = Genes[edge.Vertex1ID].color;
                var color2 = Genes[edge.Vertex2ID].color;

                isValid = edge.IsValidWithColors(color1, color2);
            }

            return isValid;
        }

        public int GetColorsCount()
        {
            IList<int> colors = new List<int>(20);

            foreach (var gene in Genes)
            {
                if (gene != null && !colors.Contains(gene.color))
                {
                    colors.Add(gene.color);
                }
            }

            return colors.Count;
        }

        public int GetMaxColor()
        {
            var maxColor = 0;
            foreach (var gene in Genes)
            {
                if (gene != null && maxColor < gene.color)
                {
                    maxColor = gene.color;
                }
            }

            return maxColor;
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(new string('-', 50));
            result.AppendLine("GENOTYPE");

            foreach (var edge in Edges)
            {
                result.AppendLine(edge.Print(Genes));
            }
            foreach (var gene in Genes)
            {
                if (gene != null)
                {
                    result.AppendLine(gene.Print());
                }
            }

            result.AppendLine(string.Format("edges: {0} vertices: {1}", Edges.Length, Genes.Count()));
            result.AppendLine(string.Format("colors: {0} k: {1}", GetColorsCount(), GetMaxColor()));
            result.AppendLine(new string('-', 50));

            return result.ToString();
        }

        public string Dump()
        {
            var colors = GetColorsCount();
            var k = GetMaxColor();
            var fitness = GAExecutor.GetFitness(this);
            var invalidEdges = GetInvalidEdgesCount();
            var isValid = invalidEdges == 0;
            var isValidText = isValid ? 1 : 0;

            var text = string.Format("{0},{1},{2},{3},{4}",
                colors,
                k,
                isValidText,
                fitness,
                invalidEdges);

            return text;
        }

        public int GetInvalidEdgesCount()
        {
            var invalidCount = 0;
            foreach (var edge in Edges)
            {
                var color1 = Genes[edge.Vertex1ID].color;
                var color2 = Genes[edge.Vertex2ID].color;

                if (!edge.IsValidWithColors(color1, color2))
                {
                    invalidCount++;
                }
            }

            return invalidCount;
        }
    }
}
