namespace AdventOfCode2017.Solutions
{
    public static class ArrayExtensions
    {
        public static int CreateHash(this int[] ints)
        {
            var hash = ints.Length;
            foreach (var bank in ints)
                hash = unchecked(hash * 314159 + bank);
            return hash;
        }
    }
}
