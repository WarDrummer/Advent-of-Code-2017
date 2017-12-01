namespace AdventOfCode2017.Solutions.Day10
{
    using ParserType = SingleLineStringParser;

    internal class Day10B : IProblem
    {
        private readonly ParserType _parser;

        public Day10B(ParserType parser)
        {
            _parser = parser;
        }

        public Day10B() : this(new ParserType("Day10\\day10.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
