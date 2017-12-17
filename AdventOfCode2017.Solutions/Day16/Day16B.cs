using System.Collections.Generic;

namespace AdventOfCode2017.Solutions.Day16
{
	internal class Day16B : Day16A
    {
        public override string Solve()
        {
            var moves = Parser.GetData().Split(',');
            DanceMoves = GetDanceMoves(moves, Programs);
            var found = new Dictionary<int, string>();
            var count = 0;

            while(true)
            {
                PerformDance();
                var current = new string(Programs);
                if (!found.ContainsValue(current))
                    found.Add(++count, current);
                else
                    break;
            }

            return found[1000000000 % count];
        }
    }
}
