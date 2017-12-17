using System;

namespace AdventOfCode2017.Solutions.Day16
{
    public class RotateMove : IDanceMove
    {
        private readonly int _programLength;
        private readonly int _rotation;
        private static char[] _rotated;

        public RotateMove(int rotation, int programLength)
        {
            _programLength = programLength;
            _rotation = rotation % programLength;
            _rotated = new char[programLength];
        }

        public void Perform(ref char[] programs)
        {
            // needs to be in-place
            Array.Copy(programs, _rotated, _programLength);
            var rotation = _programLength - _rotation;
            for (var i = 0; i < _programLength; i++, rotation++)
                programs[i] = _rotated[rotation % _programLength];
        }
    }
}