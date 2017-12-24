using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day24
{
    internal class Day24B : Day24A
    {
        public override string Solve()
        {
            var components = GetComponents();
            var maxLength = 0;
            var maxStrength = 0;

            foreach (var component in components)
            {
                if (!component.PinCounts.Contains(0))
                    continue;

                var nextPinCount = GetNextPinCount(0, component);
                var strength = component.Strength;
                var unused = ComponentsWithout(components, component.Id);

                foreach (var result in GetStrengths(unused, nextPinCount, strength, 1))
                {
                    if (result.Item2 > maxLength)
                    {
                        maxLength = result.Item2;
                        maxStrength = result.Item1;
                    }
                    else if (result.Item2 == maxLength)
                    {
                        if (result.Item1 > maxStrength)
                            maxStrength = result.Item1;
                    }
                }
            }

            return maxStrength.ToString();
        }


        protected IEnumerable<Tuple<int, int>> GetStrengths(List<Component> components, int pinCountToMatch, int strength, int length)
        {
            var matchingComponents = components.Where(c => c.PinCounts.Contains(pinCountToMatch)).ToArray();
            if (matchingComponents.Length == 0)
                yield return new Tuple<int, int>(strength, length);
            else
            {
                foreach (var matchingComponent in matchingComponents)
                {
                    var unused = ComponentsWithout(components, matchingComponent.Id);
                    var nextPinCount = GetNextPinCount(pinCountToMatch, matchingComponent);
                    foreach (var result in GetStrengths(unused, nextPinCount, strength + matchingComponent.Strength, length + 1))
                        yield return result;
                }
            }
        }
    }
}
