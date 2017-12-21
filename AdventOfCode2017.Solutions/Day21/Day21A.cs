using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day21
{
    using ParserType = MultiLineStringParser;

    internal class Day21A : IProblem
    {
        private readonly ParserType _parser;

        public Day21A(ParserType parser) { _parser = parser; }

        public Day21A() : this(new ParserType("Day21\\day21.in")) { }

        public virtual string Solve()
        {
            return Iterate(5);
        }

        protected string Iterate(int numberOfIterations)
        {
            var lines = _parser.GetData()
                .Select(l => l.Split(new[] {" => "}, StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

            var fractal = ".#./..#/###";
            var rules = BuildRulesLookup(lines);

            for (var iteration = 0; iteration < numberOfIterations; iteration++)
            {
                var expandedFractal = new List<string>();
                var rows = fractal.Split('/');
                var size = rows[0].Length;
                if (rows[0].Length % 2 == 0)
                {
                    for (var x = 0; x < size; x += 2)
                    {
                        var newRows = new[] {new StringBuilder(), new StringBuilder(), new StringBuilder()};
                        for (var y = 0; y < size; y += 2)
                        {
                            var pattern = new StringBuilder();
                            pattern.Append(rows[x][y]).Append(rows[x][y + 1]).Append('/');
                            pattern.Append(rows[x + 1][y]).Append(rows[x + 1][y + 1]);

                            var replacement = rules[pattern.ToString()].Split('/');
                            newRows[0].Append(replacement[0]);
                            newRows[1].Append(replacement[1]);
                            newRows[2].Append(replacement[2]);
                        }

                        expandedFractal.Add(string.Join("/", newRows.Select(sb => sb.ToString())));
                    }
                }
                else
                {
                    for (var x = 0; x < size; x += 3)
                    {
                        var newRows = new[]
                            {new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder()};
                        for (var y = 0; y < size; y += 3)
                        {
                            var pattern = new StringBuilder();
                            pattern.Append(rows[x][y]).Append(rows[x][y + 1]).Append(rows[x][y + 2]).Append('/');
                            pattern.Append(rows[x + 1][y]).Append(rows[x + 1][y + 1]).Append(rows[x + 1][y + 2])
                                .Append('/');
                            pattern.Append(rows[x + 2][y]).Append(rows[x + 2][y + 1]).Append(rows[x + 2][y + 2]);

                            var replacement = rules[pattern.ToString()].Split('/');
                            newRows[0].Append(replacement[0]);
                            newRows[1].Append(replacement[1]);
                            newRows[2].Append(replacement[2]);
                            newRows[3].Append(replacement[3]);
                        }
                        expandedFractal.Add(string.Join("/", newRows.Select(sb => sb.ToString())));
                    }
                }

                fractal = string.Join("/", expandedFractal);
                //PrintMatrix(fractal);
            }

            return fractal.Count(c => c == '#').ToString();
        }

        private void PrintMatrix(string m)
        {
            foreach (var row in m.Split('/'))
                Console.WriteLine(row);
            Console.WriteLine("=======================");
        }

        private static string AsMatrixString(string m)
        {
            var sb = new StringBuilder();
            foreach (var row in m.Split('/'))
                sb.AppendLine(row);
            return sb.ToString();
        }

        private static Dictionary<string, string> BuildRulesLookup(string[][] lines)
        {
            var rules = new Dictionary<string, string>();
            foreach (var rule in lines)
            {
                if (!rules.ContainsKey(rule[0]))
                    rules.Add(rule[0], rule[1]);

                var matchAsMatrix = To2DArray(rule[0]);
                for (var i = 0; i < 3; i++)
                {
                    matchAsMatrix = Rotate(matchAsMatrix);
                    var m = BackToString(matchAsMatrix);
                    if (!rules.ContainsKey(m))
                        rules.Add(m, rule[1]);
                }

                matchAsMatrix = Flip(matchAsMatrix);
                for (var i = 0; i < 4; i++)
                {
                    matchAsMatrix = Rotate(matchAsMatrix);
                    var m = BackToString(matchAsMatrix);
                    if (!rules.ContainsKey(m))
                        rules.Add(m, rule[1]);
                }
            }
            return rules;
        }

        private static char[][] To2DArray(string matrix)
        {
            return matrix.Split('/').Select(s => s.ToCharArray()).ToArray();
        }

        private static string BackToString(char[][] matrix)
        {
            return string.Join("/", matrix.Select(m => new string(m)));
        }

        private static char[][] Rotate(char[][] matrix)
        {
            var n = matrix.Length;
            for (var layer = 0; layer < n / 2; layer++)
            {
                var first = layer;
                var last = n - 1 - layer;
                for (var i = first; i < last; i++)
                {
                    var offset = i - first;
                    var top = matrix[first][i];
                    matrix[first][i] = matrix[last - offset][first];
                    matrix[last - offset][first] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[i][last];
                    matrix[i][last] = top;
                }
            }

            return matrix;
        }

        private static char[][] Flip(char[][] matrix)
        {
            foreach (var row in matrix)
                Array.Reverse(row);
            return matrix;
        }
    }
}
