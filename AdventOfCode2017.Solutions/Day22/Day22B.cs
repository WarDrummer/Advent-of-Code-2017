namespace AdventOfCode2017.Solutions.Day22
{
    using ParserType = SingleLineStringParser;

    internal class Day22B : IProblem
    {
        private readonly ParserType _parser;

        public Day22B(ParserType parser)
        {
            _parser = parser;
        }

        public Day22B() : this(new ParserType("Day22\\day22.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
