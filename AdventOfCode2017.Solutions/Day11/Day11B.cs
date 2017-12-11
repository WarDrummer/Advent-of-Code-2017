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

            var x = 0;
            var y = 0;
            var start = new AxialHexNode(x, y).ToCubeHex();
            var max = int.MinValue;
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "n": x++; break;
                    case "nw": x++; y--; break;
                    case "ne": y++; break;
                    case "s": x--; break;
                    case "sw": y--; break;
                    case "se": x--; y++; break;
                }

                var cubeHex = new AxialHexNode(x, y).ToCubeHex();
                var distance = cubeHex.GetDistanceTo(start);
                if (distance > max)
                    max = distance;
            }

            return max.ToString();
        }
    }
}
