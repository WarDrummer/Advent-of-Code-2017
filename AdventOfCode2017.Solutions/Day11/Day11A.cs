using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day11
{
    using ParserType = SingleLineStringParser;

    internal class Day11A : IProblem
    {
        protected readonly ParserType _parser;

        public Day11A(ParserType parser) { _parser = parser; }

        public Day11A() : this(new ParserType("Day11\\day11.in")) { }


        public virtual string Solve()
        {
            var directions = _parser.GetData().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var q = 0;
            var r = 0;

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "n": q++; break;
                    case "nw": q++; r--;  break;
                    case "ne": r++;  break;
                    case "s": q--; break;
                    case "sw": r--;  break;
                    case "se": q--; r++; break;
                }
            }

            return new AxialHexCoordinate(q, r)
                .GetDistanceTo(new AxialHexCoordinate(0, 0))
                .ToString();
        }
    }
}
