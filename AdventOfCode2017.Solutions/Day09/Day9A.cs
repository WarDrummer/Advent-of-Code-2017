namespace AdventOfCode2017.Solutions.Day09
{
    using ParserType = SingleLineStringParser;

    internal class Day9A : IProblem
    {
        private readonly ParserType _parser;

        public Day9A(ParserType parser)
        {
            _parser = parser;
        }

        public Day9A() : this(new ParserType("Day09\\day9.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
