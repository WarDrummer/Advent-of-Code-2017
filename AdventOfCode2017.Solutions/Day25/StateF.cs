namespace AdventOfCode2017.Solutions.Day25
{
    public class StateF : State
    {
        public override void Update(Machine machine)
        {
            //In state F:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state D.
            //  If the current value is 1:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state A.
            if (!machine.Value)
            {
                machine.Value = true;
                machine.MoveRight();
                machine.State = Lookup["D"];
            }
            else
            {
                machine.Value = true;
                machine.MoveRight();
                machine.State = Lookup["A"];
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}