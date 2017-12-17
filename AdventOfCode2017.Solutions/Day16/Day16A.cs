using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day16
{
    using ParserType = SingleLineStringParser;

    internal class Day16A : IProblem
    {
		protected readonly ParserType Parser;
        protected List<IDanceMove> DanceMoves;
        protected char[] Programs = "abcdefghijklmnop".ToCharArray();

        public Day16A(ParserType parser) { Parser = parser; }

        public Day16A() : this(new ParserType("Day16/day16.in")) { }

        public virtual string Solve()
		{
			var moves = Parser.GetData().Split(',');
		    DanceMoves = GetDanceMoves(moves, Programs);
		    PerformDance();
            return new string(Programs);
		}

        protected void PerformDance()
        {
            foreach (var move in DanceMoves)
                move.Perform(ref Programs);
        }

        protected static List<IDanceMove> GetDanceMoves(string[] moves, char[] programs)
        {
            var danceMoves = new List<IDanceMove>(moves.Length);
            foreach (var move in moves)
            {
                if (move[0] == 's')
                {
                    var rotate = int.Parse(move.Substring(1, move.Length - 1));
                    danceMoves.Add(new RotateMove(rotate, programs.Length));
                }
                else if (move[0] == 'x')
                {
                    {
                        var indexes = move
                            .Substring(1, move.Length - 1)
                            .Split('/')
                            .Select(int.Parse)
                            .ToArray();

                        danceMoves.Add(new SwapPositionMove(indexes[0], indexes[1]));
                    }
                }
                else if (move[0] == 'p')
                {
                    {
                        var indexes = move.Substring(1, move.Length - 1)
                            .Split('/')
                            .Select(c => c[0])
                            .ToArray();

                        danceMoves.Add(new SwapProgramMove(indexes[0], indexes[1]));
                    }
                }
            }
            return danceMoves;
        }
    }
}
