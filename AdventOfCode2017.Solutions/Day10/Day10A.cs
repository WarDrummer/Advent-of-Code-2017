using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day10
{
    using ParserType = SingleLineStringParser;

    internal class Day10A : IProblem
    {
        protected readonly ParserType Parser;

        public Day10A(ParserType parser) { Parser = parser; }

        public Day10A() : this(new ParserType("Day10\\day10.in")) { }

        public virtual string Solve()
        {
            var lengths = Parser.GetData().ParseDelimitedInts(',').ToList();
            var skipSize = 0;
            var head = Enumerable.Range(0, 256).ToArray().BuildCircularList();
            var current = head;
            KnotHash(lengths, ref current, ref skipSize);
            return GetProduct(head).ToString();
        }

        protected static int GetProduct(Node<int> head)
        {
            var node = head;
            var multiplicand = node.Value;
            node = node.Next;
            var multiplier = node.Value;
            var result = multiplicand * multiplier;
            return result;
        }

        protected static void KnotHash(List<int> lengths, ref Node<int> node, ref int skipSize)
        {
            var stack = new Stack<int>();
            foreach (var length in lengths)
            {
                var current = node;

                for (var lengthCount = 0; lengthCount < length; lengthCount++)
                {
                    stack.Push(node.Value);
                    node = node.Next;
                }

                while (stack.Count > 0)
                {
                    current.Value = stack.Pop();
                    current = current.Next;
                }

                for (var advanceCount = 0; advanceCount < skipSize; advanceCount++)
                    node = node.Next;

                skipSize++;
            }
        }
    }
}
