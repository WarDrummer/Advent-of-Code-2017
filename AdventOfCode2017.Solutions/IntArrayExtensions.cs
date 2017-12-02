using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Solutions
{
    public static class IntArrayExtensions
    {
        public static void MinMax(this int[] numbers, out int min, out int max)
        {
            max = int.MinValue;
            min = int.MaxValue;

            foreach (var i in numbers)
            {
                if (i < min) min = i;
                if (i > max) max = i;
            }
        }
    }
}
