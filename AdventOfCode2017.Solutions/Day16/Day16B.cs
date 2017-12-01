namespace AdventOfCode2017.Solutions.Day16
{
    using ParserType = SingleLineStringParser;

    internal class Day16B : IProblem
    {
        private readonly ParserType _parser;

        public Day16B(ParserType parser)
        {
            _parser = parser;
        }

        public Day16B() : this(new ParserType("Day16\\day16.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
