using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_1.Models
{
    public class Genotype
    {
        public IList<Edge> Edges { get; set; }

        public Gene[] Genes { get; set; }

        public int MaxID { get; set; }

        public Genotype(IList<Edge> edges, IList<int> verticesIds, int maxID)
        {
            Edges = edges;

            Genes = new Gene[maxID + 1];

            foreach (var id in verticesIds)
            {
                Genes[id] = new Gene(id);
            }

            MaxID = maxID;
        }

        public bool IsValid()
        {
            var isValid = true;
            for (int i = 0; isValid && i < Edges.Count; i++)
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

            result.AppendLine(string.Format("edges: {0} vertices: {1}", Edges.Count, Genes.Count()));
            result.AppendLine(string.Format("colors: {0} k: {1}", GetColorsCount(), GetMaxColor()));
            result.AppendLine(new string('-', 50));

            return result.ToString();
        }

        public string Dump()
        {
            var colors = GetColorsCount().ToString().PadLeft(3, ' ');
            var k = GetMaxColor().ToString().PadLeft(3, ' ');

            var isValid = IsValid();
            var isValidText = isValid ? string.Empty : "INVALID";

            var text = string.Format("colors:{0} k:{1} valid:{2}", colors, k, isValidText);

            return text;
        }
    }
}
