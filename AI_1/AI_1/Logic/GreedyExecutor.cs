using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Models;

namespace AI_1.Logic
{
    public class GreedyExecutor
    {
        private Graph _loadedGraph;

        private StreamWriter _writer;

        public GreedyExecutor(Graph sourceGraph)
        {
            _loadedGraph = sourceGraph;
        }

        public Genotype GetSolution(string logFilePath = null, bool openLogFile = false)
        {
            Genotype solution = new Genotype(_loadedGraph.Edges, _loadedGraph.VerticesIds, _loadedGraph.MaxVertexID); ;

            logFilePath = logFilePath ?? Configuration.GetLogFilePath;

            var lastSlash = logFilePath.LastIndexOf('/');

            Directory.CreateDirectory(logFilePath.Substring(0, lastSlash));

            using (_writer = new StreamWriter(logFilePath, true))
            {
                if (openLogFile) Process.Start(logFilePath);

                foreach (var vertex in solution.Genes)
                {
                    if (vertex != null) vertex.color = 1;
                }

                var lel = 0;
                while (!solution.IsValid())
                {
                    foreach (var edge in solution.Edges)
                    {
                        var vertex1 = solution.Genes[edge.Vertex1ID];
                        var vertex2 = solution.Genes[edge.Vertex2ID];

                        if (!edge.IsValidWithColors(vertex1.color, vertex2.color))
                        {
                            if (vertex1.color > vertex2.color)
                            {
                                vertex1.color += edge.Weight - Math.Abs(vertex1.color - vertex2.color);
                            }
                            else
                            {
                                vertex2.color += edge.Weight - Math.Abs(vertex1.color - vertex2.color);
                            }
                        }
                    }
                    lel++;
                }

                _writer.WriteLine(solution.Dump());
                _writer.WriteLine(solution.Print());
                Console.WriteLine(lel);
            }

            return solution;
        }
    }
}
