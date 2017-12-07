using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day22
{
    using ParserType = SingleLineStringParser;

    internal class Day22A : IProblem
    {
        private readonly ParserType _parser;

        public Day22A(ParserType parser)
        {
            _parser = parser;
        }

        public Day22A() : this(new ParserType("Day22\\day22.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
