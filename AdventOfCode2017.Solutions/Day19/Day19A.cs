using System.Linq;
using System.Text;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day19
{
    using ParserType = MultiLineStringParser;

    internal class Day19A : IProblem
    {
        protected readonly ParserType Parser;

        public Day19A(ParserType parser) { Parser = parser; }

        public Day19A() : this(new ParserType("Day19\\day19.in")) { }

        private string[] _lines;
        protected int Steps;
        protected string Path;

        public virtual string Solve()
        {
            RunPath();
            return Path;
        }

        protected void RunPath()
        {
            _lines = Parser.GetData().ToArray();

            var location = new Coordinate(_lines[0].IndexOf('|'), 0);
            var direction = 's';
            var end = false;
            var sb = new StringBuilder();

            while (!end)
            {
                Steps++;
                if (char.IsLetter(_lines[location.Y][location.X]))
                    sb.Append(_lines[location.Y][location.X]);

                switch (direction)
                {
                    case 'n':
                        if (CanMoveNorth(ref location, ref direction)) break;
                        if (CanMoveEast(ref location, ref direction)) break;
                        if (CanMoveWest(ref location, ref direction)) break;
                        end = true;
                        break;
                    case 's':
                        if (CanMoveSouth(ref location, ref direction)) break;
                        if (CanMoveEast(ref location, ref direction)) break;
                        if (CanMoveWest(ref location, ref direction)) break;
                        end = true;
                        break;
                    case 'e':
                        if (CanMoveEast(ref location, ref direction)) break;
                        if (CanMoveSouth(ref location, ref direction)) break;
                        if (CanMoveNorth(ref location, ref direction)) break;
                        end = true;
                        break;
                    case 'w':
                        if (CanMoveWest(ref location, ref direction)) break;
                        if (CanMoveSouth(ref location, ref direction)) break;
                        if (CanMoveNorth(ref location, ref direction)) break;
                        end = true;
                        break;
                }
            }
            Path = sb.ToString();
        }

        private bool CanMoveSouth(ref Coordinate location, ref char direction)
        {
            var s = location.South();
            if (CanMove(s))
            {
                location = s;
                direction = 's';
                return true;
            }
            return false;
        }

        private bool CanMoveWest(ref Coordinate location, ref char direction)
        {
            var w = location.West();
            if (CanMove(w))
            {
                location = w;
                direction = 'w';
                return true;
            }
            return false;
        }

        private bool CanMoveEast(ref Coordinate location, ref char direction)
        {
            var e = location.East();
            if (CanMove(e))
            {
                location = e;
                direction = 'e';
                return true;
            }
            return false;
        }

        private bool CanMoveNorth(ref Coordinate location, ref char direction)
        {
            var n = location.North();
            if (CanMove(n))
            {
                location = n;
                direction = 'n';
                return true;
            }
            return false;
        }

        private bool CanMove(Coordinate c)
        {
            return CanMove(c.X, c.Y);
        }

        private bool CanMove(int x, int y)
        {
            if (_lines.Length > y && y >= 0)
            {
                if (_lines[y].Length > x && x >= 0)
                {
                    return _lines[y][x] != ' ';
                }
            }
            return false;
        }
    }

    internal static class CoordinateExtensions
    {
        internal static Coordinate North(this Coordinate c)
        {
            return new Coordinate(c.X, c.Y - 1);
        }
        internal static Coordinate South(this Coordinate c)
        {
            return new Coordinate(c.X, c.Y + 1);
        }
        internal static Coordinate East(this Coordinate c)
        {
            return new Coordinate(c.X + 1, c.Y);
        }
        internal static Coordinate West(this Coordinate c)
        {
            return new Coordinate(c.X - 1, c.Y);
        }
    }
}
