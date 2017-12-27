namespace AdventOfCode2017.Solutions.Day25
{
    public class StateD : State
    {
        public override void Update(Machine machine)
        {
            //In state D:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state A.
            //  If the current value is 1:
            //    - Write the value 0.
            //    - Move one slot to the right.
            //    - Continue with state B.
            if (!machine.Value)
            {
                machine.Value = true;
                machine.MoveRight();
                machine.State = Lookup["A"];
            }
            else
            {
                machine.Value = false;
                machine.MoveRight();
                machine.State = Lookup["B"];
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}