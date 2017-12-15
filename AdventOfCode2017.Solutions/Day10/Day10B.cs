namespace AdventOfCode2017.Solutions.Day10
{
    internal class Day10B : Day10A
    {
        public override string Solve()
        {
            var data = Parser.GetData();
            return KnotHasher.ComputeKnotHash(data);
        }
    }
}
