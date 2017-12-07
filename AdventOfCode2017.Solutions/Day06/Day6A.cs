using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day06
{
    using System.Collections.Generic;
    using System.Linq;

    using ParserType = SingleLineStringParser;

    internal class Day6A : IProblem
    {
        protected readonly ParserType FileParser;

        public Day6A(ParserType fileParser) { FileParser = fileParser; }

        public Day6A() : this(new ParserType("Day06\\day6.in")) { }

        public virtual string Solve()
        {
            var banks = FileParser.GetData().ParseDelimitedInts('\t').ToArray();
            var seen = new HashSet<int>();

            var hash = banks.CreateHash();
            var count = 0;
            while (!seen.Contains(hash))
            {
                seen.Add(hash);
                hash = GetNextHash(banks);
                count++;
            }

            return count.ToString();
        }

        protected static int GetNextHash(int[] banks)
        {
            Redistribute(banks);
            return banks.CreateHash();
        }

        protected static void Redistribute(int[] banks)
        {
            var banksCount = banks.Length;
            var index = -1;
            var max = int.MinValue;
            for (var i = 0; i < banksCount; i++)
            {
                if (banks[i] > max)
                {
                    max = banks[i];
                    index = i;
                }
            }

            banks[index] = 0;
            for (var i = 0; i < max; i++)
            {
                banks[++index % banksCount]++;
            }
        }
    }
}
