namespace AdventOfCode2017.Solutions.Day3
{
    using ParserType = SingleLineStringParser;

    internal class Day3B : IProblem
    {
        private readonly ParserType _parser;

        public Day3B(ParserType parser)
        {
            _parser = parser;
        }

        public Day3B() : this(new ParserType("Day03\\day3.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
