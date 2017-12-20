using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day20
{
    using ParserType = MultiLineStringParser;

    internal class Day20A : IProblem
    {
        protected readonly ParserType Parser;

        public Day20A(ParserType parser){ Parser = parser; }

        public Day20A() : this(new ParserType("Day20\\day20.in")) { }

        public virtual string Solve()
        {
            var particles = Parser.GetData().Select(Particle.FromString).ToArray();
            const int numberOfTicks = 1000;
            var startPosition = new Vector3(0,0,0);
            var closest = 0;
            var minDistance = int.MaxValue;
            for (var pIndex = 0; pIndex < particles.Length; pIndex++)
            {
                particles[pIndex].Advance(numberOfTicks);
                var distance = startPosition.GetDistanceTo(particles[pIndex].Position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = pIndex;
                }
            }

            return closest.ToString();
        }
    }
}
