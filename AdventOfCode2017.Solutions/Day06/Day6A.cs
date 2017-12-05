namespace AdventOfCode2017.Solutions.Day06
{
    using ParserType = SingleLineStringParser;

    internal class Day6A : IProblem
    {
        private readonly ParserType _parser;

        public Day6A(ParserType parser)
        {
            _parser = parser;
        }

        public Day6A() : this(new ParserType("Day06\\day6.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
