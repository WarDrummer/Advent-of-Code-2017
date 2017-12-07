using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day24
{
    using ParserType = SingleLineStringParser;

    internal class Day24B : IProblem
    {
        private readonly ParserType _parser;

        public Day24B(ParserType parser)
        {
            _parser = parser;
        }

        public Day24B() : this(new ParserType("Day24\\day24.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
