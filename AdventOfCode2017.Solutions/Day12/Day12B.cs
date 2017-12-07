using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day12
{
    using ParserType = SingleLineStringParser;

    internal class Day12B : IProblem
    {
        private readonly ParserType _parser;

        public Day12B(ParserType parser)
        {
            _parser = parser;
        }

        public Day12B() : this(new ParserType("Day12\\day12.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
