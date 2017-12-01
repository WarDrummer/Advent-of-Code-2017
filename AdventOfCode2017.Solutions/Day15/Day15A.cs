namespace AdventOfCode2017.Solutions.Day15
{
    using ParserType = SingleLineStringParser;

    internal class Day15A : IProblem
    {
        private readonly ParserType _parser;

        public Day15A(ParserType parser)
        {
            _parser = parser;
        }

        public Day15A() : this(new ParserType("Day15\\day15.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
