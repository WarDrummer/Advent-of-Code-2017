namespace AdventOfCode2017.Solutions.Day14
{
    using ParserType = SingleLineStringParser;

    internal class Day14A : IProblem
    {
        private readonly ParserType _parser;

        public Day14A(ParserType parser)
        {
            _parser = parser;
        }

        public Day14A() : this(new ParserType("Day14\\day14.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
