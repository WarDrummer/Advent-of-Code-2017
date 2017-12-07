using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day23
{
    using ParserType = SingleLineStringParser;

    internal class Day23A : IProblem
    {
        private readonly ParserType _parser;

        public Day23A(ParserType parser)
        {
            _parser = parser;
        }

        public Day23A() : this(new ParserType("Day23\\day23.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
