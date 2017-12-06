namespace AdventOfCode2017.Solutions.Day06
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Day6B : Day6A
    {
        public override string Solve()
        {
            var banks = FileParser.GetData().ParseDelimitedInts('\t').ToArray();
            var seen = new HashSet<int>();

            var key = banks.CreateHash();
            while (!seen.Contains(key))
            {
                seen.Add(key);
                key = GetNextHash(banks);
            }

            var count = 0;
            var nextHash = 0;

            while (nextHash != key)
            {
                seen.Add(nextHash);
                nextHash = GetNextHash(banks);
                count++;
            }

            return count.ToString();
        }
    }
}
