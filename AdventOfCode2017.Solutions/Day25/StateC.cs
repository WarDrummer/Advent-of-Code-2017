namespace AdventOfCode2017.Solutions.Day25
{
    public class StateC : State
    {
        public override void Update(Machine machine)
        {
            //In state C:
            //  If the current value is 0:
            //    - Write the value 0.
            //    - Move one slot to the left.
            //    - Continue with state B.
            //  If the current value is 1:
            //    - Write the value 0.
            //    - Move one slot to the left.
            //    - Continue with state E.
            if (!machine.Value)
            {
                machine.Value = false;
                machine.MoveLeft();
                machine.State = Lookup["B"];
            }
            else
            {
                machine.Value = false;
                machine.MoveLeft();
                machine.State = Lookup["E"];
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}