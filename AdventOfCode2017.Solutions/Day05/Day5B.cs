using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day05
{
    using System.Linq;
    using ParserType = MultiLineStringParser;

    internal class Day5B : IProblem
    {
        private readonly ParserType _parser;

        public Day5B(ParserType parser) { _parser = parser; }

        public Day5B() : this(new ParserType("Day05\\day5.in")) { }

        public virtual string Solve()
        {
            var input = _parser.GetData().Select(int.Parse).ToArray();

            var nextInstruction = 0;
            var steps = 0;
            while (nextInstruction < input.Length)
            {
                var offset = input[nextInstruction];
                input[nextInstruction] += (input[nextInstruction] > 2) ? -1 : 1;
                nextInstruction += offset;
                steps++;
            }

            return steps.ToString();
        }
    }
}
