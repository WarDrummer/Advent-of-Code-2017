namespace AdventOfCode2017.Solutions.Day25
{
    public class StateA : State
    {
        public override void Update(Machine machine)
        {
            //In state A:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state B.
            //  If the current value is 1:
            //    - Write the value 0.
            //    - Move one slot to the left.
            //    - Continue with state C.
            if (!machine.Value)
            {
                machine.Value = true;
                machine.MoveRight();
                machine.State = Lookup["B"];
            }
            else
            {
                machine.Value = false;
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