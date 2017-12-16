using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day16
{
    using ParserType = SingleLineStringParser;

	internal class Day16B : Day16A
    {
		public override string Solve()
        {
			var moves = _parser.GetData().Split(',');
			var programs = "abcdefghijklmnop".ToCharArray();

			for (var i = 0; i < 1000000000; i++)
				programs = Dance(moves, programs);

			return new string(programs);
        }
    }
}
