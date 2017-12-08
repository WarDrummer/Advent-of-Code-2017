using System.Linq;

namespace AdventOfCode2017.Solutions.Day08
{
    internal class Day8B : Day8A
    {
        public override string Solve()
        {
            var totalMax = 0;
            foreach (var line in _parser.GetData().ToArray())
            {
                var parts = line.Split(' ');

                var commandRegister = parts[0];
                var command = parts[1];
                var commandValue = int.Parse(parts[2]);
                var evalRegister = parts[4];
                var evalOperator = parts[5];
                var evalValue = int.Parse(parts[6]);

                if (!Registers.ContainsKey(commandRegister))
                    Registers[commandRegister] = 0;

                if (!Registers.ContainsKey(evalRegister))
                    Registers[evalRegister] = 0;

                if (EvaluateCondition(evalRegister, evalOperator, evalValue))
                {
                    UpdateRegister(commandRegister, command, commandValue);
                    if (Registers[commandRegister] > totalMax)
                        totalMax = Registers[commandRegister];
                }
            }

            return totalMax.ToString();
        }
    }
}
