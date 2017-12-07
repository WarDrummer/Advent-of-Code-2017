using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day15
{
    using ParserType = SingleLineStringParser;

    internal class Day15B : IProblem
    {
        private readonly ParserType _parser;

        public Day15B(ParserType parser)
        {
            _parser = parser;
        }

        public Day15B() : this(new ParserType("Day15\\day15.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
