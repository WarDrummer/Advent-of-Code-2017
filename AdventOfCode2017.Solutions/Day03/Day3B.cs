using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day03
{
    using System;
    using System.Collections.Generic;

    using ParserType = SingleLineStringParser;

    internal class Day3B : IProblem
    {
        private readonly Dictionary<Coordinate, int> _mapping = new Dictionary<Coordinate, int>();
        private readonly ParserType _parser;

        public Day3B(ParserType parser) { _parser = parser; }

        public Day3B() : this(new ParserType("Day03\\day3.in")) { }

        public virtual string Solve()
        {
            var number = int.Parse(_parser.GetData());
            int current = 0;
            foreach (var coordinate in SpiralCoordinates.GenerateCounterClockwise(number))
            {
                current = Math.Max(1, GetValueForCoordinates(coordinate.X, coordinate.Y));
                if (current > number)
                    break;
                _mapping.Add(coordinate, current);
            }

            return current.ToString();
        }

        private int GetValueForCoordinates(int x, int y)
        {
            var sum = 0;
            
            sum += _mapping.GetValueOrDefault(new Coordinate(x-1, y+1), 0); // top left
            sum += _mapping.GetValueOrDefault(new Coordinate(x,   y+1), 0); // top
            sum += _mapping.GetValueOrDefault(new Coordinate(x+1, y+1), 0); // top right
            sum += _mapping.GetValueOrDefault(new Coordinate(x-1, y  ), 0); // left
            sum += _mapping.GetValueOrDefault(new Coordinate(x+1, y  ), 0); // right
            sum += _mapping.GetValueOrDefault(new Coordinate(x-1, y-1), 0); // bottom left
            sum += _mapping.GetValueOrDefault(new Coordinate(x,   y-1), 0); // bottom
            sum += _mapping.GetValueOrDefault(new Coordinate(x+1, y-1), 0); // bottom right

            return sum;
        }
    }
}
