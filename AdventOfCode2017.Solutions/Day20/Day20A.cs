namespace AdventOfCode2017.Solutions.Day20
{
    using ParserType = SingleLineStringParser;

    internal class Day20A : IProblem
    {
        private readonly ParserType _parser;

        public Day20A(ParserType parser)
        {
            _parser = parser;
        }

        public Day20A() : this(new ParserType("Day20\\day20.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
