namespace AdventOfCode2017.Solutions.Day9
{
    using ParserType = SingleLineStringParser;

    internal class Day9B : IProblem
    {
        private readonly ParserType _parser;

        public Day9B(ParserType parser)
        {
            _parser = parser;
        }

        public Day9B() : this(new ParserType("Day09\\day9.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
