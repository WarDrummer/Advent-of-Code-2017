namespace AdventOfCode2017
{
    using System;
    using AdventOfCode2017.Solutions;

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(
                ProblemFactory.Create(ProblemId.Day4A)
                .SendToClipboard()
                .AppendTime()
                .Solve());

            Console.ReadKey();
        }
    }
}
