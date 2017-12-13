using System.Collections.Generic;

namespace AdventOfCode2017.Solutions.Day12
{
    internal class Day12B : Day12A
    {
        public override string Solve()
        {
            var lines = Parser.GetData();
            var adjacencyList = BuildAdjacencyList(lines);
            return GetNumberOfGroups(adjacencyList).ToString();
        }
        protected int GetNumberOfGroups(Dictionary<int, List<int>> adjacencyList)
        {
            var visited = new HashSet<int>();
            var count = 0;

            foreach (var key in adjacencyList.Keys)
            {
                if (visited.Contains(key))
                    continue;

                count++;
                visited.Add(key);

                var connectedNodes = new Queue<int>();
                connectedNodes.Enqueue(key);

                while (connectedNodes.Count > 0)
                {
                    var current = connectedNodes.Dequeue();
                    foreach (var child in adjacencyList[current])
                    {
                        if (!visited.Contains(child))
                        {
                            connectedNodes.Enqueue(child);
                            visited.Add(child);
                        }
                    }
                }
            }

            return count;
        }

    }
}
