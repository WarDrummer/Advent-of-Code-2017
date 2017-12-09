using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day09
{
    using ParserType = SingleLineStringParser;

    internal class Day9A : IProblem
    {
        private readonly ParserType _parser;

        public Day9A(ParserType parser) { _parser = parser; }

        public Day9A() : this(new ParserType("Day09\\day9.in")) { }

        public virtual string Solve()
        {
            var stream = _parser.GetData();

            var depth = 0;
            var garbage = false;
            var score = 0;
            for (var index = 0; index < stream.Length; index++)
            {
                var c = stream[index];
                if (c == '!')
                {
                    index++;
                    continue;
                }

                if (!garbage)
                {
                    switch (c)
                    {
                        case '{':
                            depth++;
                            break;
                        case '}':
                            score += depth;
                            depth--;
                            break;
                        case '<':
                            garbage = true;
                            break;
                    }
                }
                else if (c == '>')
                    garbage = false;
            }
            return score.ToString();
        }
    }
}
