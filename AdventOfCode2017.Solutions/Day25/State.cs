using System.Collections.Generic;

namespace AdventOfCode2017.Solutions.Day25
{
    public abstract class State
    {
        protected static readonly Dictionary<string, State> Lookup;
        static State()
        {
            Lookup = new Dictionary<string, State>
            {
                { "A", new StateA()},
                { "B", new StateB()},
                { "C", new StateC()},
                { "D", new StateD()},
                { "E", new StateE()},
                { "F", new StateF()},
            };
        }

        public abstract void Update(Machine machine);
    }
}