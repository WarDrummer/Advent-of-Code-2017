using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day12
{
    using ParserType = MultiLineStringParser;

    internal class Day12A : IProblem
    {
        protected readonly ParserType Parser;

        public Day12A(ParserType parser) { Parser = parser; }

        public Day12A() : this(new ParserType("Day12\\day12.in")) { }

        public virtual string Solve()
        {
            var lines = Parser.GetData();
            var adjacencyList = BuildAdjacencyList(lines);
            return GetNumberOfNodesThatRouteToZero(adjacencyList).ToString();
        }

        protected static Dictionary<int, List<int>> BuildAdjacencyList(IEnumerable<string> lines)
        {
            var adjacencyList = new Dictionary<int, List<int>>();
            foreach (var line in lines)
            {
                var parts = line.Split(new[] {"<->"}, StringSplitOptions.RemoveEmptyEntries);
                var target = int.Parse(parts[0]);
                var targets = parts[1].Split(',').Select(int.Parse).ToArray();

                foreach (var t in targets)
                {
                    if (!adjacencyList.ContainsKey(target))
                        adjacencyList[target] = new List<int>();

                    if (!adjacencyList[target].Contains(t))
                        adjacencyList[target].Add(t);

                    if (!adjacencyList.ContainsKey(t))
                        adjacencyList[t] = new List<int>();

                    if (!adjacencyList[t].Contains(target))
                        adjacencyList[t].Add(target);
                }
            }
            return adjacencyList;
        }

        protected int GetNumberOfNodesThatRouteToZero(Dictionary<int, List<int>> adjacencyList)
        {
            var mapsToZero = new HashSet<int> {0};

            var connectedNodes = new Queue<int>();
            connectedNodes.Enqueue(0);

            while (connectedNodes.Count > 0)
            {
                var current = connectedNodes.Dequeue();
                foreach (var child in adjacencyList[current])
                {
                    if (!mapsToZero.Contains(child))
                    {
                        connectedNodes.Enqueue(child);
                        mapsToZero.Add(child);
                    }
                }
            }

            return mapsToZero.Count;
        }
    }
}
