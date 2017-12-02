namespace AdventOfCode2017.Solutions.Day2
{
    using System;
    using System.Linq;
    using ParserType = MultiLineStringParser;

    internal class Day2A : IProblem
    {
        private readonly ParserType _parser;

        public Day2A(ParserType parser) { _parser = parser; }

        public Day2A() : this(new ParserType("Day02\\day2.in")) { }

        public virtual string Solve()
        {
            var total = 0;
            foreach(var line in _parser.Parse())
            {
                var numbers = line
                    .Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(y => int.Parse(y));

                int max = int.MinValue;
                int min = int.MaxValue;
                foreach(var i in numbers)
                {
                    if (i < min)
                        min = i;

                    if (i > max)
                        max = i;
                }
                total += max - min;
            }
            return total.ToString();
        }
    }
}
