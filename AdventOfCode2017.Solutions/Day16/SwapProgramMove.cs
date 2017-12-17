using System.Collections.Generic;

namespace AdventOfCode2017.Solutions.Day16
{
    public class SwapProgramMove : IDanceMove
    {
        private readonly char _programA;
        private readonly char _programB;

        public SwapProgramMove(char programA, char programB)
        {
            _programA = programA;
            _programB = programB;
        }

        public void Perform(ref char[] programs)
        {
            var indexA = IndexOf(_programA, programs);
            var indexB = IndexOf(_programB, programs);
            new SwapPositionMove(indexA, indexB).Perform(ref programs);
        }

        private static int IndexOf(char program, IReadOnlyList<char> programs)
        {
            for (var i = 0; i < programs.Count; i++)
                if (programs[i] == program)
                    return i;
            return -1;
        }
    }
}