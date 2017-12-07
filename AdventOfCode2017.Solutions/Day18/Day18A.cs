using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day18
{
    using ParserType = SingleLineStringParser;

    internal class Day18A : IProblem
    {
        private readonly ParserType _parser;

        public Day18A(ParserType parser)
        {
            _parser = parser;
        }

        public Day18A() : this(new ParserType("Day18\\day18.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
