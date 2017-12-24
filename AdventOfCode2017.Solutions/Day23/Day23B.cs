namespace AdventOfCode2017.Solutions.Day23
{
    internal class Day23B : Day23A
    {
        public override string Solve()
        {
            var c = 109300 + 17000;
            var h = 0;

            for(var b = 109300; b < c; b += 17)
            {
                var f = 1;
                var d = 2;

                do
                {
                    var e = 2;

                    do
                    {
                        if (d * e - b == 0)
                            f = 0;
                        e++;
                    } while (e - b != 0);

                    d++;

                } while (d - b != 0);

                if (f == 0)
                    h++;
            }

            return h.ToString();

            //var computer = new Computer(Parser.GetData().ToArray());
            //computer.SetRegister("a", 1);
            //computer.Run();
            //return computer.GetRegisterValue("h").ToString();
        }
    }
}
