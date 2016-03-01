using AI_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AI_1.Parser
{
    public class COLReader
    {
        public Graph ParseFile(string path)
        {
            var graph = new Graph();

            try
            {
                string line;
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                        {
                            //if some accidental empty lines in file (or at the end), try to still read it
                            continue;
                        }

                        string[] lineElements = Regex.Split(line.Substring(2), @"\D+");
                        lineElements = lineElements.Where(val => !string.IsNullOrEmpty(val)).ToArray();

                        var elementTag = line[0];

                        if (elementTag.Equals('c'))
                        {
                            continue;
                        }
                        else if (elementTag.Equals('p'))
                        {
                            continue;
                        }
                        else if (elementTag.Equals('n'))
                        {
                            int weight;

                            weight = int.Parse(lineElements[0]);

                            var vertex = new Vertex { Weight = weight };
                            graph.Vertices.Add(vertex);
                        }
                        else if (elementTag.Equals('e'))
                        {
                            int firstVertexId;
                            int secondVertexId;
                            int weight;

                            firstVertexId = int.Parse(lineElements[0]);
                            secondVertexId = int.Parse(lineElements[1]);
                            weight = int.Parse(lineElements[2]);

                            var edge = new Edge
                            {
                                Vertex1ID = firstVertexId,
                                Vertex2ID = secondVertexId,
                                Weight = weight
                            };

                            graph.Edges.Add(edge);
                        }
                    }
                }
                foreach (var edge in graph.Edges)
                {
                    edge.Vertex1 = graph.Vertices[edge.Vertex1ID - 1];
                    edge.Vertex2 = graph.Vertices[edge.Vertex2ID - 1];
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(string.Format("File not found using path: {0}\nSee error below", path));
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return graph;
        }
    }
}
