namespace AdventOfCode2017.Solutions.Day21
{
    using ParserType = SingleLineStringParser;

    internal class Day21A : IProblem
    {
        private readonly ParserType _parser;

        public Day21A(ParserType parser)
        {
            _parser = parser;
        }

        public Day21A() : this(new ParserType("Day21\\day21.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
