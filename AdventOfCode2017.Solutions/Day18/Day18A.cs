using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day18
{
    using ParserType = MultiLineStringParser;

    internal class Day18A : IProblem
    {
        protected readonly ParserType Parser;

        public Day18A(ParserType parser) { Parser = parser; }

        public Day18A() : this(new ParserType("Day18\\day18.in")) { }

        public virtual string Solve()
        {
            var computer = new Computer(Parser.GetData().ToArray());
            computer.Run();
            return computer.LastRecovered.ToString();
        }
    }
}
