using System;

namespace AdventOfCode2017.Solutions.Day11
{
    public class CubeHexCoordinate
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public CubeHexCoordinate(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int GetDistanceTo(CubeHexCoordinate hexCoordinate)
        {
            return Math.Max(
                Math.Max(
                    Math.Abs(X - hexCoordinate.X), Math.Abs(Y - hexCoordinate.Y)),
                Math.Abs(Z - hexCoordinate.Z));
        }
    }
}