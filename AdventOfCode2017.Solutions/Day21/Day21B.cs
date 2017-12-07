using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day21
{
    using ParserType = SingleLineStringParser;

    internal class Day21B : IProblem
    {
        private readonly ParserType _parser;

        public Day21B(ParserType parser)
        {
            _parser = parser;
        }

        public Day21B() : this(new ParserType("Day21\\day21.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
