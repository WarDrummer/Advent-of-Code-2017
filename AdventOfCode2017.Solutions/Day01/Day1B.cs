namespace AdventOfCode2017.Solutions.Day01
{
    using ParserType = SingleLineStringParser;

    internal class Day1B : IProblem
    {
        private readonly ParserType _parser;

        public Day1B() : this(new ParserType("Day01\\day1.in")) { }

        private Day1B(ParserType parser) { _parser = parser; }

        public string Solve()
        {
            var input = _parser.GetData().Trim();

            var sum = 0;
            var offset = input.Length / 2;
            for (var i = 0; i < input.Length; i++)
            {
                var opposite = (i + offset) % input.Length;
                if (input[i] == input[opposite])
                    sum += input[i] - '0';
            }
            
            return sum.ToString();
        }
    }
}
