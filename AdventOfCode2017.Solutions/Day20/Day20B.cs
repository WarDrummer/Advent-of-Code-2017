using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day20
{
    internal class Day20B : Day20A
    {
        public override string Solve()
        {
            var particles = Parser.GetData().Select(Particle.FromString).ToList();
            var countMatch = 0;
            var lastCount = 0;
            while (countMatch < 10)
            {
                var locationsEncountered = new Dictionary<string, int>();
                for (var index = 0; index < particles.Count; index++)
                {
                    particles[index].Tick();
                    var locationHash = particles[index].ToString();
                    if (!locationsEncountered.ContainsKey(locationHash))
                        locationsEncountered.Add(locationHash, 0);
                    locationsEncountered[locationHash]++;
                }

                particles = particles
                    .Where(p => locationsEncountered[p.ToString()] == 1).ToList();

                if (lastCount == particles.Count)
                    countMatch++;
                else
                {
                    countMatch = 0;
                    lastCount = particles.Count;
                }
            }

            return particles.Count.ToString();
        }
    }
}
