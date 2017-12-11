namespace AdventOfCode2017
{
    using System;
    using Solutions.Extensions;
    using Solutions.Problem;

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(
                ProblemFactory.Create(ProblemId.Day11A)
                //ProblemFactory.Create(ProblemId.Day11B)
                .SendToClipboard()
                .AppendTime()
                .Solve());

            Console.ReadKey();
        }
    }
}
