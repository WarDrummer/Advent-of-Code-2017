using System;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day18
{
    internal class Day18B : Day18A
    {
        public override string Solve()
        {
            var instructions = Parser.GetData().ToArray();

            var computer0 = new ComputerV2(instructions,0);
            computer0.SetRegister("p", 0);

            var computer1 = new ComputerV2(instructions,1);
            computer1.SetRegister("p", 1);

            computer0.PairedComputer = computer1;
            computer1.PairedComputer = computer0;

            //while (!(computer0.Waiting && computer1.Waiting))
            //{

            //computer0.ExecuteCycle();
            //computer1.ExecuteCycle();

            //Console.WriteLine("============================\n");

            //Console.WriteLine(computer0.GetInstruction());
            //computer0.Run();
            //Console.WriteLine(computer0.GetState());

            //Console.WriteLine(computer1.GetInstruction());
            //computer1.Run();
            //Console.WriteLine(computer1.GetState());
            //}

            var computers = new[] {computer0, computer1};
            var id = 0;
            while (true)
            {
                computers[id].ExecuteCycle();
                if (computers[id].Terminate)
                    break;
                id = (id + 1) % 2;
            }

            //}
            //0
            //133
            //301
            //496
            //771
            //771

            // 301 too low
            return computer1.SendCount.ToString();
        }
    }
}
