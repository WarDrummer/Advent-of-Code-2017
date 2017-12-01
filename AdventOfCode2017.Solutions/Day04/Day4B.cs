namespace AdventOfCode2017.Solutions.Day4
{
    using ParserType = SingleLineStringParser;

    internal class Day4B : IProblem
    {
        private readonly ParserType _parser;

        public Day4B(ParserType parser)
        {
            _parser = parser;
        }

        public Day4B() : this(new ParserType("Day04\\day4.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}