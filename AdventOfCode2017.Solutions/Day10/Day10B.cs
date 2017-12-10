using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Solutions.Day10
{
    internal class Day10B : Day10A
    {
        public override string Solve()
        {
            var lengths = Parser.GetData().Select(c => (int)c).ToList();
            lengths.AddRange(new[] { 17, 31, 73, 47, 23 });

            var head = Enumerable.Range(0, 256).ToArray().BuildCircularList();

            var skipSize = 0;
            var current = head;

            for (var count = 0; count < 64; count++)
                KnotHash(lengths, ref current, ref skipSize);

            var denseHash = ConvertToDenseHash(head);
            return ConvertToHashString(denseHash);
        }

        private static string ConvertToHashString(IEnumerable<int> hash)
        {
            var sb = new StringBuilder();

            foreach (var hex in hash)
                sb.Append(hex.ToString("x2"));

            return sb.ToString();
        }

        private static int[] ConvertToDenseHash(Node<int> head)
        {
            var output = new int[16];
            var values = head.ToList();

            for (var x = 0; x < values.Count; x += 16)
            {
                output[x / 16] =
                    values[x] ^ values[x + 1] ^ values[x + 2] ^ values[x + 3] ^
                    values[x + 4] ^ values[x + 5] ^ values[x + 6] ^ values[x + 7] ^
                    values[x + 8] ^ values[x + 9] ^ values[x + 10] ^ values[x + 11] ^
                    values[x + 12] ^ values[x + 13] ^ values[x + 14] ^ values[x + 15];
            }
            return output;
        }
    }
}
