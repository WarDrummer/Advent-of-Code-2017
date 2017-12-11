using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day11
{
    using ParserType = SingleLineStringParser;

    internal class Day11A : IProblem
    {
        protected readonly ParserType _parser;

        public Day11A(ParserType parser) { _parser = parser; }

        public Day11A() : this(new ParserType("Day11\\day11.in")) { }


        public virtual string Solve()
        {
            var directions = _parser.GetData().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var x = 0;
            var y = 0;

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "n": x++; break;
                    case "nw": x++; y--;  break;
                    case "ne": y++;  break;
                    case "s": x--; break;
                    case "sw": y--;  break;
                    case "se": x--; y++; break;
                }
            }

            return new BreadthFirstSearch<int>(new AxialHexNode(x, y))
                .GetMinimumNumberOfMoves(new AxialHexNode(0, 0)).ToString();
        }
    }

    public class CubeHex
    {
        public CubeHex(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public int GetDistanceTo(CubeHex hex)
        {
            return Math.Max(
                        Math.Max(
                            Math.Abs(X - hex.X), Math.Abs(Y - hex.Y)),
                    Math.Abs(Z - hex.Z));
        }
    }
    public class AxialHexNode : IBfsNode<int>
    {
        public int X { get; }
        public int Y { get; }

        public AxialHexNode(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(IBfsNode<int> other)
        {
            if (other is AxialHexNode node)
                return (X == node.X && Y == node.Y) ? 0 : 1;
            return -1;
        }

        public IEnumerable<IBfsNode<int>> GetNextNodes()
        {
            yield return new AxialHexNode(X + 1, Y - 1); // NW
            yield return new AxialHexNode(X + 1, Y); // N
            yield return new AxialHexNode(X, Y + 1); // NE
            yield return new AxialHexNode(X - 1, Y + 1); // SE
            yield return new AxialHexNode(X - 1, Y); // S
            yield return new AxialHexNode(X, Y - 1); // SW
        }

        public int UniqueIdentifier => ToString().CreateHash();
        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public CubeHex ToCubeHex()
        {
            var x = X;
            var z = Y;
            var y = -x - z;
            return new CubeHex(x, y, z);
        }
    }
}
