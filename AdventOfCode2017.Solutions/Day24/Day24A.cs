using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day24
{
    using ParserType = MultiLineStringParser;

    public struct Component
    {
        public List<int> PinCounts { get; set; }

        public int Strength { get; }
        public int Id { get; }

        private static int _idGen;

        public Component(IEnumerable<int> pinCounts)
        {
            PinCounts = pinCounts.ToList();
            Strength = PinCounts[0] + PinCounts[1];
            Id = _idGen++;
        }

        public override string ToString()
        {
            return $"{PinCounts[0]}/{PinCounts[1]}";
        }
    }

    internal class Day24A : IProblem
    {
        protected readonly ParserType Parser;

        public Day24A(ParserType parser) { Parser = parser; }

        public Day24A() : this(new ParserType("Day24\\day24.in")) { }

        public virtual string Solve()
        {
            var components = GetComponents();
            var max = 0;

            foreach (var component in components)
            {
                if(!component.PinCounts.Contains(0))
                    continue;

                var nextPinCount = GetNextPinCount(0, component);
                var strength = component.Strength;
                var unused = ComponentsWithout(components, component.Id);

                foreach (var str in GetStrengths(unused, nextPinCount, strength))
                    if (str > max)
                        max = str;
            }

            return max.ToString();
        }

        private IEnumerable<int> GetStrengths(List<Component> components, int pinCountToMatch, int strength)
        {
            var matchingComponents = components.Where(c => c.PinCounts.Contains(pinCountToMatch)).ToArray();
            if (matchingComponents.Length == 0)
            {
                yield return strength;
            }
            else
            {
                foreach (var matchingComponent in matchingComponents)
                {
                    var unused = ComponentsWithout(components, matchingComponent.Id);
                    var nextPinCount = GetNextPinCount(pinCountToMatch, matchingComponent);
                    foreach (var str in GetStrengths(unused, nextPinCount, strength + matchingComponent.Strength))
                        yield return str;
                }
            }
        }

        protected static int GetNextPinCount(int pinCountToMatch, Component component)
        {
            var unusedPinCount = new List<int>(component.PinCounts.ToArray());
            unusedPinCount.Remove(pinCountToMatch);
            return unusedPinCount[0];
        }

        protected List<Component> ComponentsWithout(List<Component> components, int componentId)
        {
            var reduced = new List<Component>(components.ToArray());
            reduced.RemoveAll(x => x.Id == componentId);
            return reduced;
        }

        protected List<Component> GetComponents()
        {
            return Parser.GetData()
                .Select(s => s.Split('/').Select(int.Parse).ToArray()).ToArray()
                .Select(pins => new Component(pins)).ToList();
        }
    }
}
