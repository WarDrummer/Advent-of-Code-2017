using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day23
{
    using ParserType = MultiLineStringParser;

    internal class Day23A : IProblem
    {
        protected readonly ParserType Parser;

        public Day23A(ParserType parser) { Parser = parser; }

        public Day23A() : this(new ParserType("Day23\\day23.in")) { }

        public virtual string Solve()
        {
            var computer = new Computer(Parser.GetData().ToArray());
            computer.Run();
            return computer.MultiplyCount.ToString();
        }
    }
}
