namespace AdventOfCode2017.Solutions.Day5
{
    using ParserType = SingleLineStringParser;

    internal class Day5A : IProblem
    {
        private readonly ParserType _parser;

        public Day5A(ParserType parser)
        {
            _parser = parser;
        }

        public Day5A() : this(new ParserType("Day05\\day5.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
