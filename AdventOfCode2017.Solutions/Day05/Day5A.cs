namespace AdventOfCode2017.Solutions.Day05
{
    using System.Linq;
    using ParserType = MultiLineStringParser;

    internal class Day5A : IProblem
    {
        private readonly ParserType _parser;

        public Day5A(ParserType parser) { _parser = parser; }

        public Day5A() : this(new ParserType("Day05\\day5.in")) { }

        public virtual string Solve()
        {
            var input = _parser.Parse().Select(int.Parse).ToArray();

            var nextInstruction = 0;
            var steps = 0;
            while (nextInstruction < input.Length)
            {
                var offset = input[nextInstruction];
                input[nextInstruction]++;
                nextInstruction += offset;
                steps++;
            }

            return steps.ToString();
        }
    }
}
