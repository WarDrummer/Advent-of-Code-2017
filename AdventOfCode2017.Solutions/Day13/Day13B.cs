using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day13
{
    internal class Day13B : Day13A
    {
        public override string Solve()
        {
            var input = Parser.GetData();
            var scannerRanges = new Dictionary<int, int>();
  
            foreach (var depth in input)
            {
                var parts = depth
                    .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                // back to starting location is (range - 1) * 2
                scannerRanges.Add(parts[0], (parts[1]-1)*2);
            }

            var delay = 0;
            while (true)
            {
                var caught = false;
                foreach (var layer in scannerRanges.Keys)
                {
                    if ((layer + delay) % scannerRanges[layer] == 0)
                    {
                        caught = true;
                        break;
                    }
                }

                if (!caught)
                    return delay.ToString();
                delay++;
            }
        }

        

        private string SimulateForAnswer(int max, Dictionary<int, int> scannerRanges)
        {
            var delay = 0;
            var caught = true;

            var backup = new int[max + 1];
            for (var index = 0; index < backup.Length; index++)
            {
                if (scannerRanges.ContainsKey(index))
                    continue;

                backup[index] = -1;
            }

            var scannerLocationsArray = new int[max + 1];
            while (caught)
            {
                delay++;
                Array.Copy(backup, scannerLocationsArray, backup.Length);
                AdvanceScanners(scannerLocationsArray, scannerRanges);
                Array.Copy(scannerLocationsArray, backup, backup.Length);
                caught = WasCaught(scannerLocationsArray, scannerRanges);
            }

            return delay.ToString();
        }

        private bool WasCaught(IList<int> scannerLocations, Dictionary<int, int> scannerRanges)
        {
            var caught = false;
            for (var index = 0; index < scannerLocations.Count; index++)
            {
                if (scannerLocations[index] == 0)
                {
                    caught = true;
                    break;
                }
                AdvanceScanners(scannerLocations, scannerRanges);
            }
            return caught;
        }
    }
}
