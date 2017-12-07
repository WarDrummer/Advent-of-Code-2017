using System;

namespace AdventOfCode2017.Solutions.Extensions
{
    public static class StringExtensions
    {
        public static int[] ParseDelimitedInts(this string line, params char[] delimiters)
        {
            return Array.ConvertAll(
                line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries), 
                int.Parse);
        }

        public static string[] SplitAndRemoveEmpty(this string line)
        {
            return line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
