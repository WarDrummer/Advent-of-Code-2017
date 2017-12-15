using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Extensions;

namespace AdventOfCode2017.Solutions.Day14
{
    internal class Day14B : Day14A
    {
        private readonly int[][] _rows = new int[128][];
        private int _currentGroupNumber = 2;

        public override string Solve()
        {
            var input = Parser.GetData();

            for (var i = 0; i < 128; i++)
            {
                var hash = KnotHasher.ComputeKnotHash($"{input}-{i}");
                var binary = hash.FromHexStringToBinaryString();
                _rows[i] = binary.Select(c => c - '0').ToArray();
            }

            for (var x = 0; x < 128; x++)
            {
                for (var y = 0; y < 128; y++)
                {
                    if (_rows[x][y] != 1)
                        continue;

                    _rows[x][y] = ++_currentGroupNumber;

                    var q = new Queue<Coordinate>();
                    q.Enqueue(new Coordinate(x, y));

                    while (q.Count > 0)
                    {
                        var current = q.Dequeue();
                        QueueValidCoordinate(current.X, current.Y + 1, q);
                        QueueValidCoordinate(current.X, current.Y - 1, q);
                        QueueValidCoordinate(current.X + 1, current.Y, q);
                        QueueValidCoordinate(current.X - 1, current.Y, q);
                    }
                }
            }

            return (_currentGroupNumber - 2).ToString();
        }

        private void QueueValidCoordinate(int x, int y, Queue<Coordinate> q)
        {
            if (x >= 0 && x < 128 && y >= 0 && y < 128 && _rows[x][y] == 1)
            {
                _rows[x][y] = _currentGroupNumber;
                q.Enqueue(new Coordinate(x, y));
            }
        }
    }
}
