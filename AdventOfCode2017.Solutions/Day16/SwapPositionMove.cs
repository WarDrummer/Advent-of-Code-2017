namespace AdventOfCode2017.Solutions.Day16
{
    public class SwapPositionMove : IDanceMove
    {
        private readonly int _indexA;
        private readonly int _indexB;

        public SwapPositionMove(int indexA, int indexB)
        {
            _indexA = indexA;
            _indexB = indexB;
        }

        public void Perform(ref char[] programs)
        {
            var temp = programs[_indexA];
            programs[_indexA] = programs[_indexB];
            programs[_indexB] = temp;
        }
    }
}