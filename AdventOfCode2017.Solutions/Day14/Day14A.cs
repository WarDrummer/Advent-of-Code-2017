using System.Linq;
using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day14
{
    using ParserType = SingleLineStringParser;

    internal class Day14A : IProblem
    {
        protected readonly ParserType Parser;

        public Day14A(ParserType parser) { Parser = parser; }

        public Day14A() : this(new ParserType("Day14\\day14.in")){ }

        public virtual string Solve()
        {
            var input = Parser.GetData();
            var count = 0;
            for (var i = 0; i < 128; i++)
            {
                var hash = KnotHasher.ComputeKnotHash($"{input}-{i}");
                var binary = hash.FromHexStringToBinaryString();
                count += binary.Count(b => b == '1');
            }

            return count.ToString();
        }
    }
}
