using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day04
{
    using ParserType = MultiLineStringParser;

    internal class Day4A : IProblem
    {
        private readonly ParserType _parser;

        public Day4A(ParserType parser) { _parser = parser; }

        public Day4A() : this(new ParserType("Day04\\day4.in")) { }

        public virtual string Solve()
        {
            var phrases = _parser.GetData().ToArray();
            var count = 0;

            foreach(var phrase in phrases)
                if(!ContainsDuplicateWords(phrase))
                    count++;

            return count.ToString();
        }

        private static bool ContainsDuplicateWords(string phrase)
        {
            var set = new HashSet<string>();
            var words = phrase.SplitAndRemoveEmpty();

            foreach (var word in words)
            {
                if (set.Contains(word))
                    return true;
                set.Add(word);
            }

            return false;
        }
    }
}
