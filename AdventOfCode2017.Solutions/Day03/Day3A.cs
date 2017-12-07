using System;
using System.Collections.Generic;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day03
{
    using ParserType = SingleLineStringParser;

    internal class Day3A : IProblem
    {
        private readonly ParserType _parser;

        public Day3A(ParserType parser) { _parser = parser; }

        public Day3A() : this(new ParserType("Day03\\day3.in")) { }
        
        public virtual string Solve()
        {
            var number = int.Parse(_parser.GetData());
            var mapping = new Dictionary<int, Coordinate>(number);
            var current = 1;

            foreach(var coordinate in SpiralCoordinates.GenerateCounterClockwise(number))
                mapping.Add(current++, coordinate);

            return (Math.Abs(mapping[number].X - mapping[1].X) + Math.Abs(mapping[number].Y - mapping[1].Y)).ToString();
        }
    }
}
