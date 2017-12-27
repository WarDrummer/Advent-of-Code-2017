using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day25
{
    internal class Day25A : IProblem
    {
        public virtual string Solve()
        {
            var machine = new Machine(new StateA());
            for (var i = 0; i < 12481997; i++)
                machine.Step();
            return machine.Checksum.ToString();
        }
    }
}