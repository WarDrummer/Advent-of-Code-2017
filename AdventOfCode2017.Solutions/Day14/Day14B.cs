namespace AdventOfCode2017.Solutions.Day14
{
    using ParserType = SingleLineStringParser;

    internal class Day14B : IProblem
    {
        private readonly ParserType _parser;

        public Day14B(ParserType parser)
        {
            _parser = parser;
        }

        public Day14B() : this(new ParserType("Day14\\day14.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
