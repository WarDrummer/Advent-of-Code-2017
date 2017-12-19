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

            while (!(computer0.Waiting && computer1.Waiting))
            {
                computer1.ExecuteCycle();
                //Console.WriteLine(computer0.GetInstruction());
                //computer0.Run();
                computer0.ExecuteCycle();
                //Console.WriteLine(computer0.GetState());

                //Console.WriteLine(computer1.GetInstruction());
                //computer1.Run();
                //computer1.ExecuteCycle();
                //Console.WriteLine(computer1.GetState());
            }

            // 133 too low
            return computer1.SendCount.ToString();
        }
    }
}
