namespace AdventOfCode2017.Solutions.Day3
{
    using System.Collections.Generic;
    using ParserType = SingleLineStringParser;

    internal class Day3B : IProblem
    {
        private Dictionary<Coordinate, int> _mapping = new Dictionary<Coordinate, int>();
        private readonly ParserType _parser;

        public Day3B(ParserType parser)
        {
            _parser = parser;
        }

        public Day3B() : this(new ParserType("Day03\\day3.in"))
        {

        }

        public virtual string Solve()
        {
            var number = int.Parse(_parser.Parse());

            var current = 1;
            var x = 1;
            var y = 1;
            var width = 8;

            _mapping.Add(new Coordinate(x, y), 1);

            while (current < number)
            {
                current = GetValueForCoordinates(++x, y);
                _mapping.Add(new Coordinate(x, y), current);

                var len = width / 4;

                // move up
                for (var i = 0; i < len - 1 && current < number; i++)
                {
                    current = GetValueForCoordinates(x, ++y);
                    _mapping.Add(new Coordinate(x, y), current);
                }

                // move left
                for (var i = 0; i < len && current < number; i++)
                {
                    current = GetValueForCoordinates(--x, y);
                    _mapping.Add(new Coordinate(x, y), current);
                }

                // move down
                for (var i = 0; i < len && current < number; i++)
                {
                    current = GetValueForCoordinates(x, --y);
                    _mapping.Add(new Coordinate(x, y), current);
                }

                // move right
                for (var i = 0; i < len && current < number; i++)
                {
                    current = GetValueForCoordinates(++x, y);
                    _mapping.Add(new Coordinate(x, y), current);
                }

                width += 8;
            }

            return current.ToString();
        }

        private int GetValueForCoordinates(int x, int y)
        {
            var sum = 0;

            var topLeft = new Coordinate(x - 1, y + 1);
            if (_mapping.ContainsKey(topLeft))
                sum += _mapping[topLeft];

            var top = new Coordinate(x, y + 1);
            if (_mapping.ContainsKey(top))
                sum += _mapping[top];

            var topRight = new Coordinate(x + 1, y + 1);
            if (_mapping.ContainsKey(topRight))
                sum += _mapping[topRight];

            var left = new Coordinate(x - 1, y);
            if (_mapping.ContainsKey(left))
                sum += _mapping[left];

            var right = new Coordinate(x + 1, y);
            if (_mapping.ContainsKey(right))
                sum += _mapping[right];

            var bottomLeft = new Coordinate(x - 1, y - 1);
            if (_mapping.ContainsKey(bottomLeft))
                sum += _mapping[bottomLeft];

            var bottom = new Coordinate(x, y - 1);
            if (_mapping.ContainsKey(bottom))
                sum += _mapping[bottom];

            var bottomRight = new Coordinate(x + 1, y - 1);
            if (_mapping.ContainsKey(bottomRight))
                sum += _mapping[bottomRight];

            return sum;
        }
    }
}
