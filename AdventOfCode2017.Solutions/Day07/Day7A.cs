using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day07
{
    using ParserType = SingleLineStringParser;

    internal class Day7A : IProblem
    {
        private readonly ParserType _parser;

        public Day7A(ParserType parser)
        {
            _parser = parser;
        }

        public Day7A() : this(new ParserType("Day07\\day7.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
