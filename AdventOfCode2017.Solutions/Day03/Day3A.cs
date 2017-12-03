namespace AdventOfCode2017.Solutions.Day3
{
    using System;
    using System.Collections.Generic;
    using ParserType = SingleLineStringParser;

    internal class Day3A : IProblem
    {
        private readonly ParserType _parser;

        public Day3A(ParserType parser)
        {
            _parser = parser;
        }

        public Day3A() : this(new ParserType("Day03\\day3.in"))
        {

        }
        
        public virtual string Solve()
        {
            var number = int.Parse(_parser.Parse());
            var mapping = new Dictionary<int, Coordinate>();

            var current = 1;
            var x = 1;
            var y = 1;
            var width = 8;

            mapping.Add(current++, new Coordinate(x, y));

            while (current < number)
            {
                mapping.Add(current++, new Coordinate(++x, y));

                var len = width / 4;

                // move up
                for(var i = 0; i < len - 1; i++)
                    mapping.Add(current++, new Coordinate(x, ++y));

                // move left
                for (var i = 0; i < len; i++)
                    mapping.Add(current++, new Coordinate(--x, y));

                // move down
                for (var i = 0; i < len; i++)
                    mapping.Add(current++, new Coordinate(x, --y));

                // move right
                for (var i = 0; i < len; i++)
                    mapping.Add(current++, new Coordinate(++x, y));

                width += 8;
            }

            return (Math.Abs(mapping[number].X - mapping[1].X) + Math.Abs(mapping[number].Y - mapping[1].Y)).ToString();
        }
    }
}
