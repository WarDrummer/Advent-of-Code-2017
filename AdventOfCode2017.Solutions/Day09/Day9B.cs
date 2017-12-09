using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day09
{
    using ParserType = SingleLineStringParser;

    internal class Day9B : IProblem
    {
        private readonly ParserType _parser;

        public Day9B(ParserType parser) { _parser = parser; }

        public Day9B() : this(new ParserType("Day09\\day9.in")) { }

        public virtual string Solve()
        {
            var stream = _parser.GetData();

            var garbage = false;
            var garbageCount = 0;
            for (var index = 0; index < stream.Length; index++)
            {
                var c = stream[index];
                if (c == '!')
                {
                    index++;
                    continue;
                }

                if (garbage)
                {
                    if (c == '>')
                        garbage = false;
                    else
                        garbageCount++;
                }
                else if (c == '<')
                    garbage = true;

            }
            return garbageCount.ToString();
        }
    }
}
