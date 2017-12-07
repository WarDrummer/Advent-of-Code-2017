using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day13
{
    using ParserType = SingleLineStringParser;

    internal class Day13A : IProblem
    {
        private readonly ParserType _parser;

        public Day13A(ParserType parser)
        {
            _parser = parser;
        }

        public Day13A() : this(new ParserType("Day13\\day13.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
