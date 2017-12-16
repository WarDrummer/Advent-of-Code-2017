using System;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day16
{
    using ParserType = SingleLineStringParser;

    internal class Day16A : IProblem
    {
		protected readonly ParserType _parser;

        public Day16A(ParserType parser) { _parser = parser; }

        public Day16A() : this(new ParserType("Day16/day16.in")) { }

        public virtual string Solve()
		{
			var moves = _parser.GetData().Split(',');
			var programs = "abcdefghijklmnop".ToCharArray();
			programs = Dance(moves, programs);
			return new string(programs);
		}

		protected static char[] Dance(string[] moves, char[] programs)
		{
			foreach (var move in moves)
			{
				switch (move[0])
				{
					case 's':
						var rotate = int.Parse(move.Substring(1, move.Length - 1));
						Rotate(ref programs, rotate);
						break;
					case 'x':
						{
							var indexes = move.Substring(1, move.Length - 1).Split('/').Select(int.Parse).ToArray();
							SwapAtIndexes(ref programs, indexes);
						}
						break;
					case 'p':
						{
							var indexes = move.Substring(1, move.Length - 1).Split('/').Select(c => c[0]).Select(c => IndexOf(c, programs)).ToArray();
							SwapAtIndexes(ref programs, indexes);
						}
						break;
				}
			}

			return programs;
		}

		private static void SwapAtIndexes(ref char[] programs, int[] indexes)
		{
			var temp = programs[indexes[0]];
			programs[indexes[0]] = programs[indexes[1]];
			programs[indexes[1]] = temp;
		}

		private static int IndexOf(char program, char[] programs)
		{
			for (var i = 0; i < programs.Length; i++)
				if (programs[i] == program)
					return i;
			return -1;
		}

		private static void Rotate(ref char[] chars, int rotation)
		{
			var length = chars.Length;
			rotation = (rotation % length);
			rotation = length - rotation;
			var rotated = new char[length];
			for (var i = 0; i < length; i++, rotation++)
				rotated[i] = chars[rotation % length];
			chars = rotated;
		}
	}
}
