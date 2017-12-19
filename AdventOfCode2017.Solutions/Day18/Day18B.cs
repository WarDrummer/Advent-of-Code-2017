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

            var computers = new[] {computer0, computer1};
            var id = 0;
            while (!(computers[0].Terminate && computers[1].Terminate))
            {
                computers[id].ExecuteCycle();
                id = (id + 1) % 2;
            }

            return computer1.SendCount.ToString();
        }
    }
}
