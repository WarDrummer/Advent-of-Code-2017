using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day13
{
    using ParserType = MultiLineStringParser;

    internal class Day13A : IProblem
    {
        protected readonly ParserType Parser;

        public Day13A(ParserType parser) { Parser = parser; }

        public Day13A() : this(new ParserType("Day13\\day13.in")) { }

        public virtual string Solve()
        {
            var input = Parser.GetData();
            var scannerRanges = new Dictionary<int, int>();
            var max = 0;
            foreach (var depth in input)
            {
                var parts = depth
                    .Split(new[] {": "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                scannerRanges.Add(parts[0], parts[1]);
                max = parts[0];
            }

            var scannerLocations = new List<int>(new int[max + 1]);
            var severity = 0;
            for (var layer = 0; layer < scannerLocations.Count; layer++)
            {
                if (scannerRanges.ContainsKey(layer) && scannerLocations[layer] == 0)
                    severity += scannerRanges[layer] * layer;
                AdvanceScanners(scannerLocations, scannerRanges);
            }

            return severity.ToString();
        }

        protected void AdvanceScanners(
            IList<int> scannerLocations, Dictionary<int, int> scannerRanges)
        {
            foreach (var i in scannerRanges.Keys)
            {
                if (scannerRanges[i] - 1 == scannerLocations[i])
                    scannerLocations[i] *= -1;

                scannerLocations[i]++;
            }
        }
    }
}
