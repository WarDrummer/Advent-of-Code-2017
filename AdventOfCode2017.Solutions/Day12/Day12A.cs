using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day12
{
    using ParserType = MultiLineStringParser;

    internal class Day12A : IProblem
    {
        protected readonly ParserType _parser;

        public Day12A(ParserType parser) { _parser = parser; }

        public Day12A() : this(new ParserType("Day12\\day12.in")) { }

        public virtual string Solve()
        {
            var lines = _parser.GetData();
            var mappings = new Dictionary<int, List<int>>();
            foreach (var line in lines)
            {
                var parts = line.Split(new [ ]{"<->"}, StringSplitOptions.RemoveEmptyEntries);
                var target = int.Parse(parts[0]);
                var targets = parts[1].Split(',').Select(int.Parse).ToArray();

                foreach (var t in targets)
                {
                    if(!mappings.ContainsKey(target))
                        mappings[target] = new List<int>();

                    if (!mappings[target].Contains(t))
                        mappings[target].Add(t);

                    if (!mappings.ContainsKey(t))
                        mappings[t] = new List<int>();

                    if (!mappings[t].Contains(target))
                        mappings[t].Add(target);
                }
            }

            var count = 0;
            foreach (var kvp in mappings)
                count += RoutesToZero(kvp.Key, mappings, new HashSet<int>());

            return count.ToString();
        }

        private int RoutesToZero(int startingPoint, Dictionary<int, List<int>> routes, HashSet<int> visited)
        {
            visited.Add(startingPoint);
            if (startingPoint == 0)
                return 1;
            if (routes[startingPoint].Contains(0))
                return 1;
            foreach(var child in routes[startingPoint])
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    if (RoutesToZero(child, routes, visited) > 0)
                        return 1;
                }
            }

            return 0;
        }
    }


}
