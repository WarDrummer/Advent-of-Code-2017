namespace AdventOfCode2017.Solutions.Day08
{
    using ParserType = SingleLineStringParser;

    internal class Day8A : IProblem
    {
        private readonly ParserType _parser;

        public Day8A(ParserType parser)
        {
            _parser = parser;
        }

        public Day8A() : this(new ParserType("Day08\\day8.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
