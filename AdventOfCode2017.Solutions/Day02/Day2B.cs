namespace AdventOfCode2017.Solutions.Day2
{
    using System.Linq;
    using ParserType = MultiLineStringParser;

    internal class Day2B : IProblem
    {
        private readonly ParserType _parser;

        public Day2B(ParserType parser) { _parser = parser; }

        public Day2B() : this(new ParserType("Day02\\day2.in")) { }

        public virtual string Solve()
        {
            var total = 0;

            foreach (var line in _parser.Parse())
            {
                var numbers = line.ParseDelimitedInts('\t')
                    .OrderByDescending(i => i)
                    .ToArray();

                for(int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if(numbers[i] % numbers[j] == 0)
                        {
                            total += numbers[i] / numbers[j];
                        }
                    }
                }
            }

            return total.ToString();
        }
    }
}
