using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day25
{
    using ParserType = SingleLineStringParser;

    internal class Day25B : IProblem
    {
        private readonly ParserType _parser;

        public Day25B(ParserType parser)
        {
            _parser = parser;
        }

        public Day25B() : this(new ParserType("Day25\\day25.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
