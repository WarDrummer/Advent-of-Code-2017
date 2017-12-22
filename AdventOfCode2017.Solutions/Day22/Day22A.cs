using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Day19;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day22
{
    using ParserType = MultiLineStringParser;

    internal class Day22A : IProblem
    {
        protected readonly ParserType Parser;

        public Day22A(ParserType parser) { Parser = parser; }

        public Day22A() : this(new ParserType("Day22\\day22.in")) { }

        public virtual string Solve()
        {
            const int iterations = 10000;
            var matrix = Parser.GetData().Select(s => s.ToCharArray()).ToArray();
            var size = matrix.Length;
            var sparseArray = new Dictionary<Coordinate, char>();
            var offset = size >> 1;
            for (var y = 0; y < size; y++)
                for (var x = 0; x < size; x++)
                    if(matrix[y][x] == '#')
                        sparseArray.Add(new Coordinate(x - offset, y - offset), '#');

            var direction = 'n';
            var location = new Coordinate(0,0);
            var numberOfInfections = 0;
            for (var count = 0; count < iterations; count++)
            {
                if (sparseArray.ContainsKey(location) && sparseArray[location] == '#')
                {
                    // INFECTED, turn right
                    sparseArray[location] = '.';
                    switch (direction)
                    {
                        case 'n': direction = 'e'; break;
                        case 's': direction = 'w'; break;
                        case 'e': direction = 's'; break;
                        case 'w': direction = 'n'; break;
                    }
                }
                else
                {
                    // NOT INFECTED, turn left
                    sparseArray[location] = '#';
                    numberOfInfections++;
                    switch (direction)
                    {
                        case 'n': direction = 'w'; break;
                        case 's': direction = 'e'; break;
                        case 'e': direction = 'n'; break;
                        case 'w': direction = 's'; break;
                    }
                }

                switch (direction)
                {
                    case 'n': location = location.North(); break;
                    case 's': location = location.South(); break;
                    case 'e': location = location.East(); break;
                    case 'w': location = location.West(); break;
                }
            }

            return numberOfInfections.ToString();
        }
    }
}
