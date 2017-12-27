namespace AdventOfCode2017.Solutions.Day25
{
    public class StateE : State
    {
        public override void Update(Machine machine)
        {
            //In state E:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the left.
            //    - Continue with state F.
            //  If the current value is 1:
            //    - Write the value 1.
            //    - Move one slot to the left.
            //    - Continue with state C.
            if (!machine.Value)
            {
                machine.Value = true;
                machine.MoveLeft();
                machine.State = Lookup["F"];
            }
            else
            {
                machine.Value = true;
                machine.MoveLeft();
                machine.State = Lookup["C"];
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}