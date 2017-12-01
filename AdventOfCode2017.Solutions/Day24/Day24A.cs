namespace AdventOfCode2017.Solutions.Day24
{
    using ParserType = SingleLineStringParser;

    internal class Day24A : IProblem
    {
        private readonly ParserType _parser;

        public Day24A(ParserType parser)
        {
            _parser = parser;
        }

        public Day24A() : this(new ParserType("Day24\\day24.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
