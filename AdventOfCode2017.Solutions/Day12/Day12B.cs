using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;

namespace AdventOfCode2017.Solutions.Day12
{
    internal class Day12B : Day12A
    {
        public override string Solve()
        {
            var lines = _parser.GetData();
            var nodes = new Dictionary<int, GraphNode>();
         
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
                var target = int.Parse(parts[0]);
                var targets = parts[1].Split(',').Select(int.Parse).ToArray();

                foreach (var t in targets)
                {
                    if(!nodes.ContainsKey(t))
                        nodes[t] = new GraphNode(t);

                    if (!nodes.ContainsKey(target))
                        nodes[target] = new GraphNode(target);

                    if(!nodes[t].ConnectedNodes.Contains(target))
                        nodes[t].ConnectedNodes.Add(nodes[target].Id);

                    if (!nodes[target].ConnectedNodes.Contains(t))
                        nodes[target].ConnectedNodes.Add(nodes[t].Id);
                }
            }

            for (var i = 0; i < nodes.Count; i++)
            {
                for (var j = 0; j < nodes.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (nodes[i].ConnectedNodes.Contains(j))
                    {
                        var aggregate = nodes[i].ConnectedNodes
                            .Concat(nodes[j].ConnectedNodes)
                            .Distinct()
                            .ToList();
                        nodes[i].ConnectedNodes = aggregate;
                        nodes[j].ConnectedNodes = aggregate;
                    }
                }
            }

            var uniqueGroups = new HashSet<string>();
            foreach (var node in nodes.Values)
            {
                uniqueGroups.Add(node.GroupId);
            }

            return uniqueGroups.Count.ToString();
        }
        public class GraphNode
        {
            public int Id { get; }
            public List<int> ConnectedNodes = new List<int>();

            public GraphNode(int id) { Id = id; }

            public string GroupId
            {
                get
                {
                    var connected = ConnectedNodes.ToArray();
                    Array.Sort(connected);
                    return string.Join(",", connected);
                }
            }
        }
    }
}
