namespace AdventOfCode2017.Solutions.Day18
{
    using ParserType = SingleLineStringParser;

    internal class Day18B : IProblem
    {
        private readonly ParserType _parser;

        public Day18B(ParserType parser)
        {
            _parser = parser;
        }

        public Day18B() : this(new ParserType("Day18\\day18.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
