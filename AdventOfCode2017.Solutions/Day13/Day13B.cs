namespace AdventOfCode2017.Solutions.Day13
{
    using ParserType = SingleLineStringParser;

    internal class Day13B : IProblem
    {
        private readonly ParserType _parser;

        public Day13B(ParserType parser)
        {
            _parser = parser;
        }

        public Day13B() : this(new ParserType("Day13\\day13.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
