namespace AdventOfCode2017.Solutions.Day25
{
    using ParserType = SingleLineStringParser;

    internal class Day25A : IProblem
    {
        private readonly ParserType _parser;

        public Day25A(ParserType parser)
        {
            _parser = parser;
        }

        public Day25A() : this(new ParserType("Day25\\day25.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
