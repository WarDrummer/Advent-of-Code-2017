namespace AdventOfCode2017.Solutions.Day23
{
    using ParserType = SingleLineStringParser;

    internal class Day23B : IProblem
    {
        private readonly ParserType _parser;

        public Day23B(ParserType parser)
        {
            _parser = parser;
        }

        public Day23B() : this(new ParserType("Day23\\day23.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
