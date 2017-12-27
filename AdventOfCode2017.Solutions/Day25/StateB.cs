namespace AdventOfCode2017.Solutions.Day25
{
    public class StateB : State
    {
        public override void Update(Machine machine)
        {
            //In state B:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the left.
            //    - Continue with state A.
            //  If the current value is 1:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state D.
            if (!machine.Value)
            {
                machine.Value = true;
                machine.MoveLeft();
                machine.State = Lookup["A"];
            }
            else
            {
                machine.Value = true;
                machine.MoveRight();
                machine.State = Lookup["D"];
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}