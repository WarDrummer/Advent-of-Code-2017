namespace AdventOfCode2017.Solutions.Day17
{
    using ParserType = SingleLineStringParser;

    internal class Day17A : IProblem
    {
        private readonly ParserType _parser;

        public Day17A(ParserType parser)
        {
            _parser = parser;
        }

        public Day17A() : this(new ParserType("Day17\\day17.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
