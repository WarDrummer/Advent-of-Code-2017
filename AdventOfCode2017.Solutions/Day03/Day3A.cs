namespace AdventOfCode2017.Solutions.Day3
{
    using ParserType = SingleLineStringParser;

    internal class Day3A : IProblem
    {
        private readonly ParserType _parser;

        public Day3A(ParserType parser)
        {
            _parser = parser;
        }

        public Day3A() : this(new ParserType("Day03\\day3.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
