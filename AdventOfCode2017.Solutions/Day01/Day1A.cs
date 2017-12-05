namespace AdventOfCode2017.Solutions.Day01
{
    using ParserType = SingleLineStringParser;

    internal class Day1A : IProblem
    {
        private readonly ParserType _parser;

        public Day1A() : this(new ParserType("Day01\\day1.in")) { }

        private Day1A(ParserType parser) { _parser = parser; }

        public string Solve()
        {
            var input = _parser.Parse().Trim();

            var sum = 0;
            for(var i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                    sum += input[i] - '0';
            }

            if (input[0] == input[input.Length - 1])
                sum += input[0] - '0';

            return sum.ToString();
        }
    }
}
