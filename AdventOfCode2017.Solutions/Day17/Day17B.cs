namespace AdventOfCode2017.Solutions.Day17
{
    internal class Day17B : Day17A
    {
        private const int Spins = 50000000;

        public override string Solve()
        {
            var spin = int.Parse(Parser.GetData());
            var head = new Node<int>(0);
            head.Next = head;
            var current = head;
            for (var i = 1; i <= Spins; i++)
            {
                for (var spinCount = 0; spinCount < spin; spinCount++)
                    current = current.Next;

                current.Next = new Node<int>(i, current.Next);
                current = current.Next;
            }
            return head.Next.Value.ToString();
        }
    }
}
