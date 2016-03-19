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
                var edges = new List<Edge>(200);
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

                            var vertex = new Vertex();
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

                            //skip loops in graph
                            if (firstVertexId == secondVertexId) continue;

                            var edge = new Edge
                            {
                                Vertex1ID = firstVertexId,
                                Vertex2ID = secondVertexId,
                                Weight = weight
                            };

                            edges.Add(edge);
                        }
                    }
                }
                graph.Edges = edges.ToArray();
                foreach (var edge in graph.Edges)
                {
                    edge.Vertex1 = graph.Vertices[edge.Vertex1ID - 1];
                    edge.Vertex2 = graph.Vertices[edge.Vertex2ID - 1];
                }

                //remove disjoined vertices
                //for (int i = 0; i < graph.Vertices.Count; i++)
                //{
                //    var vertex = graph.Vertices[i];

                //    var disjoined = true;

                //    for (int j = 0; disjoined && j < graph.Edges.Count; j++)
                //    {
                //        if (graph.Edges[j].Vertex1 == vertex || graph.Edges[j].Vertex2 == vertex)
                //        {
                //            disjoined = false;
                //        }
                //    }
                //    if (disjoined)
                //    {
                //        graph.Vertices.RemoveAt(i);
                //        //.NET remove empty spaces in lists, next item is now at current index
                //        i--;
                //    }
                //}

                //find all unique vertices ids and find biggest id
                int maxID = 0;
                foreach (var edge in graph.Edges)
                {
                    if (edge.Vertex1ID > maxID)
                    {
                        maxID = edge.Vertex1ID;
                    }
                    if (edge.Vertex2ID > maxID)
                    {
                        maxID = edge.Vertex2ID;
                    }

                    if (!graph.VerticesIds.Contains(edge.Vertex1ID))
                    {
                        graph.VerticesIds.Add(edge.Vertex1ID);
                    }
                    if (!graph.VerticesIds.Contains(edge.Vertex2ID))
                    {
                        graph.VerticesIds.Add(edge.Vertex2ID);
                    }
                }
                graph.MaxVertexID = maxID;
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
