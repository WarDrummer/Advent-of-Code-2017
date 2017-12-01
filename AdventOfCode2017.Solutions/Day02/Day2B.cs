namespace AdventOfCode2017.Solutions.Day2
{
    using ParserType = SingleLineStringParser;

    internal class Day2B : IProblem
    {
        private readonly ParserType _parser;

        public Day2B(ParserType parser)
        {
            _parser = parser;
        }

        public Day2B() : this(new ParserType("Day02\\day2.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
