using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day19
{
    using ParserType = SingleLineStringParser;

    internal class Day19B : IProblem
    {
        private readonly ParserType _parser;

        public Day19B(ParserType parser)
        {
            _parser = parser;
        }

        public Day19B() : this(new ParserType("Day19\\day19.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
