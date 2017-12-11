using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day11
{
    using ParserType = SingleLineStringParser;

    internal class Day11A : IProblem
    {
        protected readonly ParserType _parser;

        public Day11A(ParserType parser) { _parser = parser; }

        public Day11A() : this(new ParserType("Day11\\day11.in")) { }

        public virtual string Solve()
        {
            return "";
        }
    }
}
