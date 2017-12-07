using System;
using System.Collections.Generic;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day07
{
    using ParserType = MultiLineStringParser;

    internal class Day7A : IProblem
    {
        private readonly ParserType _parser;

        public Day7A(ParserType parser) { _parser = parser; }

        public Day7A() : this(new ParserType("Day07\\day7.in")) { }

        public virtual string Solve()
        {
            var lines = _parser.GetData();
            var mapping = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var parts = line.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = parts[0];
                //var weight = parts[1].Remove(0).Remove(parts[1].Length - 1);
                if (parts.Length > 2)
                {
                    for (var i = 3; i < parts.Length; i++)
                    {
                        var discAbove = parts[i];
                        if (discAbove.EndsWith(","))
                            discAbove = discAbove.Remove(discAbove.Length - 1);
                        mapping.Add(discAbove, name);
                    }
                }
            }

            foreach (var holder in mapping.Values)
            {
                if (!mapping.ContainsKey(holder))
                    return holder;
            }
            return "nope";
        }
    }
}
