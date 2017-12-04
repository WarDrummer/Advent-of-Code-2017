namespace AdventOfCode2017.Solutions
{
    using System.Collections.Generic;
    internal static class SpiralCoordinates
    {
        internal static IEnumerable<Coordinate> GenerateCounterClockwise(int number)
        {
            var current = 1;
            var x = 1;
            var y = 1;
            var width = 8;

            yield return new Coordinate(x, y);

            while (current < number)
            {
                yield return new Coordinate(++x, y);

                var len = width / 4;

                // move up
                for (var i = 0; i < len - 1; i++)
                    yield return new Coordinate(x, ++y);

                // move left
                for (var i = 0; i < len; i++)
                    yield return new Coordinate(--x, y);

                // move down
                for (var i = 0; i < len; i++)
                    yield return new Coordinate(x, --y);

                // move right
                for (var i = 0; i < len; i++)
                    yield return new Coordinate(++x, y);

                current += width;
                width += 8;
            }
        }
    }
}
