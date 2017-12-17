using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day17
{
    using ParserType = SingleLineStringParser;

    internal class Day17A : IProblem
    {
        protected readonly ParserType Parser;

        public Day17A(ParserType parser) { Parser = parser; }

        public Day17A() : this(new ParserType("Day17\\day17.in")) { }

        private const int Spins = 2017;

        public virtual string Solve()
        {
            var spin = int.Parse(Parser.GetData());
            var current = new Node<int>(0);
            current.Next = current;
            for (var i = 1; i <= Spins; i++)
            {
                for (var spinCount = 0; spinCount < spin; spinCount++)
                    current = current.Next;

                current.Next = new Node<int>(i, current.Next);
                current = current.Next;
            }
            return current.Next.Value.ToString();
        }
    }
}
