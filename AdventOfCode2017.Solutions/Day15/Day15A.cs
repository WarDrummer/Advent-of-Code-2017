using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day15
{
    using ParserType = MultiLineStringParser;

    internal class Day15A : IProblem
    {
        protected readonly ParserType Parser;

        public Day15A(ParserType parser) { Parser = parser; }

        public Day15A() : this(new ParserType("Day15\\day15.in")) { }

        protected const long Div = 2147483647;
        protected const long FactorA = 16807;
        protected const long FactorB = 48271;

        protected const long Mask = 0xffff;

        public virtual string Solve()
        {
            var startingNumbers = Parser.GetData().Select(l => long.Parse(l.Split(' ')[4])).ToArray();

            var a = startingNumbers[0];
            var b = startingNumbers[1];
            var count = 0;
            for (var i = 0; i < 40000000; i++)
            {
                a = (a * FactorA) % Div;
                b = (b * FactorB) % Div;
                if ((a & Mask) == (b & Mask))
                    count++;
            }

            return count.ToString();
        }
    }
}
