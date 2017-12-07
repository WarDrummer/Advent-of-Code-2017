using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day07
{
    using ParserType = MultiLineStringParser;

    public struct Disc
    {
        public string Name { get; }
        public int Weight { get; }

        public Disc(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
    internal class Day7B : IProblem
    {
        private readonly ParserType _parser;

        public Day7B(ParserType parser) { _parser = parser; }

        public Day7B() : this(new ParserType("Day07\\day7.in")) { }

        public virtual string Solve()
        {
            var lines = _parser.GetData();
            var mapping = new Dictionary<string, List<string>>();
            var discWeights = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var discHolding = parts[0];
                var weightPart = parts[1].Remove(parts[1].Length - 1, 1).Remove(0, 1);
                var weight = int.Parse(weightPart);
                discWeights.Add(discHolding, weight);

                if (parts.Length > 2)
                {
                    for (var i = 3; i < parts.Length; i++)
                    {
                        var discBeingHeld = parts[i];
                        if (discBeingHeld.EndsWith(","))
                            discBeingHeld = discBeingHeld.Remove(discBeingHeld.Length - 1);

                        if (!mapping.ContainsKey(discHolding))
                        {
                            mapping[discHolding] = new List<string>();
                        }
                        mapping[discHolding].Add(discBeingHeld);
                    }
                }
            }

            var result = "";
            try
            {
                var top = "dgoocsw";

                GetWeight(top, mapping, discWeights);
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        private int GetWeight(string name, Dictionary<string, List<string>> mapping, Dictionary<string, int> weightMapping)
        {
            if (!mapping.ContainsKey(name))
                return weightMapping[name];

            var children = mapping[name];
            var totalWeight = new Dictionary<string, int>();
            foreach (var child in children)
            {
                var weight = GetWeight(child, mapping, weightMapping);
                totalWeight.Add(child, weight);
            }

            var uniqueWeights = totalWeight.Values.Distinct().ToArray();
            if (uniqueWeights.Length > 1)
            {
                var difference = Math.Abs(uniqueWeights[0] - uniqueWeights[1]);
                var oddValue = totalWeight.Values.Count(v => v == uniqueWeights[0]) == 1 
                        ? uniqueWeights[0] : uniqueWeights[1];

                var oddDisc = totalWeight
                    .Where(kvp => kvp.Value == oddValue)
                    .Select(kvp => kvp.Key).First();

                var shouldBe = weightMapping[oddDisc] - difference;
                throw new Exception(shouldBe.ToString());
            }

            return totalWeight.Sum(kvp => kvp.Value) + weightMapping[name];
        }
    }
}
