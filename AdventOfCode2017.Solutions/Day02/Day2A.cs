namespace AdventOfCode2017.Solutions.Day2
{
    using ParserType = SingleLineStringParser;

    internal class Day2A : IProblem
    {
        private readonly ParserType _parser;

        public Day2A(ParserType parser)
        {
            _parser = parser;
        }

        public Day2A() : this(new ParserType("Day02\\day2.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
