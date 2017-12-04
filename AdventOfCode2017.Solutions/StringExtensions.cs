namespace AdventOfCode2017.Solutions
{
    using System;

    public static class StringExtensions
    {
        public static int[] ParseDelimitedInts(this string line, params char[] delimiters)
        {
            return Array.ConvertAll(
                line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries), 
                int.Parse);
        }
    }
}
