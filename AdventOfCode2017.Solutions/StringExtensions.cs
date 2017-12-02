namespace AdventOfCode2017.Solutions
{
    using System;

    public static class StringExtensions
    {
        public static int[] ParseTabDelimitedInts(this string line)
        {
            return Array.ConvertAll(line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
