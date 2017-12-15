using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day15
{ 
    internal class Day15B : Day15A
    {
        public override string Solve()
        {
            var startingNumbers = Parser.GetData().Select(l => long.Parse(l.Split(' ')[4])).ToArray();

            var a = startingNumbers[0];
            var b = startingNumbers[1];
            var count = 0;
            var q1 = new Queue<long>();
            var q2 = new Queue<long>();
            var numberJudged = 0;
            while (numberJudged < 5000000)
            {
                a = (a * FactorA) % Div;
                b = (b * FactorB) % Div;

                if (a % 4 == 0) q1.Enqueue(a);
                if (b % 8 == 0) q2.Enqueue(b);

                if (q1.Count > 0 && q2.Count > 0)
                {
                    numberJudged++;
                    if ((q1.Dequeue() & Mask) == (q2.Dequeue() & Mask))
                        count++;
                }
            }

            return count.ToString();
        } 
    }
}
