namespace AdventOfCode2017.Solutions.Day08
{
    using ParserType = SingleLineStringParser;

    internal class Day8B : IProblem
    {
        private readonly ParserType _parser;

        public Day8B(ParserType parser)
        {
            _parser = parser;
        }

        public Day8B() : this(new ParserType("Day08\\day8.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
