namespace AdventOfCode2017.Solutions.Day6
{
    using ParserType = SingleLineStringParser;

    internal class Day6B : IProblem
    {
        private readonly ParserType _parser;

        public Day6B(ParserType parser)
        {
            _parser = parser;
        }

        public Day6B() : this(new ParserType("Day06\\day6.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
