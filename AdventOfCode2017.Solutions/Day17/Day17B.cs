using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day17
{
    using ParserType = SingleLineStringParser;

    internal class Day17B : IProblem
    {
        private readonly ParserType _parser;

        public Day17B(ParserType parser)
        {
            _parser = parser;
        }

        public Day17B() : this(new ParserType("Day17\\day17.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
