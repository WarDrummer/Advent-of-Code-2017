namespace AdventOfCode2017.Solutions.Day20
{
    using ParserType = SingleLineStringParser;

    internal class Day20B : IProblem
    {
        private readonly ParserType _parser;

        public Day20B(ParserType parser)
        {
            _parser = parser;
        }

        public Day20B() : this(new ParserType("Day20\\day20.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
