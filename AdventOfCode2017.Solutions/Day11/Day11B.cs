using System;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day11
{
    internal class Day11B : Day11A
    {
        public override string Solve()
        {
            var directions = _parser.GetData().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var q = 0;
            var r = 0;
            var start = new AxialHexCoordinate(0, 0);
            var max = int.MinValue;
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "n": q++; break;
                    case "nw": q++; r--; break;
                    case "ne": r++; break;
                    case "s": q--; break;
                    case "sw": r--; break;
                    case "se": q--; r++; break;
                }

                var distance = new AxialHexCoordinate(q, r).GetDistanceTo(start);
                if (distance > max)
                    max = distance;
            }

            return max.ToString();
        }
    }
}
