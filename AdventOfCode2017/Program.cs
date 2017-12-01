using System;
using AdventOfCode2017.Solutions;

namespace AdventOfCode2017
{
    
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(
                ProblemFactory.Create(ProblemId.Day1B)
                .SendToClipboard()
                .AppendTime()
                .Solve());

            Console.ReadKey();
        }
    }
}
