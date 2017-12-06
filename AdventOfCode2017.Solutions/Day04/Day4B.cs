using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day04
{
    using ParserType = MultiLineStringParser;

    internal class Day4B : IProblem
    {
        private readonly ParserType _parser;

        public Day4B(ParserType parser) { _parser = parser; }

        public Day4B() : this(new ParserType("Day04\\day4.in")) { }

        public virtual string Solve()
        {
            var phrases = _parser.GetData().ToArray();
            var count = 0;

            foreach (var phrase in phrases)
                if(!ContainsAnagrams(phrase))
                    count++;

            return count.ToString();
        }

        private static bool ContainsAnagrams(string phrase)
        {
            var set = new HashSet<string>();
            var words = phrase.SplitAndRemoveEmpty();

            foreach (var word in words)
            {
                var chars = word.ToCharArray();
                Array.Sort(chars);
                var anagramHash = new string(chars);

                if (set.Contains(anagramHash))
                    return true;
                set.Add(anagramHash);
            }

            return false;
        }
    }
}