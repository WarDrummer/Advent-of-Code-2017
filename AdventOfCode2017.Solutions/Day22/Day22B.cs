using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day22
{
    internal class Day22B : Day22A
    {
        public override string Solve()
        {
            const int iterations = 10000000;
            var matrix = Parser.GetData().Select(s => s.ToCharArray()).ToArray();
            var size = matrix.Length;
            var sparseArray = new Dictionary<Coordinate, char>();
            var offset = size >> 1;
            for (var y = 0; y < size; y++)
                for (var x = 0; x < size; x++)
                    if (matrix[y][x] == '#')
                        sparseArray.Add(new Coordinate(x - offset, y - offset), '#');

            var direction = 'n';
            var location = new Coordinate(0, 0);
            var numberOfInfections = 0;
            for (var count = 0; count < iterations; count++)
            {
                var currentState = sparseArray.ContainsKey(location) ? sparseArray[location] : '.';
                switch (currentState)
                {
                    case '#': // infected
                        direction = TurnRight[direction];
                        sparseArray[location] = 'f';
                        break;
                    case '.': // clean
                        direction = TurnLeft[direction];
                        sparseArray[location] = 'w';
                        break;
                    case 'f': // flagged
                        direction = TurnAround[direction];
                        sparseArray[location] = '.';
                        break;
                    case 'w': // weakened
                        sparseArray[location] = '#';
                        numberOfInfections++;
                        break;
                }

                switch (direction)
                {
                    case 'n':
                        location.Y -= 1;
                        break;
                    case 's':
                        location.Y += 1;
                        break;
                    case 'e':
                        location.X += 1;
                        break;
                    case 'w':
                        location.X -= 1;
                        break;
                }
            }

            return numberOfInfections.ToString();
        }

        public Dictionary<char, char> TurnRight = new Dictionary<char, char>
        {
            { 'n', 'e' },
            { 's', 'w' },
            { 'e', 's' },
            { 'w', 'n' }
        };

        public Dictionary<char, char> TurnLeft = new Dictionary<char, char>
        {
            { 'n', 'w' },
            { 's', 'e' },
            { 'e', 'n' },
            { 'w', 's' }
        };

        public Dictionary<char, char> TurnAround = new Dictionary<char, char>
        {
            { 'n', 's' },
            { 's', 'n' },
            { 'e', 'w' },
            { 'w', 'e' }
        };
    }
}
